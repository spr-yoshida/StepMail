using Codeplex.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepMail
{
    class Members
    {
        private static readonly string memberFile = "members.json";
        private readonly Message _message;
        public Members(Message message)
        {
            this._message = message;
        }

        public List<Profile> Profiles { get; set; }
        public IEnumerable<Profile> ActiveUsers { get { return Profiles.Where(c => c.Message.Length > 0); } }


        public void Initailze()
        {
            var members = new List<Profile>();
            members.Add(new Profile() { Name = "User1", Mail = "u1@example.com", Count = 1 });
            members.Add(new Profile() { Name = "User2", Mail = "u2@example.com", Count = 2 });
            members.Add(new Profile() { Name = "User3", Mail = "u3@example.com", Count = 3 });

            var jsonStringFromProfiles = DynamicJson.Serialize(members);

            Save(jsonStringFromProfiles);
        }

        public string Serialize(List<Profile> profiles)
        {
            var jsonStringFromProfiles = DynamicJson.Serialize(profiles);

            return jsonStringFromProfiles;
        }

        public void Save(string val)
        {
            //ディレクトリ
            var currentDir = Directory.GetCurrentDirectory();

            //ファイル名
            var fileName = memberFile;
            var fullPath = Path.Combine(currentDir, fileName);

            using (StreamWriter sw = new StreamWriter(fullPath, false, Encoding.GetEncoding("shift_jis")))
            {
                sw.Write(val);
            }
        }

        public string GetMessage(int index)
        {
            var message = string.Empty;
            //countで判断してmessage.jsonファイルより読み込んだ値をセットする
            if (_message.Messages.Count > index)
            {
                message = _message.Messages[index];
            }

            return message;
        }

        public void Read()
        {
            var fileName = memberFile;
            var currentDir = Directory.GetCurrentDirectory();
            var filePath = Path.Combine(currentDir, fileName);

            var profiles = new List<Profile>();
            using (StreamReader sr = new StreamReader(filePath, Encoding.GetEncoding("shift_jis")))
            {
                var data = sr.ReadToEnd();
                var json = DynamicJson.Parse(data);


                foreach (var item in json)
                {
                    var profile = new Profile();
                    profile.Name = item.Name;
                    profile.Mail = item.Mail;
                    int count = (int)item.Count;
                    profile.Count = count;
                    int index = count - 1;
                    profile.Message = GetMessage(index);
                    profiles.Add(profile);
                }
            }
            
            Profiles =  profiles;

        }

        public void CountUp()
        {
            foreach (var activeUser in ActiveUsers)
            {
                activeUser.Count++;
                Console.WriteLine("次回 " + activeUser.Name + " -> [" + activeUser.Count.ToString() + "]回目");
            }
        }

    }
}
