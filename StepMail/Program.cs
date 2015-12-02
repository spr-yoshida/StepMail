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
            var profiles = members.Read();
            //アクティブユーザの絞り込み
            var activeUser = profiles.Where(c => c.Message.Length > 0);

            if (activeUser.Count() == 0)
            {
                Console.WriteLine("アクティブユーザーがいません。");
            }

            //メール配信
            foreach (var user in activeUser)
            {
                Console.WriteLine("メール配信：" + user.Name + "[" + user.Count.ToString() + "]回目");
                user.Count++;
                Console.WriteLine("次回：[" + user.Count.ToString() + "]回目");
            }

            //メンバーファイルの更新
            var val = members.Serialize(profiles);
            members.Save(val);

            //終了
            Console.WriteLine("---- 処理終了 ----");
            Console.ReadKey();

        }
    }
}
