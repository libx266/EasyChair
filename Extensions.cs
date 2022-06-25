using EasyChair2.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EasyChair2
{
    internal static class Extensions
    {
        const string numbers = "0123456789.-";
        internal static decimal ToDecimal(this string value, int entry = 0)
        {
            value += "q";
            var result = new StringBuilder();
            var answer = new List<Decimal>(entry + 1);
            foreach (char c in value)
            {
                if (numbers.Contains(c))
                    result.Append(c);
                else if (result.Length > 0)
                {
                    answer.Add(Decimal.TryParse(result.ToString(), out decimal r) ? r : 0);
                    result.Clear();
                }
            }
            return answer[entry];
        }

        internal static IEnumerable<T> ForEach<T>(this IEnumerable<T> data, Action<T> action)
        {
            foreach (var item in data)
                action(item);
            return data;
        }

        internal static HashSet<T> Cache<T>(this HashSet<T> data) where T : BaseEntity
        {
            data.ForEach(e => e.Cache());
            return data;
        }

        internal static T? Get<T>(this object sender) where T : BaseEntity =>
            (sender as FrameworkElement)?.DataContext as T;
    }
}
