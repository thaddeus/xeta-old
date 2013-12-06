﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.WebSockets;
using System.Threading;
using Newtonsoft.Json;

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

        //Create a new socket client class
        public xetaSocket(string networkAddress, string networkPort, mainGUI gui) 
        {
            mainGUI = gui;
            //Init socket
            socketClient = new ClientWebSocket();
            //Create a token from a cancel source object
            connectCancelToken = connectCancel.Token;
            //Start the connection task
            Task socketConnectTask = socketClient.ConnectAsync(new Uri("ws://" + networkAddress + ":" + networkPort + "/"), connectCancelToken);
            //Lets receive after we've finished connecting
            socketConnectTask.ContinueWith((t) => Receive());
        }

        //Cancel a socket connection attempt
        public void cancelConnect()
        {
            connectCancel.Cancel();
        }

        //Asynchronous Send Task
        public async Task Send(String packet)
        {
            Console.WriteLine("Sending packet: " + packet);
            byte[] buffer = encoding.GetBytes(packet);
            await socketClient.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
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
                socket.Send(outgoing.getPacket(new outgoing.InitializePacket())).Wait();
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
            VolumePacket,
            VolumePeakPacket
        }

        //Tell the server who I am
        public class InitializePacket
        {
            public int packetType = (int)packetTypes.InitializePacket;
            public string clientType = "Daemon";
            public string machineName = System.Environment.MachineName;
            public string machineType = "Windows";
        }
    }
}
