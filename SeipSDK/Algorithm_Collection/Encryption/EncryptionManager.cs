using Algorithm_Collection.Encryption.Key;
using System.Numerics;
using System.Text;

namespace Algorithm_Collection.Encryption
{
    public class EncryptionManager
    {
        private static EncryptionManager _instance;
		/// <summary>
		/// Singelton Instance of EncryptionManager
		/// </summary>
		public static EncryptionManager Instance
		{
			get
			{
				if (_instance == null)
					_instance = new EncryptionManager();

				return _instance;
			}

			private set { }
		}

        private static KeyGenerator _keyGenerator;

        private EncryptionManager()
        {
			_keyGenerator = new KeyGenerator();
		}
		
        public KeyPair GenerateKeyPair(string password)
        {
            return _keyGenerator.GenerateNewKeyPair(password);
        }

        public BigInteger Encrypt(long message, PublicKey key)
        {
            return BigInteger.Pow(message, (int)key.KeyValues[0]) % key.KeyValues[1];
        }

        public BigInteger Decrypt(BigInteger encMessage, PrivateKey key)
        {
            return BigInteger.Pow(encMessage, (int)key.KeyValues[0]) % key.KeyValues[1];
        }

        public string EncryptStringMessage(string message, PublicKey key)
        {
            char[] charMessage = message.ToCharArray();
            
            for(int i = 0; i < charMessage.Length; i++)
            {
                charMessage[i] = (char)Encrypt(charMessage[i], key);
            }

            return Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(charMessage));
        }

        public string DecryptStringMessage(string message, PrivateKey key)
        {
            char[] charMessage = message.ToCharArray();

            for (int i = 0; i < charMessage.Length; i++)
            {
                charMessage[i] = (char)Decrypt(charMessage[i], key);
            }
            return Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(charMessage));
        }
    }
}
