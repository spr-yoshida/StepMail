using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepMail
{
    class Mail : IMail
    {
        private readonly IEnumerable<Profile> _activeUser;
        public Mail(IEnumerable<Profile> activeUser)
        {
            this._activeUser = activeUser;
        }

        public void Send()
        {
            foreach (var user in _activeUser)
            {
                Console.WriteLine("メール配信：" + user.Name + "[" + user.Count.ToString() + "]回目");
                //user.Count++;
                //Console.WriteLine("次回：[" + user.Count.ToString() + "]回目");
            }
        }
    }
}
