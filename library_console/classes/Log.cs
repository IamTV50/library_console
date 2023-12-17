using System;
using System.IO;

namespace library_console.classes {
    public class Log {
        public static void writeLog(string message, string dateTime) {
            try {
                using (StreamWriter writer = File.AppendText("library.log")) {
                    writer.WriteLine($"{message} {dateTime}");
                }
            }
            catch (Exception ex) {
                Console.WriteLine($"error writing to log: {ex.Message}");
            }
        }
    }
}
