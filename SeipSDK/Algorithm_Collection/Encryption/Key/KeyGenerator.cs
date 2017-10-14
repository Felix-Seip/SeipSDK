using System;
using System.Numerics;
using System.Text;

namespace Algorithm_Collection.Encryption.Key
{
    public class KeyGenerator
    {
        private long _maxPrimeValue;
        private Random _randomGen;
        public KeyGenerator()
        { }

        public KeyPair GenerateNewKeyPair(string password)
        {
            byte[] pass = Encoding.ASCII.GetBytes(password);
            for (int i = 0; i < pass.Length; i++)
            {
                _maxPrimeValue += pass[i];
            }

            _randomGen = new Random();

            _maxPrimeValue /= 10;

            return CalculateKeyPairValues(password);
        }

        private KeyPair CalculateKeyPairValues(string password)
        {
            long p = 1;
            long q = 1;
            GeneratePrimeSeed(ref p, ref q);

            long n = p * q;
            long totient = (p - 1) * (q - 1);
            long e = 2;
            while (!AreCoprimes(totient, e) && e < totient)
            {
                e = _randomGen.Next(1, (int)totient);
            }

            long d = 0;
            d = CalculateD(e, totient);
            return new KeyPair(new PrivateKey(d, n), new PublicKey(e, n), password);
        }

        private void GeneratePrimeSeed(ref long p, ref long q)
        {
            while (!IsPrimeNubmer(p) || !IsPrimeNubmer(q))
            {
                p = _randomGen.Next(1, (int)_maxPrimeValue);
                q = _randomGen.Next(1, (int)_maxPrimeValue);
            }
        }

        private long CalculateD(long e, long totient)
        {
            e = e % totient;
            for (long t = 1; t < totient; t++)
            {
                if ((e * t) % totient == 1)
                {
                    return t;
                }
            }
            return 0;
        }

        private bool IsPrimeNubmer(long n)
        {
            if (n == 1) return false;
            if (n == 2) return true;

            var boundary = (int)Math.Floor(Math.Sqrt(n));

            for (int i = 2; i <= boundary; ++i)
            {
                if (n % i == 0) return false;
            }

            return true;
        }

        private bool AreCoprimes(long a, long b)
        {
            return BigInteger.GreatestCommonDivisor(a, b) == 1;
        }
    }
}
