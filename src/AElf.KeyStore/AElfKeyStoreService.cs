using AElf.Cryptography;
using AElf.Cryptography.Exceptions;
using AElf.Types;
using Nethereum.KeyStore;

namespace AElf.KeyStore
{
    public class AElfKeyStoreService : KeyStoreService
    {
        public string EncryptKeyStoreAsJson(string password, string privateKey)
        {
            var keyPair = CryptoHelper.FromPrivateKey(ByteArrayHelper.HexStringToByteArray(privateKey));
            if (keyPair?.PrivateKey == null || keyPair.PublicKey == null)
                throw new InvalidKeyPairException("Invalid keypair (null reference).", null);

            var address = Address.FromPublicKey(keyPair.PublicKey);
            return EncryptAndGenerateDefaultKeyStoreAsJson(password, keyPair.PrivateKey, address.ToBase58());
        }
    }
}