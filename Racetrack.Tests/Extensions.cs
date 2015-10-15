using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racetrack
{
    internal static class Extensions
    {
        public static string MakeString<T>(this IEnumerable<T> array)
        {
            return string.Join(", ", array) + "\r\n";
        }
    }
}
