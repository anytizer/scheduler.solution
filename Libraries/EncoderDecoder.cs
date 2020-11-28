using System;
using System.Text;

namespace libraries
{
    public class EncoderDecoder
    {
        // https://stackoverflow.com/questions/11743160/how-do-i-encode-and-decode-a-base64-string
        public string encode(string raw)
        {
            byte[] data = Encoding.UTF8.GetBytes(raw);
            string encoded = Convert.ToBase64String(data);
            return encoded;
        }

        public string decode(string encoded)
        {
            byte[] data = Convert.FromBase64String(encoded);
            string decoded = Encoding.ASCII.GetString(data);
            return decoded;
        }
    }
}
