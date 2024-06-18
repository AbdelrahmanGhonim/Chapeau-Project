using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ChapeauService
{
    public class ActivityLogger
    {
        private string filename = "ActivityLog.txt";

        public void Log(string message, string level = "INFO")
        {
            using (StreamWriter writer = new StreamWriter(filename, true))
            {
                writer.WriteLine($"{DateTime.Now:dd/MM/yyyy HH:mm:ss} [{level}] - {message}");
            }
        }
    }
}
