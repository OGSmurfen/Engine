using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SnakeMultiplayer
{
    public class UDPSender : IDisposable
    {
        private static UDPSender _instance;

        private UdpClient udpClient;

        public static UDPSender Instance
        {
            get 
            { 
            if(_instance == null)
                _instance = new UDPSender();

            return _instance;
            }
        }

        public void Connect(string ipAddress, int port)
        {
            udpClient.Connect(ipAddress, port);
        }
        
        public void SendSnakeSegments(List<Rectangle> snakeSegments)
        {
            string json = JsonSerializer.Serialize(snakeSegments, new JsonSerializerOptions { IncludeFields = true });
            byte[] bytes = Encoding.UTF8.GetBytes(json);
            udpClient.Send(bytes, bytes.Length);
        }

        private UDPSender()
        {
            udpClient = new UdpClient();
        }

        public void Dispose()
        {
            udpClient.Close();
            udpClient.Dispose();
        }

    }
}
