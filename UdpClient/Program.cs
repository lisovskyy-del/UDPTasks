using System.Net;
using System.Net.Sockets;
using System.Text;
using UdpClient.Utils;

namespace UdpClient;

class Program
{
    static void Main()
    {
        Socket clientSocket = new Socket(
            AddressFamily.InterNetwork,
            SocketType.Dgram,
            ProtocolType.Udp
        );

        clientSocket.ReceiveTimeout = 2000;

        while (true)
        {
            try
            {
                string message = InputHelpers.StringInput("\nEnter a message: ");

                byte[] data = Encoding.UTF8.GetBytes(message);

                EndPoint serverEndPoint = new IPEndPoint(IPAddress.Loopback, 5005);

                clientSocket.SendTo(data, serverEndPoint);

                Console.WriteLine("Packet sent!");

                byte[] buffer = new byte[1024];

                EndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);

                int receivedBytes = clientSocket.ReceiveFrom(buffer, ref remoteEndPoint);

                string response = Encoding.UTF8.GetString(buffer, 0, receivedBytes);

                Console.WriteLine($"Server response: {response}");
            }
            catch (SocketException ex)
            {
                if (ex.SocketErrorCode == SocketError.TimedOut)
                {
                    Console.WriteLine("Timeout!");
                }
            }
        }
    }
}