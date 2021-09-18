using System;
using System.IO;
using System.Text;

namespace parsing_api.Classes
{
    /// <summary>
    /// Класс - логгер. Паттерн одиночка. Пишет инфо и ошибки в файлы в папку Log
    /// </summary>
    public sealed class Log
    {
        private static volatile Log _instance;
        private static readonly object SyncRoot = new object();
        private readonly object _logLocker = new object();

        private Log()
        {
            CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            LogDirectory = Path.Combine(CurrentDirectory, "log");
        }

        /// <summary>
        /// Директория где выполняется приложение
        /// </summary>
        private string CurrentDirectory { get; set; }

        /// <summary>
        /// Директория для записи логов
        /// </summary>
        private string LogDirectory { get; set; }

        /// <summary>
        /// Реализация Одиночки
        /// </summary>
        public static Log Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null) _instance = new Log();
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// Публичный метод для записи ошибок
        /// </summary>
        /// <param name="errorNumber"></param>
        /// <param name="errorText"></param>
        public void Error(int errorNumber, string errorText)
        {
            // Ошибки пишем в лог всегда
            Add($"Ошибка {(errorNumber.ToString()).PadLeft(4, '0')}: {errorText}", "[ERROR]");
        }

        /// <summary>
        /// Публичный метод для записи дебаг информации
        /// </summary>
        /// <param name="log"></param>
        public void Info(string log)
        {
            Add(log, "[INFO]");
        }

        /// <summary>
        /// Запись собранной информации в файл
        /// </summary>
        /// <param name="log"></param>
        /// <param name="logLevel"></param>
        private void Add(string log, string logLevel)
        {
            lock (_logLocker)
            {
                try
                {
                    if (!Directory.Exists(LogDirectory))
                    {
                        // Создание директории log в случае отсутствия
                        Directory.CreateDirectory(LogDirectory);
                    }
                    // Запись в лог файл вместе с датой и уровнем лога.
                    string newFileName = Path.Combine(LogDirectory, String.Format("{0}.txt", DateTime.Now.ToString("yyyyMMdd")));
                    File.AppendAllText(newFileName, $"{DateTime.Now} {logLevel} {log} \r\n", Encoding.UTF8);
                }
                catch { }
            }
        }
    }
}
