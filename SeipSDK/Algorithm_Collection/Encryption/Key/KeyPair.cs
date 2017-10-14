using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Collection.Encryption.Key
{
    public class KeyPair
    {
        public PrivateKey PrivateKey { get; private set; }
        public PublicKey PublicKey { get; private set; }

        private string _password;

        public KeyPair(PrivateKey privateKey, PublicKey publicKey, string password)
        {
            PrivateKey = privateKey;
            PublicKey  = publicKey;
            _password = password;
        }

        public string Encrypt(PublicKey publicKey)
        {
            return "";
        }

        public string Decrypt()
        {
            return "";
        }
    }
}
