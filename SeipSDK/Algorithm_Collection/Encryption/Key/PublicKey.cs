using System;

namespace Algorithm_Collection.Encryption.Key
{
    public class PublicKey
    {
        public Guid GUID { get; private set; }
        public long[] KeyValues { get; private set; } 

        public PublicKey(long s, long k)
        {
            GUID = Guid.NewGuid();
            KeyValues = new long[] { s, k };
        }
    }
}
