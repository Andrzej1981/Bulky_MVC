using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bulky.Utility.Extensions
{
    public static class StringExtensions
    {
        public static string StripHtmL(this string input)
        {
            return Regex.Replace(input,"<.*?>",string.Empty);
        }
    }
}
