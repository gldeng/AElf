using System;
using Akka.Actor;
using Akka.Configuration;
using AElf.Kernel.Concurrency.Execution;

namespace TestWorker.Worker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("I am worker!");

            var config = ConfigurationFactory.ParseString(Config.Content);
            
            config = ConfigurationFactory.ParseString($@"akka.actor.router.type-mapping.tracked-group=""{typeof(TrackedGroup).AssemblyQualifiedName}""").WithFallback(config);
            
            if (args.Length == 1)
            {
                config = ConfigurationFactory.ParseString("akka.remote.dot-netty.tcp.port=" + args[0]).WithFallback(config);
            }
                
            var system = ActorSystem.Create("ClusterSystem", config);

            var worker = system.ActorOf(Props.Create<AElf.Kernel.Concurrency.Execution.Worker>(), "job");
//            Console.WriteLine(worker.Path.Uid);
            
            Console.ReadKey();
        }
    }
}