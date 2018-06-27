using System;
using AElf.Kernel.Concurrency.Execution.Messages;
using Akka.Actor;

namespace TestWorker.Main
{
    public class Receiver: UntypedActor
    {
        protected override void OnReceive(object message)
        {
            switch (message)
            {
                case DummyMessage m:
                    Console.WriteLine(m.Message);
                    break;
            }
        }
    }
}