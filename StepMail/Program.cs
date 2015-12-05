using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: CLSCompliant(true)]
namespace StepMail
{
    class Program
    {
        private const string MESSAGE_DIR = "subDir";
        private const string MEMBER_FILE = "members.json";

        static void Main(string[] args)
        {
            Console.WriteLine("---- 処理開始 ----");

            //ディレクトリ
            var currentDir = Directory.GetCurrentDirectory();
            var messageFilePath = Path.Combine(currentDir, MESSAGE_DIR);

            //メッセージの読み込み
            var message = new Message();
            message.Read(messageFilePath);

            
            var mailList = new List<IMail>();
            //メンバー情報
            var members = new Members();
            var memberFilePath = Path.Combine(currentDir, MEMBER_FILE);
            //HACK:メンバーファイルを初期化したいときに使用する
            Members.Initailze(memberFilePath);
            //メンバーファイル読み込み
            members.Read(memberFilePath);

            var activeUsers = members.GetActiveUsers(message.Messages.Count());

            foreach (var user in activeUsers)
            {
                var index = user.Count - 1;
                var selectMessage = message.Messages[index];

                mailList.Add(Mail.CreateMail(user.Mail, string.Empty, user.Count, selectMessage));
            }
            foreach (var mail in mailList)
            {
                mail.Send();
            }

            
            members.CountUp();
            //メンバーファイルの更新
            var val = members.Serialize();
            Members.Save(memberFilePath, val);

            //終了
            Console.WriteLine("---- 処理終了 ----");
            Console.ReadKey();

        }
    }
}
