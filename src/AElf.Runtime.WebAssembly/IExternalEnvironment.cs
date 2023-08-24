using AElf.Kernel.SmartContract;
using AElf.Types;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;

namespace AElf.Runtime.WebAssembly;

public interface IExternalEnvironment
{
    IHostSmartContractBridgeContext? HostSmartContractBridgeContext { get; set; }
    void SetHostSmartContractBridgeContext(IHostSmartContractBridgeContext smartContractBridgeContext);

    Dictionary<string, ByteString> Writes { get; set; }
    Dictionary<string, bool> Reads { get; set; }
    Dictionary<string, bool> Deletes { get; set; }

    Dictionary<Hash, byte[]> Events { get; }

    void Transfer(Address to, long value);
    WriteOutcome SetStorage(byte[] key, byte[] value, bool takeOld);
    Task<byte[]?> GetStorageAsync(byte[] key);
    Task<int> GetStorageSizeAsync(byte[] key);
    Address Caller();
    bool IsContract();
    Hash CodeHash(Address address);
    Hash OwnCodeHash();

    bool CallerIsOrigin();

    // TODO: -> Caller is zero contract or system contract.
    bool CallerIsRoot();

    /// <summary>
    /// Returns a reference to the account id of the current contract.
    /// </summary>
    /// <returns></returns>
    Address GetAddress();

    /// <summary>
    /// Returns the balance of the current contract.
    /// </summary>
    /// <returns></returns>
    long Balance();

    /// <summary>
    /// Returns the value transferred along with this call.
    /// </summary>
    /// <returns></returns>
    long ValueTransferred();

    Timestamp Now();

    /// <summary>
    /// Returns the minimum balance that is required for creating an account.
    /// </summary>
    /// <returns></returns>
    long MinimumBalance();

    byte[] Random(byte[] subject);

    /// <summary>
    /// Deposit an event with the given topics.
    /// <br/>
    /// There should not be any duplicates in `topics`.
    /// </summary>
    /// <param name="topics"></param>
    /// <param name="data"></param>
    void DepositEvent(byte[] topics, byte[] data);

    /// <summary>
    /// Returns the current block number.
    /// </summary>
    /// <returns></returns>
    long BlockNumber();

    /// <summary>
    /// Returns the maximum allowed size of a storage item.
    /// </summary>
    /// <returns></returns>
    int MaxValueSize();

    // 	fn get_weight_price(&self, weight: Weight) -> BalanceOf<Self::T>;
    // 	fn schedule(&self) -> &Schedule<Self::T>;
    // 	fn gas_meter(&self) -> &GasMeter<Self::T>;
    // 	fn gas_meter_mut(&mut self) -> &mut GasMeter<Self::T>;

    /// <summary>
    /// Append a string to the debug buffer.
    /// <br/>
    /// It is added as-is without any additional new line.
    /// <br/>
    /// This is a no-op if debug message recording is disabled which is always the case
    /// when the code is executing on-chain.
    /// </summary>
    /// <param name="message"></param>
    /// <returns>Returns `true` if debug message recording is enabled. Otherwise `false` is returned.</returns>
    bool AppendDebugBuffer(string message);

    // 	fn call_runtime(&self, call: <Self::T as Config>::RuntimeCall) -> DispatchResultWithPostInfo;
    // 	fn ecdsa_recover(&self, signature: &[u8; 65], message_hash: &[u8; 32]) -> Result<[u8; 33], ()>;
    // 	fn sr25519_verify(&self, signature: &[u8; 64], message: &[u8], pub_key: &[u8; 32]) -> bool;
    // 	fn ecdsa_to_eth_address(&self, pk: &[u8; 33]) -> Result<[u8; 20], ()>;
    Address EcdsaToEthAddress(byte[] pk);
    
    // 	fn contract_info(&mut self) -> &mut ContractInfo<Self::T>;

    void SetCodeHash(Hash hash);

    int ReentranceCount();
    int AccountReentranceCount(Address accountAddress);

    long Nonce();
}