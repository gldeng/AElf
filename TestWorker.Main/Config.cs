using AElf.Kernel.Concurrency.Execution;
using Org.BouncyCastle.Asn1.X509.Qualified;

namespace TestWorker.Main
{
    public class Config
    {
        public static bool IsCluster { get; set; }

        public static string Content { get; set; }

        static Config()
        {
            IsCluster = true;
            Content = 
                @"
                akka {
                    actor {
                        provider = cluster
                        deployment {
                            /tasker {
                                router = tracked-group
                                routees.paths = [""/user/job""]
                                virtual-nodes-factor = 8
                                cluster {
                                    enabled = on
                                    max-nr-of-instances-per-node = 1
                                    allow-local-routees = off
                                    use-role = worker
                                }
                            }
                        }
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
                            port = 0
                        }
                    }
                    cluster {
                        seed-nodes = [""akka.tcp://ClusterSystem@127.0.0.1:2551""]
                        roles = [""manager""]
                    }
                }";
        }
    }
}