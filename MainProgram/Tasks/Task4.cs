using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Text;

namespace MainProgram.Tasks;

class Task4
{
    public static void Run()
    {
        Socket socket = new Socket(
            AddressFamily.InterNetwork,
            SocketType.Dgram,
            ProtocolType.Udp
        );

        

        IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 5005);
        socket.Bind(endPoint);

        Console.WriteLine("UDP server launched on port 5005... (Launch UdpClient)");

        while (true)
        {
            byte[] buffer = new byte[1024];

            EndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);

            int receivedBytes = socket.ReceiveFrom(buffer, ref remoteEndPoint);

            string message = Encoding.UTF8.GetString(buffer, 0, receivedBytes);

            Console.WriteLine($"Received from {remoteEndPoint}: {message}");

            string response = $"Server received: {message}";
            byte[] responseBytes = Encoding.UTF8.GetBytes(response);

            socket.SendTo(responseBytes, remoteEndPoint);
        }
    }
}