using System;
using System.Threading;
using Telepathy;

namespace ServerLes;

public static class Program
{

    static Server server;

    public static void Main()
    {
        server = new Server(1024);

        server.OnConnected = (connID, msg) => {
            Console.WriteLine($"Client connected: {connID}");
        };

        server.OnData = (connID, msg) => {
            Console.WriteLine($"Received data from {connID}: {msg}");
            // Echo the message back to the client
            server.Send(connID, msg);
        };

        server.Start(5366);
        Console.WriteLine("开始运行服务器...");

        while(true) {
            server.Tick(100);

            Thread.Sleep(10); // 间隔不准确
        }
    }

}