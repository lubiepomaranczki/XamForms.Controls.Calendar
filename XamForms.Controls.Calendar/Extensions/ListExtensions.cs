using System.Collections.Generic;
using System.Linq;

namespace XamForms.Controls
{
    internal static class ListExtensions
    {
        internal static bool IsNullOrEmpty<T>(this IEnumerable<T> list)
        {
            return list != null && list.Any();
        }
    }
}
