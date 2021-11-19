using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TOTPAuthenticator
{
    internal static class Base32
    {
        public const string Base32Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";
        private static readonly Regex _b32re = new Regex("[^" + Base32Alphabet + "]", RegexOptions.Compiled);
        private static readonly Dictionary<char, byte> _base32lookup = Base32Alphabet.Select((c, i) => new { c, i }).ToDictionary(v => v.c, v => (byte)v.i);

        public static byte[] Decode(string value)
        {
            // Have anything to decode?
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            // Remove padding
            value = value.TrimEnd('=');

            // Quick-exit if nothing to decode
            if (string.IsNullOrEmpty(value))
                return Array.Empty<byte>();

            // Make sure string contains only chars from Base32 "alphabet"
            if (_b32re.IsMatch(value))
#pragma warning disable CA1303 // Do not pass literals as localized parameters
                throw new ArgumentException("Invalid base32 string", nameof(value));
#pragma warning restore CA1303 // Do not pass literals as localized parameters

            // Decode Base32 value (not world's most efficient or beatiful code but it gets the job done.
            var bits = string.Concat(value.Select(c => Convert.ToString(_base32lookup[c], 2).PadLeft(5, '0')));
            return Enumerable.Range(0, bits.Length / 8).Select(i => Convert.ToByte(bits.Substring(i * 8, 8), 2)).ToArray();
        }
    }
}
