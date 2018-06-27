namespace AElf.Kernel.Concurrency.Execution.Messages
{
    public sealed class DummyMessage
    {
        public DummyMessage(string msg)
        {
            Message = msg;
        }

        public string Message { get; }
    }
}