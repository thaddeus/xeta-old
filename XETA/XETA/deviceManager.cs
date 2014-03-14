using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace XETA
{
    class deviceManager
    {
        public static class onkyoController
        {
            public static string ip;
            public static string port;

            public static void setMusicMode()
            {
                deviceManager.onkyoController.sendMessage("PWR01");
                deviceManager.onkyoController.sendMessage("AMT00");
                deviceManager.onkyoController.sendMessage("SWL-A");
                deviceManager.onkyoController.sendMessage("CTL-5");
                deviceManager.onkyoController.sendMessage("DIM00");
                deviceManager.onkyoController.sendMessage("LMD8C");
                deviceManager.onkyoController.sendMessage("RAS01");
                deviceManager.onkyoController.sendMessage("ADY02");
                deviceManager.onkyoController.sendMessage("ADQ00");
                deviceManager.onkyoController.sendMessage("MOT01");
                deviceManager.onkyoController.sendMessage("LMD8C");
            }

            public static void setMovieMode()
            {
                deviceManager.onkyoController.sendMessage("PWR01");
                deviceManager.onkyoController.sendMessage("AMT00");
                deviceManager.onkyoController.sendMessage("SWL-6");
                deviceManager.onkyoController.sendMessage("CTL+2");
                deviceManager.onkyoController.sendMessage("DIM02");
                deviceManager.onkyoController.sendMessage("RAS01");
                deviceManager.onkyoController.sendMessage("ADY02");
                deviceManager.onkyoController.sendMessage("ADY02");
                deviceManager.onkyoController.sendMessage("MOT00");
                deviceManager.onkyoController.sendMessage("LMD85");
            }

            public static void setGameMode()
            {
                deviceManager.onkyoController.sendMessage("PWR01");
                deviceManager.onkyoController.sendMessage("AMT00");
                deviceManager.onkyoController.sendMessage("SWL-6");
                deviceManager.onkyoController.sendMessage("CTL00");
                deviceManager.onkyoController.sendMessage("DIM00");
                deviceManager.onkyoController.sendMessage("RAS00");
                deviceManager.onkyoController.sendMessage("ADY00");
                deviceManager.onkyoController.sendMessage("ADQ00");
                deviceManager.onkyoController.sendMessage("MOT00");
                deviceManager.onkyoController.sendMessage("LMD01");
            }

            public static async Task sendMessage(string message)
            {
                TcpClient tcpClient = new TcpClient();
                await tcpClient.ConnectAsync(IPAddress.Parse(ip), Int32.Parse(port));
                tcpClient.Client.Send(message.ToISCPCommandMessage(true));
                tcpClient.Close();
            }

            public static string askQuestion(string message)
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), Int32.Parse(port));
                TcpClient tcpClient = new TcpClient();
                tcpClient.Connect(endPoint);
                tcpClient.Client.Send(message.ToISCPCommandMessage(true));
                string reMessage = null;
                bool secondResponse = false;
                byte[] loNotProcessingBytes = null;
                byte[] loResultBuffer;
                while (tcpClient.Client != null)
                {
                    try
                    {
                        if (tcpClient.Client.Available > 0)
                        {
                            var loBuffer = new byte[2048];
                            tcpClient.Client.Receive(loBuffer, loBuffer.Length, SocketFlags.None);

                            if (loNotProcessingBytes != null && loNotProcessingBytes.Length > 0)
                                loResultBuffer = loNotProcessingBytes.Concat(loBuffer).ToArray();
                            else
                                loResultBuffer = loBuffer;

                            Console.WriteLine("Receive byte [] {0}{1}", Environment.NewLine, loResultBuffer.FormatToOutput());
                            foreach (var lsMessage in loResultBuffer.ToISCPStatusMessage(out loNotProcessingBytes))
                            {
                                Console.WriteLine("Receive Message {0}", lsMessage);
                                reMessage = lsMessage;
                                if(secondResponse)
                                {
                                    return reMessage;
                                }
                                else
                                {
                                    secondResponse = true;
                                }
                                
                            }
                            
                        }  
                    }
                    catch (Exception exp)
                    {
                        //We had a problem
                    }
                }
                return null;
            }
        }

    }

    public static class ISCPExtensions
    {
        public static byte[] ToISCPCommandMessage(this string value, bool pbAddMessageChar)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("value is null or empty.", "value");

            Console.WriteLine("Convert string {0}", value);
            List<byte> loISCPMessage = new List<byte>();
            byte[] loCommandBytes = pbAddMessageChar ? Encoding.ASCII.GetBytes("!1" + value) : Encoding.ASCII.GetBytes(value);

            loISCPMessage.AddRange(ASCIIEncoding.ASCII.GetBytes("ISCP"));
            loISCPMessage.AddRange(BitConverter.GetBytes(0x00000010).Reverse());
            loISCPMessage.AddRange(BitConverter.GetBytes(loCommandBytes.Length + 1).Reverse());
            loISCPMessage.AddRange(BitConverter.GetBytes(0x01));
            loISCPMessage.AddRange(new byte[] { 0x00, 0x00, 0x00 });
            loISCPMessage.AddRange(loCommandBytes);

            loISCPMessage.Add(ISCPDefinitions.EndCharacter["CR"]);
            loISCPMessage.Add(ISCPDefinitions.EndCharacter["LF"]);
            loISCPMessage.Add(ISCPDefinitions.EndCharacter["EOF"]);

            return loISCPMessage.ToArray();
        }

        public static class ISCPDefinitions
        {
            internal static Dictionary<string, byte> EndCharacter = new Dictionary<string, byte>() 
                { 
                    {"EOF", 0x1A}, //1
                    {"CR" , 0x0D}, //2
                    {"LF",  0x0A}, //3
                    {"EM",  0x19}
                };

            public static List<string> EndCharacterKeys
            {
                get { return new List<string>(EndCharacter.Keys); }
            }

            public static string EmptyNetInfo
            {
                get { return "---"; }
            }
        }

        public static List<string> ToISCPStatusMessage(this byte[] value, out byte[] poNotProcessingBytes)
        {
            if (value == null || value.Length == 0)
                throw new ArgumentException("value is null or empty.", "value");
            if (value.Length <= 16)
                throw new ArgumentException("value is not an ISCP-Message.", "value");
            const int lnDataSizePostion = 8;
            const int lnDataSizeBytes = 4;
            List<string> loReturnList = new List<string>();
            string lsMessage;
            int lnStartSearchIndex = 0;
            int lnISCPIndex;
            poNotProcessingBytes = new byte[0];

            while ((lnISCPIndex = NextHeaderIndex(value, lnStartSearchIndex)) > -1)
            {
                if (value.Length > (lnISCPIndex + lnDataSizePostion + 4))
                {
                    int lnDataSize = BitConverter.ToInt32(Enumerable.Take(value.Skip(lnISCPIndex + lnDataSizePostion), lnDataSizeBytes).Reverse().ToArray(), 0);
                    if (value.Length >= (lnISCPIndex + 16 + lnDataSize))
                    {
                        lsMessage = ConvertMessage(value, lnISCPIndex + 16, lnDataSize);
                        loReturnList.Add(lsMessage);
                        lnStartSearchIndex = lnISCPIndex + 16 + lnDataSize;
                    }
                    else
                        break;
                }
                else
                    break;
            }

            if (value.Length > lnStartSearchIndex && !value.Skip(lnStartSearchIndex).All(item => item == 0x00))
            {
                poNotProcessingBytes = value.Skip(lnStartSearchIndex).ToArray();
            }

            return loReturnList;
        }

        public static string FormatToOutput(this byte[] value)
        {
            StringBuilder loBuilder = new StringBuilder();
            for (int i = 0; i < value.Length; i++)
            {
                loBuilder.AppendFormat("{0:x2} ", value[i]);
                if ((i + 1) % 4 == 0)
                    loBuilder.AppendLine();
            }
            return loBuilder.ToString().Trim();
        }

        public static int ConvertHexValueToInt(this string value)
        {
            return Convert.ToInt32(value.Trim(), 16);
        }

        public static long ConvertHexValueToLong(this string value)
        {
            return Convert.ToInt64(value.Trim(), 16);
        }

        public static byte ConvertHexValueToByte(this string value)
        {
            return Convert.ToByte(value.Trim(), 16);
        }

        public static byte[] ConvertHexValueToByteArray(this string value)
        {
            List<byte> loByteList = new List<byte>();
            var loMatch = System.Text.RegularExpressions.Regex.Match(value, @"(\w\w)");
            while (loMatch.Success)
            {
                loByteList.Add(loMatch.Groups[1].Value.ConvertHexValueToByte());
                loMatch = loMatch.NextMatch();
            }

            return loByteList.ToArray();
        }

        public static string ConverIntValueToHexString(this int value)
        {
            return "{0:x2}".FormatWith(value).ToUpper();
        }

        private static List<int> SearchStartIndexHeader(byte[] poBytes)
        {
            List<int> loIndexList = new List<int>();
            byte[] loISCPBytes = ASCIIEncoding.ASCII.GetBytes("ISCP");
            if (poBytes.Length >= loISCPBytes.Length)
            {
                for (int i = 0; i < poBytes.Length; i++)
                {
                    if (!IsMatch(poBytes, i, loISCPBytes))
                        continue;
                    loIndexList.Add(i);
                }
            }
            return loIndexList;
        }

        private static int NextHeaderIndex(byte[] poBytes, int pnStart)
        {
            byte[] loISCPBytes = ASCIIEncoding.ASCII.GetBytes("ISCP");

            if (poBytes.Length > (pnStart + loISCPBytes.Length))
            {
                for (int i = pnStart; i < poBytes.Length; i++)
                {
                    if (!IsMatch(poBytes, i, loISCPBytes))
                        continue;
                    return i; //ISCP Header Found
                }
            }
            return -1;
        }

        private static bool IsMatch(byte[] poSourceArray, int pnPosition, byte[] poSearchArray)
        {
            if (poSearchArray.Length > (poSourceArray.Length - pnPosition))
                return false;

            for (int i = 0; i < poSearchArray.Length; i++)
                if (poSourceArray[pnPosition + i] != poSearchArray[i])
                    return false;

            return true;
        }

        private static string ConvertMessage(byte[] poSourceArray, int pnStartIndex, int pnCount)
        {
            int lnCount = pnCount;
            for (int i = pnStartIndex + pnCount - 1; i >= 0; i--)
            {
                if (ISCPDefinitions.EndCharacter.Values.Contains(poSourceArray[i]))
                    lnCount--;
                else
                    break;
            }
            string lsMessage = UnicodeEncoding.UTF8.GetString(poSourceArray, pnStartIndex, lnCount);

            return lsMessage;
        }

        public static string FormatWith(this string value, params object[] parameters)
        {
            return string.Format(value, parameters);
        }
    }
}
