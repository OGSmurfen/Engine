using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SnakeMultiplayer
{
    public class UDPJoin : IDisposable
    {
        private static UDPJoin _instance;

        private UdpClient udpClient;

        public bool IsConnected { get; private set; }

        public static UDPJoin Instance
        {
            get 
            { 
            if(_instance == null)
                _instance = new UDPJoin();

            return _instance;
            }
        }

        public void Connect(string ipAddress, int port)
        {
            IsConnected = true;
            udpClient.Connect(ipAddress, port);
        }
        
        public void SendSnakeSegments(List<Rectangle> snakeSegments)
        {
            string json = JsonSerializer.Serialize(snakeSegments, new JsonSerializerOptions { IncludeFields = true });
            byte[] bytes = Encoding.UTF8.GetBytes(json);
            udpClient.Send(bytes, bytes.Length);
        }

        private UDPJoin()
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
