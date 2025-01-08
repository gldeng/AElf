namespace AElf.Kernel.Blockchain.Events;

public class BlockAttachedEvent
{
    public long Height { get; set; }
    public Hash Hash { get; set; }
}