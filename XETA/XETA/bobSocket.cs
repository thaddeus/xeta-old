using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.Windows.Forms;
using SlimDX.Direct3D9;
using System.Collections.Generic;
using System.Drawing;
using System.Collections.ObjectModel;
using SlimDX;
using System.ComponentModel;

public class bobLight
{
    private string name = null;
    private float hscan_min, hscan_max, vscan_min, vscan_max = 0.0F;
    private Collection<long> positions = new Collection<long>();
    public bobLight(string blname, float blvscan_min, float blvscan_max, float blhscan_min, float blhscan_max)
    {
        name = blname;
        hscan_min = blhscan_min;
        hscan_max = blhscan_max;
        vscan_min = blvscan_min;
        vscan_max = blvscan_max;
    }

    public string getName()
    {
        return name;
    }

    public float getHmax()
    {
        return hscan_max;
    }

    public float getHmin()
    {
        return hscan_min;
    }

    public float getVmax()
    {
        return vscan_max;
    }

    public float getVmin()
    {
        return vscan_min;
    }

    public void addPosition(long position)
    {
        positions.Add(position);
    }

    public Collection<long> getPositions()
    {
        return positions;
    }
}

public class bobController
{
    private Socket lightSocket = null;
    private byte[] bytes = new byte[8192];
    private bobLight[] lights = null;
    DxScreenCapture sc = new DxScreenCapture();
    private Surface s;
    private BackgroundWorker bw = new BackgroundWorker();
    public double luminosityModifier = 1D;
    public double saturationModifier = 1D;

    public bobController(string ip, int port, int priority = 128)
    {
        this.bw.WorkerSupportsCancellation = true;
        this.bw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_DoWork);
        this.bw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
        try
        {
            //Connect to boblightd
            IPAddress ipAddress = IPAddress.Parse(ip);
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

            // Create a TCP/IP  socket.
            lightSocket = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            // Connect the socket to the remote endpoint. Catch any errors.
            try
            {
                lightSocket.Connect(remoteEP);
                //Okay, we're now connected.

                //Handshake time. Shake that hand.
                sendData("hello\n");

                if (receiveData() == "hello\n")
                {
                    //Hooray, the server said hi back.
                    //Set the priority of the client, the lights won't work without it.
                    setPriority(127);
                    //Oh, we might actually need to know something about the lights too.
                    retrieveLights();
                    foreach (bobLight light in lights)
                    {
                        setSpeed(light, 40.0F);
                    }
                }
                else
                {
                    throw new Exception("Handshake failed.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    private void bw_DoWork(object sender, DoWorkEventArgs e)
    {
        // Do not access the form's BackgroundWorker reference directly. 
        // Instead, use the reference provided by the sender parameter.
        BackgroundWorker bw = sender as BackgroundWorker;

        // Extract the argument. 

        // Start the time-consuming operation.
        e.Result = screenCapture();

        // If the operation was canceled by the user,  
        // set the DoWorkEventArgs.Cancel property to true. 
        if (bw.CancellationPending)
        {
            e.Cancel = true;
        }
    }

    // This event handler demonstrates how to interpret  
    // the outcome of the asynchronous operation implemented 
    // in the DoWork event handler. 
    private void bw_RunWorkerCompleted(
        object sender,
        RunWorkerCompletedEventArgs e)
    {
        if (e.Cancelled)
        {
            // The user canceled the operation.
        }
        else if (e.Error != null)
        {
            // There was an error during the operation. 
        }
        else
        {
            // The operation completed normally. 
            bw.RunWorkerAsync();
        }
    }

    public void startAmbilight()
    {
        bw.RunWorkerAsync();
    }


    public void killClient()
    {
        lightSocket.Close();
        lightSocket = null;
    }

    public bool screenCapture()
    {
        s = sc.CaptureScreen();
        DataRectangle dr = s.LockRectangle(LockFlags.None);
        DataStream gs = dr.Data;

        foreach (bobLight light in lights)
        {
            if (light.getName().Contains("General"))
                continue;
            HSLColor colorstring = DxScreenCapture.avcs(gs, light.getPositions());
            colorstring.Saturation = colorstring.Saturation * saturationModifier;
            colorstring.Luminosity = colorstring.Luminosity * luminosityModifier;
            int[] colorArray = colorstring.getRGB();
            setColor(light, colorArray[0], colorArray[1], colorArray[2], 1.0F);
        }

        syncLights();

        s.UnlockRectangle();
        s.Dispose();
        return true;
    }

    public void calculateArea()
    {
        int o = 20;
        int sx = Screen.PrimaryScreen.Bounds.Width;
        int sy = Screen.PrimaryScreen.Bounds.Height;

        long x, y;
        long pos;

        for (x = 0; x < sx; x += o)
        {
            for (y = 0; y < sy; y += o)
            {
                foreach (bobLight light in lights)
                {
                    if (light.getName().Contains("General"))
                        continue;
                    if (x >= (light.getHmin() * sx) && x <= (light.getHmax() * sx) && y >= (light.getVmin() * sy) && y <= (light.getVmax() * sy))
                    {
                        pos = (y * sx + x) * 4;
                        light.addPosition(pos);
                    }
                }
            }
        }
    }

    public void setColor(bobLight light, string color, float brightness)
    {
        if (isConnected())
        {
            float red, green, blue = 0.0F;
            red = int.Parse(color.Substring(0, 2), System.Globalization.NumberStyles.HexNumber) / 255F * brightness;
            green = int.Parse(color.Substring(2, 2), System.Globalization.NumberStyles.HexNumber) / 255F * brightness;
            blue = int.Parse(color.Substring(4, 2), System.Globalization.NumberStyles.HexNumber) / 255F * brightness;
            sendData("set light " + light.getName() + " rgb " + red.ToString() + " " + green.ToString() + " " + blue.ToString() + "\n");
        }
    }

    public void setColor(bobLight light, int ired, int igreen, int iblue, float brightness)
    {
        if (isConnected())
        {
            float red, green, blue = 0.0F;
            red = ired / 255F * brightness;
            green = igreen / 255F * brightness;
            blue = iblue / 255F * brightness;
            sendData("set light " + light.getName() + " rgb " + red.ToString() + " " + green.ToString() + " " + blue.ToString() + "\n");
        }
    }

    public void setColor(bobLight[] lights, string color, float brightness)
    {
        if (isConnected())
        {
            float red, green, blue = 0.0F;
            red = Int32.Parse(color.Substring(0, 2), System.Globalization.NumberStyles.HexNumber) / 255 * brightness;
            green = Int32.Parse(color.Substring(2, 2), System.Globalization.NumberStyles.HexNumber) / 255 * brightness;
            blue = Int32.Parse(color.Substring(4, 2), System.Globalization.NumberStyles.HexNumber) / 255 * brightness;
            foreach (bobLight light in lights)
            {
                sendData("set light " + light.getName() + " rgb " + red.ToString() + " " + green.ToString() + " " + blue.ToString() + "\n");
            }
        }
    }

    public void setColor(bobLight[] lights, int ired, int igreen, int iblue, float brightness)
    {
        if (isConnected())
        {
            float red, green, blue = 0.0F;
            red = ired / 255 * brightness;
            green = igreen / 255 * brightness;
            blue = iblue / 255 * brightness;
            foreach (bobLight light in lights)
            {
                sendData("set light " + light.getName() + " rgb " + red.ToString() + " " + green.ToString() + " " + blue.ToString() + "\n");
            }
        }
    }

    public void setSpeed(bobLight light, float speed)
    {
        if (isConnected())
        {
            sendData("set light " + light.getName() + " speed " + speed.ToString() + "\n");
        }
    }

    public void setSpeed(bobLight[] lights, float speed)
    {
        if (isConnected())
        {
            foreach (bobLight light in lights)
            {
                sendData("set light " + light.getName() + " speed " + speed.ToString() + "\n");
            }
        }
    }

    public void setUse(bobLight light, bool use)
    {
        if (isConnected())
        {
            sendData("set light " + light.getName() + " use " + use.ToString() + "\n");
        }
    }

    public void setUse(bobLight[] lights, bool use)
    {
        if (isConnected())
        {
            foreach (bobLight light in lights)
            {
                sendData("set light " + light.getName() + " use " + use.ToString() + "\n");
            }
        }
    }

    public void syncLights()
    {
        if (isConnected())
        {
            sendData("sync\n");
        }
    }

    public void setPriority(int priority)
    {
        if (isConnected())
            sendData("set priority " + priority.ToString() + "\n");
    }

    private void retrieveLights()
    {
        if (isConnected())
        {
            //Communicate with boblight server and get back the lights
            sendData("get lights\n");
            string lightsData = receiveData();

            //Remove the last new line, then split everything into something useful
            string[] lightArray = lightsData.Remove(lightsData.Length - 1, 1).Split(UnicodeEncoding.Unicode.GetChars(UnicodeEncoding.Unicode.GetBytes("\n")));
            lights = new bobLight[Convert.ToInt32(lightArray[0].Substring(7))];
            for (int i = 1; i < lightArray.Length; i++)
            {
                string[] lightData = lightArray[i].Split(UnicodeEncoding.Unicode.GetChars(UnicodeEncoding.Unicode.GetBytes(" ")));
                lights[i - 1] = new bobLight(lightData[1], float.Parse(lightData[3]) / 100, float.Parse(lightData[4]) / 100, float.Parse(lightData[5]) / 100, float.Parse(lightData[6]) / 100);
            }

            calculateArea();
        }
    }

    public bobLight[] getLights()
    {
        return lights;
    }

    public bool isConnected()
    {
        if (lightSocket != null)
            return lightSocket.Connected;
        else
            return false;
    }

    private void sendData(string data)
    {
        lightSocket.Send(Encoding.UTF8.GetBytes(data));
    }

    private string receiveData()
    {
        int bytesRec = lightSocket.Receive(bytes);
        string data = Encoding.UTF8.GetString(bytes, 0, bytesRec);
        return data;
    }
}

public class DxScreenCapture
{
    Device d;

    public DxScreenCapture()
    {
        PresentParameters present_params = new PresentParameters();
        present_params.Windowed = true;
        present_params.SwapEffect = SwapEffect.Discard;
        d = new Device(new Direct3D(), 0, DeviceType.Hardware, IntPtr.Zero, CreateFlags.SoftwareVertexProcessing, present_params);
    }

    public Surface CaptureScreen()
    {
        Surface s = Surface.CreateOffscreenPlain(d, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, Format.A8R8G8B8, Pool.Scratch);
        d.GetFrontBufferData(0, s);
        return s;
    }

    public static HSLColor avcs(DataStream gs, Collection<long> positions)
    {
        byte[] bu = new byte[4];
        int r = 0;
        int g = 0;
        int b = 0;
        int i = 0;

        foreach (long pos in positions)
        {
            gs.Position = pos;
            gs.Read(bu, 0, 4);
            r += bu[2];
            g += bu[1];
            b += bu[0];
            i++;
        }

        return new HSLColor(r / i, g / i, b / i);
    }
}

public class HSLColor
{
    // Private data members below are on scale 0-1
    // They are scaled for use externally based on scale
    private double hue = 1.0;
    private double saturation = 1.0;
    private double luminosity = 1.0;

    private const double scale = 240.0;

    public double Hue
    {
        get { return hue * scale; }
        set { hue = CheckRange(value / scale); }
    }
    public double Saturation
    {
        get { return saturation * scale; }
        set { saturation = CheckRange(value / scale); }
    }
    public double Luminosity
    {
        get { return luminosity * scale; }
        set { luminosity = CheckRange(value / scale); }
    }

    private double CheckRange(double value)
    {
        if (value < 0.0)
            value = 0.0;
        else if (value > 1.0)
            value = 1.0;
        return value;
    }

    public override string ToString()
    {
        return String.Format("H: {0:#0.##} S: {1:#0.##} L: {2:#0.##}", Hue, Saturation, Luminosity);
    }

    public string ToRGBString()
    {
        Color color = (Color)this;
        return String.Format("R: {0:#0.##} G: {1:#0.##} B: {2:#0.##}", color.R, color.G, color.B);
    }

    public int[] getRGB()
    {
        Color color = (Color)this;
        int[] colorArray = new int[3];
        colorArray[0] = color.R;
        colorArray[1] = color.G;
        colorArray[2] = color.B;
        return colorArray;
    }

    #region Casts to/from System.Drawing.Color
    public static implicit operator Color(HSLColor hslColor)
    {
        double r = 0, g = 0, b = 0;
        if (hslColor.luminosity != 0)
        {
            if (hslColor.saturation == 0)
                r = g = b = hslColor.luminosity;
            else
            {
                double temp2 = GetTemp2(hslColor);
                double temp1 = 2.0 * hslColor.luminosity - temp2;

                r = GetColorComponent(temp1, temp2, hslColor.hue + 1.0 / 3.0);
                g = GetColorComponent(temp1, temp2, hslColor.hue);
                b = GetColorComponent(temp1, temp2, hslColor.hue - 1.0 / 3.0);
            }
        }
        return Color.FromArgb((int)(255 * r), (int)(255 * g), (int)(255 * b));
    }



    private static double GetColorComponent(double temp1, double temp2, double temp3)
    {
        temp3 = MoveIntoRange(temp3);
        if (temp3 < 1.0 / 6.0)
            return temp1 + (temp2 - temp1) * 6.0 * temp3;
        else if (temp3 < 0.5)
            return temp2;
        else if (temp3 < 2.0 / 3.0)
            return temp1 + ((temp2 - temp1) * ((2.0 / 3.0) - temp3) * 6.0);
        else
            return temp1;
    }
    private static double MoveIntoRange(double temp3)
    {
        if (temp3 < 0.0)
            temp3 += 1.0;
        else if (temp3 > 1.0)
            temp3 -= 1.0;
        return temp3;
    }
    private static double GetTemp2(HSLColor hslColor)
    {
        double temp2;
        if (hslColor.luminosity < 0.5)  //<=??
            temp2 = hslColor.luminosity * (1.0 + hslColor.saturation);
        else
            temp2 = hslColor.luminosity + hslColor.saturation - (hslColor.luminosity * hslColor.saturation);
        return temp2;
    }

    public static implicit operator HSLColor(Color color)
    {
        HSLColor hslColor = new HSLColor();
        hslColor.hue = color.GetHue() / 360.0; // we store hue as 0-1 as opposed to 0-360 
        hslColor.luminosity = color.GetBrightness();
        hslColor.saturation = color.GetSaturation();
        return hslColor;
    }
    #endregion

    public void SetRGB(int red, int green, int blue)
    {
        HSLColor hslColor = (HSLColor)Color.FromArgb(red, green, blue);
        this.hue = hslColor.hue;
        this.saturation = hslColor.saturation;
        this.luminosity = hslColor.luminosity;
    }

    public HSLColor() { }
    public HSLColor(Color color)
    {
        SetRGB(color.R, color.G, color.B);
    }
    public HSLColor(int red, int green, int blue)
    {
        SetRGB(red, green, blue);
    }
    public HSLColor(double hue, double saturation, double luminosity)
    {
        this.Hue = hue;
        this.Saturation = saturation;
        this.Luminosity = luminosity;
    }

}
