using Microsoft.Xna.Framework;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading.Tasks;

namespace SnakeUDPListener
{
    public class Program
    {
        static void Main(string[] args)
        {

            UdpClient client = new UdpClient(6969);

            IPEndPoint remoteEndPoint = new IPEndPoint(System.Net.IPAddress.Any, 6969);

            while (true)
            {
                byte[] bytes = client.Receive(ref remoteEndPoint);

                string jsonStr = System.Text.Encoding.UTF8.GetString(bytes);

                if (string.IsNullOrEmpty(jsonStr))
                    continue;

                List<Rectangle> snakeSegments = JsonSerializer.Deserialize<List<Rectangle>>(jsonStr, new JsonSerializerOptions { IncludeFields = true });


                Console.Clear();
                Console.WriteLine($"Snake segments: {snakeSegments.Count}");
                for (int i = 0; i < snakeSegments.Count; i++)
                {
                    Console.WriteLine(
                        $"Segment{i}: X={snakeSegments[i].X}, Y={snakeSegments[i].Y}, Width={snakeSegments[i].Width}, Height={snakeSegments[i].Height}"
                        );
                }

            }

        }
    }
}
