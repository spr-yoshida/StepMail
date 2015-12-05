using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepMail
{
    public class Mail : IMail
    {
        private readonly string subTitle = "Sub Title";
        private readonly string cMark = "(c) 2015";

        private readonly string _to;
        private readonly string _cc;
        private readonly int _count;
        private readonly string _message;
        //コンストラクタ隠ぺい
        private Mail(string to, string cc, int count, string message)
        {
            this._to = to;
            this._cc = cc;
            this._count = count;
            this._message = message;
        }
        //宛先To
        public string To { get { return _to; } }
        //宛先CC
        public string CC { get { return _cc; } }
        //メールタイトル
        public string Title
        {
            get
            {
                return "配信　第" + String.Format("{0:000}", _count) + "号";
            }
        }
        //メール本文
        public string Body
        {
            get
            {
                var sb = new StringBuilder();
                sb.AppendLine(subTitle);
                sb.AppendLine(_message);
                sb.AppendLine(cMark);
                return sb.ToString();
            }
        }

        public static Mail CreateMail(string to, string cc, int count, string message)
        {
            return new Mail(to, cc, count, message);
        }

        public void Send()
        {
            //Console.WriteLine("メール送信");
            //Console.WriteLine("To:" + To);
            //Console.WriteLine("CC:" + CC);
            //Console.WriteLine("Title:" + Title);
            //Console.WriteLine("Body:" + Body);
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return string.Format("To:{0} CC:{1} Title:{2} Body:{3}", To, CC, Title, Body);
        }
    }
}
