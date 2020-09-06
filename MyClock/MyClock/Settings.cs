using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyClock
{
    public class Settings
    {
        static readonly string PATH = "settings.txt";

        public string DefaultTime { get; set; } = "00/00/00";

        public Settings()
        {
            try
            {
                var data = new List<string>();
                using (var sr = new StreamReader(PATH))
                {
                    string text;
                    while ((text = sr.ReadLine()) != null)
                    {
                        data.Add(text);
                    }
                }
                this.DefaultTime = data[0];
            }
            catch
            {
                
            }
        }

        public void CloseAction()
        {
            using (var sw = new StreamWriter(PATH))
            {
                sw.WriteLine(this.DefaultTime);
            }
        }
    }
}
