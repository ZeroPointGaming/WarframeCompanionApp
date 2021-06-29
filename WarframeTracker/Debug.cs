using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WarframeTracker.Debug
{
    public class Debug
    {
        public void Log(string log_string)
        {
            string log_file = Environment.CurrentDirectory.ToString() + "/data/log.txt";
            if (!File.Exists(log_file))
            {
                FileStream file_creater = File.Create(log_file);
                file_creater.Close();file_creater.Dispose();

                File.AppendAllText(log_file, Environment.NewLine + log_string);
            }
            else
            {
                File.AppendAllText(log_file, Environment.NewLine + log_string);
            }
        }
    }
}
