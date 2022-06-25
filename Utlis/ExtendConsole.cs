using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyChair2.Utlis
{
    internal static class ExtendConsole
    {
        private class StringBatya
        {
            private string value;

            public static explicit operator StringBatya(string value) =>
                new StringBatya { value = value };

            public static implicit operator String(StringBatya value) =>
                value.value;

            public override string ToString() => value;

            public static StringBatya operator *(StringBatya value, int count)
            {
                var sb = new StringBuilder(count < 1 ? "" : value);
                while (count > 1)
                {
                    sb.Append(value);
                    count--;
                }
                return (StringBatya)sb.ToString();
            }
        }

        internal static string Input(string msg)
        {
            Console.Write($"[{msg}]:  ");
            return Console.ReadLine();
        }

        internal static string InputPassword(string msg)
        {
            Console.Write($"[{msg}]:  ");
            var symbols = new List<char>();
            while (0 == 0)
            {
                var k = Console.ReadKey();
                if (k.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    var result = new StringBuilder();
                    for (int i = 0; i < symbols.Count; i++)
                        result.Append(symbols[i]);
                    return result.ToString();
                }
                else if (symbols.Count > 0 && k.Key == ConsoleKey.Backspace)
                    symbols.RemoveAt(symbols.Count - 1);
                else if (k.Key != ConsoleKey.Backspace)
                    symbols.Add(k.KeyChar);
                Console.Write($"\r[{msg}]:  {((StringBatya)"*") * symbols.Count} ");
            }
        }


    }
}
