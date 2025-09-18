using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SnakeMultiplayer
{
    public class UDPHost : IDisposable
    {
        public static UDPHost Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UDPHost();

                return _instance;
            }
        }

        private static UDPHost _instance;
        private UdpClient udpClient;
        IPEndPoint remoteEndPoint = new IPEndPoint(System.Net.IPAddress.Any, 6969);
        public bool IsBoundToEndpoint { get; set; }

        public List<Rectangle> ReceiveSnakeSegments()
        {
            byte[] bytes = udpClient.Receive(ref remoteEndPoint);

            string jsonStr = System.Text.Encoding.UTF8.GetString(bytes);

            if (string.IsNullOrEmpty(jsonStr))
                return null;

            List<Rectangle> snakeSegments = JsonSerializer.Deserialize<List<Rectangle>>(jsonStr, new JsonSerializerOptions { IncludeFields = true });

            return snakeSegments;
        }

        private UDPHost()
        {
            udpClient = new UdpClient(6969);
        }


        public void Dispose()
        {
            udpClient.Close();
            udpClient.Dispose();
        }
    }
}
