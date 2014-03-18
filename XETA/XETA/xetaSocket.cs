using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.WebSockets;
using System.Threading;
using Newtonsoft.Json;
using System.Threading.Tasks.Dataflow;

namespace XETA
{
    public class xetaSocket
    {
        private ClientWebSocket socketClient;
        private System.Threading.CancellationTokenSource connectCancel = new System.Threading.CancellationTokenSource();
        private System.Threading.CancellationToken connectCancelToken;
        private static UTF8Encoding encoding = new UTF8Encoding();
        public byte connectTick = 0;
        private mainGUI mainGUI;
        private Uri socketUri;
        private BufferBlock<string> messageQueue = new BufferBlock<string>();

        //Create a new socket client class
        public xetaSocket(string networkAddress, string networkPort, mainGUI gui) 
        {
            mainGUI = gui;
            //Init socket
            socketUri = new Uri("ws://" + networkAddress + ":" + networkPort + "/");
            connect();
        }

        public void connect()
        {
            //Create a token from a cancel source object
            connectCancelToken = connectCancel.Token;
            //Start the connection task
            socketClient = new ClientWebSocket();
            Task socketConnectTask = socketClient.ConnectAsync(socketUri, connectCancelToken);
            //Lets send/receive after we've finished connecting
            socketConnectTask.ContinueWith((t) => Receive());
            socketConnectTask.ContinueWith((t) => Send());
        }

        //Cancel a socket connection attempt
        public void cancelConnect()
        {
            connectCancel.Cancel();
        }

        //Asynchronous Send Task
        public async Task Send()
        {
            while(socketClient.State == WebSocketState.Open)
            {
                string packet = await messageQueue.ReceiveAsync();
                if (socketClient.State == WebSocketState.Open)
                {
                    //Continue
                    Console.WriteLine("Sending packet: " + packet);
                    byte[] buffer = encoding.GetBytes(packet);
                    await socketClient.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
                }
                else
                {
                    //Send later
                    messageQueue.Post(packet);
                }
            }
        }

        public void queueMessage(string packet)
        {
            messageQueue.Post(packet);
        }

        //Looping receive for the socket. Cancels when websocket state is no longer open.
        private async Task Receive()
        {
            var buffer = new byte[1024];
            while (socketClient.State == WebSocketState.Open)
            {
                var segment = new ArraySegment<byte>(buffer);
                var result =
                  await socketClient.ReceiveAsync(segment, CancellationToken.None);
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    await socketClient.CloseAsync(WebSocketCloseStatus.NormalClosure, "OK",
                      CancellationToken.None);
                    return;
                }
                if (result.MessageType == WebSocketMessageType.Binary)
                {
                    await socketClient.CloseAsync(WebSocketCloseStatus.InvalidMessageType,
                      "I don't do binary", CancellationToken.None);
                    return;
                }
                int count = result.Count;
                while (!result.EndOfMessage)
                {
                    if (count >= buffer.Length)
                    {
                        await socketClient.CloseAsync(WebSocketCloseStatus.InvalidPayloadData,
                          "That's too long", CancellationToken.None);
                        return;
                    }
                    segment =
                      new ArraySegment<byte>(buffer, count, buffer.Length - count);
                    result = await socketClient.ReceiveAsync(segment, CancellationToken.None);
                    count += result.Count;
                }
                string message = Encoding.UTF8.GetString(buffer, 0, count);
                Packets.processPacket(message, this);
            }
        }

        public WebSocketState getClientState()
        {
            if (socketClient != null)
            {
                return socketClient.State;
            }
            else
            {
                return WebSocketState.None;
            }
            
        }

        public void disconnect()
        {
            socketClient.CloseAsync(WebSocketCloseStatus.NormalClosure, "User requested disconnect", System.Threading.CancellationToken.None);
        }
    }
}

public class Packets
{

    enum packetTypes
    {
        //Tell me about the world
        InitializePacket,
        IdlePacket,
        VolumePacket,
        VolumePeakPacket
    }

    //Process an incoming packet
    public static void processPacket(string packet, XETA.xetaSocket socket)
    {
        //Lets check it based upon a generic packet
        Packets.genericPacket genericPacket = JsonConvert.DeserializeObject<Packets.genericPacket>(packet);

        //What packet is it?
        switch (genericPacket.packetType)
        {
            case 0:
                Console.WriteLine("Recieved Initialize Packet");
                socket.queueMessage(outgoing.getPacket(new outgoing.InitializePacket()));
                break;
            default:
                Console.WriteLine("Invalid Packet Recieved: " + packet);
                break;
        }
    }

    //Data that is generic to all packets
    //Especially useful for packet parsing
    public class genericPacket
    {
        public int packetType;
    }

    //All outbound packets go here
    public class outgoing
    {

        //Stringify!
        public static string getPacket(object classObject)
        {
            return JsonConvert.SerializeObject(classObject);
        }

        //Enumeration of outgoing packetTypes
        enum packetTypes
        {
            //Tell the world about me
            InitializePacket,
            IdlePacket,
            AudioLevelPacket,
            WindowChangePacket
        }

        //Tell the server who I am
        public class InitializePacket
        {
            public int packetType = (int)packetTypes.InitializePacket;
            public string clientType = "Daemon";
            public string machineName = System.Environment.MachineName;
            public string machineType = "Windows";
        }

        public class AudioLevelPacket
        {
            public int packetType = (int)packetTypes.AudioLevelPacket;
            public int masterPeak;
            public int leftPeak;
            public int rightPeak;
            public string machineName = System.Environment.MachineName;
            public AudioLevelPacket(int mPeak, int lPeak, int rPeak)
            {
                masterPeak = mPeak;
                leftPeak = lPeak;
                rightPeak = rPeak;
            }
        }

        public class IdlePacket
        {
            public int packetType = (int)packetTypes.IdlePacket;
            public double idleTime = XETA.Input.SecondsSinceLastInput();
            public string machineName = System.Environment.MachineName;
        }

        public class WindowChangePacket
        {
            public int packetType = (int)packetTypes.WindowChangePacket;
            public string windowName = XETA.Input.GetActiveWindowTitle();
            public string machineName = System.Environment.MachineName;
        }
    }
}
