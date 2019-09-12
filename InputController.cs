using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class InputController
{
    public float CurrentValue;

   
    float _minInputY = 0f;
    float _maxInputY = 30;

    string ipaddress = "192.168.43.238";
    float _minFinalY = -4f;
    float _maxFinalY = 4;

    public void Begin(string ipAddress, int port)
    {
        var thread = new Thread(() =>
        {
            

          
            var client = new TcpClient();

            
            client.Connect(ipAddress, port);
            var stream = new StreamReader(client.GetStream());

            
            var buffer = new List<byte>();
            while (client.Connected)
            {
               
                var read = stream.Read();

                
                if (read == 13)
                {
                    
                    var str = Encoding.ASCII.GetString(buffer.ToArray());

                    
                    var dist = float.Parse(str);

                    dist = Mathf.Clamp(dist, _minInputY, _maxInputY);

                    

                    

                    buffer.Clear();
                }
                else
                    buffer.Add((byte)read);
            }
        });

        thread.Start();
    }
}