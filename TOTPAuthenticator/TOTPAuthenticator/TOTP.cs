using System.Security.Cryptography;

namespace TOTPAuthenticator
{
    public enum Algorithm
    {
        SHA1,
        SHA256,
        SHA512,
        MD5
    }

    public class TOTP
    {
        private Algorithm Algorithm { get; set; }
        private int Digits { get; set; }
        public TOTP(Algorithm algorithm = Algorithm.SHA1, int digits = 6)
        {
            Algorithm = algorithm;
            Digits = digits;
        }

        public string GetCode(string secret)
        {
            using (var algo = (KeyedHashAlgorithm)CryptoConfig.CreateFromName("HMAC" + Enum.GetName(typeof(Algorithm), Algorithm)))
            {
                algo.Key = Base32.Decode(secret);
                var ts = BitConverter.GetBytes(TimeProvider.GetTimeSlice());
                var hashhmac = algo.ComputeHash(new byte[] { 0, 0, 0, 0, ts[3], ts[2], ts[1], ts[0] });
                var offset = hashhmac[hashhmac.Length - 1] & 0x0F;
                return $@"{((
                    hashhmac[offset + 0] << 24 |
                    hashhmac[offset + 1] << 16 |
                    hashhmac[offset + 2] << 8 |
                    hashhmac[offset + 3]
                ) & 0x7FFFFFFF) % (long)Math.Pow(10, Digits)}".PadLeft(Digits, '0');
            }
        }
    }
}
