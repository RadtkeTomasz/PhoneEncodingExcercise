using Newtonsoft.Json.Linq;
using System.Text;
using WebApplication1.Models;

namespace WebApplication1.Models.Helpers
{
    public static class PhoneEncoder
    {
        private static readonly Dictionary<char, string> _phoneKeyboardMappings = new Dictionary<char, string>()
        {
            { 'a', "2"},
            { 'b', "22"},
            { 'c', "222" },
            { 'd', "3" },
            { 'e', "33" },
            { 'f', "333" },
            { 'g',"4" },
            { 'h', "44" },
            { 'i', "444" },
            { 'j', "5" },
            { 'k', "55" },
            { 'l', "555" },
            { 'm', "6"},
            { 'n', "66" },
            { 'o', "666" },
            { 'p', "7" },
            { 'q', "77" },
            { 'r', "777" },
            { 's', "7777" },
            { 't', "8" },
            { 'u', "88" },
            { 'v', "888" },
            { 'w', "9" },
            { 'x', "99" },
            { 'y', "999" },
            { 'z', "9999" },
        };
        public static InputString EncodeStringToPhoneInput(InputString input)
        {
            var sb = new StringBuilder();
            var inputLetters = input.Text.ToLower().ToArray();

            foreach (var letter in inputLetters)
            {
                if (_phoneKeyboardMappings.TryGetValue(letter, out string value))
                {
                    sb.Append('[').Append(value).Append(']');
                }
                else
                {
                    sb.Append('#');
                }
            }
            var result = sb.ToString();
            var encodedString = new InputString();
            encodedString.Text = result;
            return encodedString;
        }
       
    }
}
