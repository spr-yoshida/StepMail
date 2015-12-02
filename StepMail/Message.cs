using Codeplex.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepMail
{
    class Message
    {
        private static readonly string messageFile = "message.json";

        public Message()
        {
            var fileName = messageFile;
            //ディレクトリ
            var currentDir = Directory.GetCurrentDirectory();
            var filePath = Path.Combine(currentDir, fileName);

            var val = new List<string>();
            //メッセージ読み込み
            using (StreamReader sr = new StreamReader(filePath, Encoding.GetEncoding("shift_jis")))
            {
                var data = sr.ReadToEnd();
                var json = DynamicJson.Parse(data);

                foreach (var item in json)
                {
                    val.Add(item);
                }
            }

            Messages = val;
        }

        public List<string> Messages { get; private set; }

        public static void SaveFile()
        {
            var messages = new List<string>();
            messages.Add("Test01");
            messages.Add("Test02");
            messages.Add("Test03");

            var jsonStringFromMessage = DynamicJson.Serialize(messages);

            //ディレクトリ
            var currentDir = Directory.GetCurrentDirectory();

            //ファイル名
            var fileName = messageFile;
            var fullPath = Path.Combine(currentDir, fileName);

            using (StreamWriter sw = new StreamWriter(fullPath, false, Encoding.GetEncoding("shift_jis")))
            {
                sw.Write(jsonStringFromMessage);
            }
        }
    }

}
