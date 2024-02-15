using System.Security.Cryptography;
using System.Text;

namespace WatchList.Core.Helpers
{
    public static class Cryptography
    {

        private static readonly RandomNumberGenerator Random = RandomNumberGenerator.Create();

        //Preconfigured Encryption Parameters
        private const int BlockBitSize = 128;
        private const int KeyBitSize = 256;

        //Preconfigured Password Key Derivation Parameters
        private const int SaltBitSize = 64;
        private const int Iterations = 10000;
        private const int MinPasswordLength = 12;

        private static readonly HashAlgorithmName HashAlgorithm = HashAlgorithmName.SHA512;

        public static byte[] NewKey()
        {
            var key = new byte[KeyBitSize / 8];
            Random.GetBytes(key);
            return key;
        }

        public static string HashString(string str, out string salt)
        {
            var saltByteArr = RandomNumberGenerator.GetBytes(BlockBitSize);

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(str),
                saltByteArr,
                Iterations,
                HashAlgorithm,
                KeyBitSize);

            salt = Convert.ToBase64String(saltByteArr);
            return Convert.ToBase64String(hash);
        }

        public static bool VerifyHash(string str, string hash, string salt)
        {
            var saltByteArr = Convert.FromBase64String(salt);

            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(str, saltByteArr, Iterations, HashAlgorithm, KeyBitSize);
            return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromBase64String(hash));
        }


        public static string SimpleEncryptWithPassword(string secretMessage, string password, byte[]? nonSecretPayload = null)
        {
            if (string.IsNullOrEmpty(secretMessage))
            {
                throw new ArgumentException("Secret Message Required!", nameof(secretMessage));
            }

            var plainText = Encoding.UTF8.GetBytes(secretMessage);
            var cipherText = SimpleEncryptWithPassword(plainText, password, nonSecretPayload);
            return Convert.ToBase64String(cipherText);
        }

        public static string SimpleDecryptWithPassword(string encryptedMessage, string password, int nonSecretPayloadLength = 0)
        {
            if (string.IsNullOrWhiteSpace(encryptedMessage))
            {
                throw new ArgumentException("Encrypted Message Required!", nameof(encryptedMessage));
            }

            var cipherText = Convert.FromBase64String(encryptedMessage);
            var plainText = SimpleDecryptWithPassword(cipherText, password, nonSecretPayloadLength);

            if (plainText == null)
            {
                throw new Exception("Unable to decrypt");
            }

            return Encoding.UTF8.GetString(plainText);
        }

        private static byte[] SimpleEncrypt(byte[] secretMessage, byte[] cryptKey, byte[] authKey, byte[]? nonSecretPayload = null)
        {
            //User Error Checks
            if (cryptKey is not {Length: KeyBitSize / 8})
            {
                throw new ArgumentException($"Key needs to be {KeyBitSize} bit!", nameof(cryptKey));
            }

            if (authKey is not { Length: KeyBitSize / 8 })
            {
                throw new ArgumentException($"Key needs to be {KeyBitSize} bit!", nameof(authKey));
            }

            if (secretMessage == null || secretMessage.Length < 1)
            {
                throw new ArgumentException("Secret Message Required!", nameof(secretMessage));
            }

            //non-secret payload optional
            nonSecretPayload ??= new byte[] { };

            byte[] cipherText;

            using var aes = Aes.Create();


            aes.KeySize = KeyBitSize;
            aes.BlockSize = BlockBitSize;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;



            //Use random IV
            aes.GenerateIV();
            var iv = aes.IV;

            using (var encryptor = aes.CreateEncryptor(cryptKey, iv))
            using (var cipherStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(cipherStream, encryptor, CryptoStreamMode.Write))
                using (var binaryWriter = new BinaryWriter(cryptoStream))
                {
                    //Encrypt Data
                    binaryWriter.Write(secretMessage);
                }

                cipherText = cipherStream.ToArray();
            }


            //Assemble encrypted message and add authentication
            using (var hmac = new HMACSHA256(authKey))
            using (var encryptedStream = new MemoryStream())
            {
                using (var binaryWriter = new BinaryWriter(encryptedStream))
                {
                    //Prepend non-secret payload if any
                    binaryWriter.Write(nonSecretPayload);
                    //Prepend IV
                    binaryWriter.Write(iv);
                    //Write CipherText
                    binaryWriter.Write(cipherText);
                    binaryWriter.Flush();

                    //Authenticate all data
                    var tag = hmac.ComputeHash(encryptedStream.ToArray());
                    //append tag
                    binaryWriter.Write(tag);
                }
                return encryptedStream.ToArray();
            }

        }
        private static byte[]? SimpleDecrypt(byte[] encryptedMessage, byte[] cryptKey, byte[] authKey, int nonSecretPayloadLength = 0)
        {

            //Basic Usage Error Checks
            if (cryptKey is not {Length: KeyBitSize / 8})
            {
                throw new ArgumentException($"CryptKey needs to be {KeyBitSize} bit!", nameof(cryptKey));
            }

            if (authKey is not {Length: KeyBitSize / 8})
            {
                throw new ArgumentException($"AuthKey needs to be {KeyBitSize} bit!", nameof(authKey));
            }

            if (encryptedMessage == null || encryptedMessage.Length == 0)
            {
                throw new ArgumentException("Encrypted Message Required!", nameof(encryptedMessage));
            }

            using var hmac = new HMACSHA256(authKey);
            var sentTag = new byte[hmac.HashSize / 8];
            //Calculate Tag
            var calcTag = hmac.ComputeHash(encryptedMessage, 0, encryptedMessage.Length - sentTag.Length);
            var ivLength = BlockBitSize / 8;

            //if message length is to small just return null
            if (encryptedMessage.Length < sentTag.Length + nonSecretPayloadLength + ivLength)
            {
                return null;
            }

            //Grab Sent Tag
            Array.Copy(encryptedMessage, encryptedMessage.Length - sentTag.Length, sentTag, 0, sentTag.Length);

            //Compare Tag with constant time comparison
            var compare = 0;
            for (var i = 0; i < sentTag.Length; i++)
                compare |= sentTag[i] ^ calcTag[i];

            //if message doesn't authenticate return null
            if (compare != 0)
            {
                return null;
            }

            using var aes = Aes.Create();

            aes.KeySize = KeyBitSize;
            aes.BlockSize = BlockBitSize;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            //Grab IV from message
            var iv = new byte[ivLength];
            Array.Copy(encryptedMessage, nonSecretPayloadLength, iv, 0, iv.Length);

            using var decryptor = aes.CreateDecryptor(cryptKey, iv);
            using var plainTextStream = new MemoryStream();
            using (var decryptorStream = new CryptoStream(plainTextStream, decryptor, CryptoStreamMode.Write))
            using (var binaryWriter = new BinaryWriter(decryptorStream))
            {
                //Decrypt Cipher Text from Message
                binaryWriter.Write(
                  encryptedMessage,
                  nonSecretPayloadLength + iv.Length,
                  encryptedMessage.Length - nonSecretPayloadLength - iv.Length - sentTag.Length
                );
            }
            //Return Plain Text
            return plainTextStream.ToArray();
        }

        private static byte[] SimpleEncryptWithPassword(byte[] secretMessage, string password, byte[]? nonSecretPayload = null)
        {
            nonSecretPayload ??= new byte[] { };

            //User Error Checks
            if (string.IsNullOrWhiteSpace(password) || password.Length < MinPasswordLength)
            {
                throw new ArgumentException($"Must have a password of at least {MinPasswordLength} characters!", nameof(password));
            }

            if (secretMessage == null || secretMessage.Length == 0)
            {
                throw new ArgumentException("Secret Message Required!", nameof(secretMessage));
            }

            var payload = new byte[SaltBitSize / 8 * 2 + nonSecretPayload.Length];

            Array.Copy(nonSecretPayload, payload, nonSecretPayload.Length);
            int payloadIndex = nonSecretPayload.Length;

            byte[] cryptKey;
            byte[] authKey;
            //Use Random Salt to prevent pre-generated weak password attacks.
            using (var generator = new Rfc2898DeriveBytes(password, SaltBitSize / 8, Iterations, HashAlgorithm))
            {
                var salt = generator.Salt;

                //Generate Keys
                cryptKey = generator.GetBytes(KeyBitSize / 8);

                //Create Non Secret Payload
                Array.Copy(salt, 0, payload, payloadIndex, salt.Length);
                payloadIndex += salt.Length;
            }

            // Deriving separate key, might be less efficient than using HKDF, 
            // but now compatible with RNEncryptor which had a very similar wireformat and requires less code than HKDF.
            using (var generator = new Rfc2898DeriveBytes(password, SaltBitSize / 8, Iterations, HashAlgorithm))
            {
                var salt = generator.Salt;

                //Generate Keys
                authKey = generator.GetBytes(KeyBitSize / 8);

                //Create Rest of Non Secret Payload
                Array.Copy(salt, 0, payload, payloadIndex, salt.Length);
            }

            return SimpleEncrypt(secretMessage, cryptKey, authKey, payload);
        }

        private static byte[]? SimpleDecryptWithPassword(byte[] encryptedMessage, string password, int nonSecretPayloadLength = 0)
        {
            //User Error Checks
            if (string.IsNullOrWhiteSpace(password) || password.Length < MinPasswordLength)
            {
                throw new ArgumentException($"Must have a password of at least {MinPasswordLength} characters!", nameof(password));
            }

            if (encryptedMessage == null || encryptedMessage.Length == 0)
            {
                throw new ArgumentException("Encrypted Message Required!", nameof(encryptedMessage));
            }

            var cryptSalt = new byte[SaltBitSize / 8];
            var authSalt = new byte[SaltBitSize / 8];

            //Grab Salt from Non-Secret Payload
            Array.Copy(encryptedMessage, nonSecretPayloadLength, cryptSalt, 0, cryptSalt.Length);
            Array.Copy(encryptedMessage, nonSecretPayloadLength + cryptSalt.Length, authSalt, 0, authSalt.Length);

            byte[] cryptKey;
            byte[] authKey;

            //Generate crypt key
            using (var generator = new Rfc2898DeriveBytes(password, cryptSalt, Iterations, HashAlgorithm))
            {
                cryptKey = generator.GetBytes(KeyBitSize / 8);
            }
            //Generate auth key
            using (var generator = new Rfc2898DeriveBytes(password, authSalt, Iterations, HashAlgorithm))
            {
                authKey = generator.GetBytes(KeyBitSize / 8);
            }

            return SimpleDecrypt(encryptedMessage, cryptKey, authKey, cryptSalt.Length + authSalt.Length + nonSecretPayloadLength);
        }
    }
}
