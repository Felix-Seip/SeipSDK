using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Collection.Encryption.Key
{
    public class KeyRing
    {
        public List<PublicKey> PublicKeys { get; private set; }

        public bool AddPublicKey(PublicKey publicKey)
        {
            if(!IsKeyInKeyRing(publicKey))
            {
                PublicKeys.Add(publicKey);
                return true;
            }
            return false;
        }

        public bool RemovePublicKey(PublicKey publicKey)
        {
            if(IsKeyInKeyRing(publicKey))
            {
                PublicKeys.Remove(publicKey);
                return true;
            }
            return false;
        }

        private bool IsKeyInKeyRing(PublicKey publicKey)
        {
            for(int i = 0; i < PublicKeys.Count; i++)
            {
                if(PublicKeys[i].GUID == publicKey.GUID)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
