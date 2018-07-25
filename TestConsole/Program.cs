﻿using System;
using System.Net;
using System.Threading.Tasks;
using StackExchange.Redis.Server;

static class Program
{
    static async Task Main()
    {
        //using (var pool = new DedicatedThreadPoolPipeScheduler(minWorkers: 10, maxWorkers: 10,
        //    priority: System.Threading.ThreadPriority.Highest))
        using (var resp = new MemoryCacheRedisServer(Console.Out))
        using (var socket = new RespSocketServer(resp))
        {
            //var options = new PipeOptions(readerScheduler: pool, writerScheduler: pool, useSynchronizationContext: false);
            socket.Listen(new IPEndPoint(IPAddress.Loopback, 6378)
                //, sendOptions: options, receiveOptions: options
            );
            await resp.Shutdown;
        }
    }
}
