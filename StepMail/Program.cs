using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepMail
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---- 処理開始 ----");
            //メッセージファイル作成
            Message.SaveFile();
            var message = new Message();

            var members = new Members(message);

            //HACK:メンバーファイルを初期化したいときに使用する
            members.Initailze();

            //メンバーファイル読み込み
            members.Read();

            if (members.ActiveUsers.Count() == 0)
            {
                Console.WriteLine("アクティブユーザーがいません。");
            }

            //メール配信
            IMail mail = new Mail(members.ActiveUsers);
            mail.Send();
            members.CountUp();
            //メンバーファイルの更新
            var val = members.Serialize(members.Profiles);
            members.Save(val);

            //終了
            Console.WriteLine("---- 処理終了 ----");
            Console.ReadKey();

        }
    }
}
