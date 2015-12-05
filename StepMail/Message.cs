using Codeplex.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepMail
{
    public class Message
    {

        public IList<string> Messages { get; private set; }

        public void Read(string filePath)
        {

            var files = Directory.GetFiles(filePath, "*.txt", SearchOption.TopDirectoryOnly);
            //ソート
            var sortFiles = files.OrderBy(s => s);

            //読み込み
            var txtList = new List<string>();
            foreach (var file in sortFiles)
            {
                using (StreamReader sr = new StreamReader(file, Encoding.GetEncoding("shift_jis")))
                {
                    var body = sr.ReadToEnd();
                    txtList.Add(body);
                }
            }

            foreach (var txt in txtList)
            {
                Console.WriteLine("---- body ----");
                Console.WriteLine(txt);
            }

            Messages = txtList;
        }
    }

}
