using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Collection.Encryption.Key
{
    public class PrivateKey
    {
        public Guid GUID { get; private set; }
        public long[] KeyValues { get; private set; }

        public PrivateKey(long t, long k)
        {
            GUID      = Guid.NewGuid();
            KeyValues = new long[] { t, k };
        }
    }
}
