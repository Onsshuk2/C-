using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Collections.Generic;

namespace np_sync_sockets
{
    class Program
    {
        static string address = "127.0.0.1"; 
        static int port = 8080; 
        static void Main(string[] args)
        {
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
            UdpClient listener = new UdpClient(ipPoint);

           
            Dictionary<string, string> responses = new Dictionary<string, string>()
            {
                { "hello", "hi" },
                { "how are you", "I'm fine. And you?" },
                { "So far, so good", "It's great!" },
                { "What do you think about IT Step", "I think, it's the most beautiful school" },
                { "goodbye", "see you" }
            };

            try
            {
                Console.WriteLine("The server is running! Waiting for messages...");

                while (true)
                {
                    
                    byte[] data = listener.Receive(ref remoteEndPoint);
                    string receivedMessage = Encoding.Unicode.GetString(data).ToLower();

                    Console.WriteLine($"{DateTime.Now.ToShortTimeString()}: message received \"{receivedMessage}\" from {remoteEndPoint}");

                   
                    string responseMessage;
                    if (responses.TryGetValue(receivedMessage, out responseMessage))
                    {
                        responseMessage = $"Server: {responseMessage}";
                    }
                    else
                    {
                        responseMessage = "Server: Sorry, I don't understand your request.";
                    }

                   
                    byte[] responseData = Encoding.Unicode.GetBytes(responseMessage);
                    listener.Send(responseData, responseData.Length, remoteEndPoint);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                listener.Close();
            }
        }
    }
}
