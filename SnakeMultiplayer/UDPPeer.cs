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
    public class UDPPeer
    {
        private UdpClient _udp;

        public static UDPPeer Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UDPPeer();
                return _instance;
            }
        }
        private static UDPPeer _instance;
        private UDPPeer()
        {
            _udp = new UdpClient(6969);
        }

        public void SendSnakeLocation(List<Rectangle> snakeSegments, string ip)
        {
            string json = JsonSerializer.Serialize(snakeSegments, new JsonSerializerOptions { IncludeFields = true });
            byte[] bytes = Encoding.UTF8.GetBytes(json);
            _udp.Send(bytes, bytes.Length, IPEndPoint.Parse(ip));
        }

        public void ReceiveSnakeLocation()
        {

        }


    }
}
