using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Common.Utilities;

namespace Thermon.Computrace.Web.Common.Extensions
{
    public static class StringExtensions
    {
        public static string ToAESEncryption(this string stringvalue)
        {
            return Cryptography.EncryptString(stringvalue);
        }

        public static string ToAESDecryption(this string stringvalue)
        {
            return Cryptography.DecryptString(stringvalue);
        }
    }
}
