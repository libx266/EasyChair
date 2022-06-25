using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EasyChair2
{
    public static class Log
    {
        /// <summary>
        /// Сохраняет информацию об ошибке в файл
        /// </summary>
        /// <param name="ex">Ошибка</param>
        /// <param name="from">Адрес ошибки</param>
        private static void SaveIntoFile(Exception ex, string from = "")
        {
            try
            {
                string date = DateTime.Now.ToString();
                string info = $"[[{from}]|[{date}]]:\n";

                string message = ex.InnerException == null ?
                    ex.Message : ex.InnerException.Message;

                File.AppendAllText
                (
                    "./log.txt", info
                    + message + "\n\n"
                );
            }
            catch { File.Create("./log.txt"); SaveIntoFile(ex, from); }
        }

        private static string From(string file, int row) => $"{file}:  {row}";

        /// <summary>
        /// Уведомляет пользователя об ошибке через графический интерфейс
        /// </summary>
        /// <param name="ex">Ошибка</param>
        /// <param name="file">Исходный файл, в котором произошал ошибка</param>
        /// <param name="row">Номер строки в файле</param>
        /// <returns>False</returns>
        public static bool Error(this Exception ex, [CallerFilePath] string file = "", [CallerLineNumber] int row = 0)
        {
            string from = From(file, row);
            MessageBox.Show(ex.Message, "Error!",
                MessageBoxButton.OK, MessageBoxImage.Error);

            SaveIntoFile(ex, from); return false;
        }

        public static bool Error(this string message)
        {
            MessageBox.Show(message, "Error!",
               MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }


        /// <summary>
        /// Уведомляет пользователя об ошибке через консоль
        /// </summary>
        /// <param name="ex">Ошибка</param>
        /// <param name="file">Исходный файл, в котором произошла ошибка</param>
        /// <param name="row">Номер строки в файле</param>
        /// <returns>False</returns>
        public static bool ErrorCli(this Exception ex, [CallerFilePath] string file = "", [CallerLineNumber] int row = 0)
        {
            string from = From(file, row);
            SaveIntoFile(ex, from);
            Console.WriteLine($"[{from}]:  {ex.Message}");
            return false;
        }

        /// <summary>
        /// Запрашивает реакцию пользователя
        /// </summary>
        /// <param name="ex">Текст сообщения</param>
        /// <returns>Ответ пользователя</returns>
        public static bool Warning(this Exception ex) => Warning(ex.Message);

        public static bool Warning(this string message)
        {
            return
            MessageBox.Show(message, "Warning",
                MessageBoxButton.YesNo, MessageBoxImage.Warning)
             == MessageBoxResult.Yes;
        }

        /// <summary>
        /// Уведомляет пользователя
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <returns>True</returns>
        public static bool Info(this string message)
        {
            MessageBox.Show(message, "Info",
                MessageBoxButton.OK, MessageBoxImage.Information);
            return true;
        }
    }
}
