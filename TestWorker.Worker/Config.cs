using System;
using AElf.Kernel.Concurrency.Execution;

namespace TestWorker.Worker
{
    public class Config
    {

        private static Type _groupType = typeof(TrackedGroup);
        
        public static string Content { get; set; }

        static Config()
        {
            Content = @"
                akka {
                    actor {
                        provider = cluster
                        debug {  
                          receive = on 
                          autoreceive = on
                          lifecycle = on
                          event-stream = on
                          unhandled = on
                        }
                    }
                    remote {
                        dot-netty.tcp {
                            hostname = ""127.0.0.1""
                            port = 2551
                        }
                    }
                    cluster {
                        seed-nodes = [""akka.tcp://ClusterSystem@127.0.0.1:2551""]
                        roles = [""worker""]
                    }
                }";
        } 
    }
}