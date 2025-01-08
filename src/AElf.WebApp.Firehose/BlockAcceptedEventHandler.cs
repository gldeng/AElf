using AElf.Kernel;
using AElf.Kernel.Blockchain.Application;
using AElf.Kernel.Blockchain.Events;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus;
using Google.Protobuf; // Ensure you have this using directive for protobuf serialization

namespace AElf.WebApp.Firehose;

public class BlockAcceptedEventHandler : ILocalEventHandler<BlockAcceptedEvent>, ILocalEventHandler<BlockAttachedEvent>,
    ITransientDependency
{
    private BlockAcceptedEvent? _acceptedEvent = null;
    private readonly IBlockchainService _blockchainService;

    public BlockAcceptedEventHandler(IBlockchainService blockchainService)
    {
        _blockchainService = blockchainService;
        Console.WriteLine($"FIRE INIT 3.0 {Block.Descriptor.FullName}");
    }

    public Task HandleEventAsync(BlockAcceptedEvent? eventData)
    {
        _acceptedEvent = eventData;
        return Task.CompletedTask;
    }

    public async Task HandleEventAsync(BlockAttachedEvent eventData)
    {
        if (_acceptedEvent == null)
        {
            Console.WriteLine("FIRE EXCEPTION NO_ACCEPTED_EVENT");
            return;
        }

        if (
            // ReSharper disable once ComplexConditionExpression
            _acceptedEvent.Block.Header.Height != eventData.Height ||
            _acceptedEvent.Block.Header.GetHash() != eventData.Hash
        )
        {
            _acceptedEvent = null;
            Console.WriteLine("FIRE EXCEPTION DISCREPANCY");
            return;
        }

        var blockPayloadBase64 = Convert.ToBase64String(_acceptedEvent.Block.ToByteArray());

        // Convert DateTime to Unix time in nanoseconds
        var unixTimeNanos = (
            _acceptedEvent.Block.Header.Time.ToDateTime() -
            new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
        ).TotalNanoseconds;
        var chain = await _blockchainService.GetChainAsync();

        var blockLine = string.Format(
            "FIRE BLOCK {0} {1} {2} {3} {4} {5} {6}",
            _acceptedEvent.Block.Height,
            _acceptedEvent.Block.GetHash().ToHex(),
            _acceptedEvent.Block.Height - 1,
            _acceptedEvent.Block.Header.PreviousBlockHash.ToHex(),
            chain.LastIrreversibleBlockHeight,
            (long)unixTimeNanos, // Cast to long for formatting
            blockPayloadBase64
        );
        Console.WriteLine(blockLine);
    }
}