using System;
using System.Collections.Generic;
using System.Threading;
using Akka.Actor;
using Akka.Configuration;
using Akka.Routing;
using AElf.Kernel.Concurrency;
using AElf.Kernel.Concurrency.Execution;
using AElf.Kernel.Concurrency.Execution.Messages;

namespace TestWorker.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = ConfigurationFactory.ParseString(Config.Content);

            config = ConfigurationFactory.ParseString($@"akka.actor.router.type-mapping.tracked-group=""{typeof(TrackedGroup).AssemblyQualifiedName}""").WithFallback(config);

            var system = ActorSystem.Create("ClusterSystem",config);
            var router = system.ActorOf(Props.Empty.WithRouter(FromConfig.Instance), "tasker");
            var receiver = system.ActorOf(Props.Create<Receiver>(), "receiver");
            
            while (true)
            {
                router.Tell(new DummyMessage("Hi there"), receiver);
//                system.ActorSelection("/user/job2").Tell(new DummyMessage("==============================good huh=========================="));
                Thread.Sleep(1000);
            }

//            system.ActorSelection("/user/*");
        }
    }
}