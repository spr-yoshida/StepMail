using Codeplex.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepMail
{
    public class Members
    {
        public Members() { }

        public IList<Profile> Profiles { get; private set; }

        public static void Initailze(string filePath)
        {
            var members = new List<Profile>();
            members.Add(new Profile() { Name = "User1", Mail = "u1@example.com", Count = 1 });
            members.Add(new Profile() { Name = "User2", Mail = "u2@example.com", Count = 2 });
            members.Add(new Profile() { Name = "User3", Mail = "u3@example.com", Count = 3 });

            var jsonStringFromProfiles = DynamicJson.Serialize(members);

            Save(filePath, jsonStringFromProfiles);
        }

        public string Serialize()
        {
            var jsonStringFromProfiles = DynamicJson.Serialize(Profiles);

            return jsonStringFromProfiles;
        }

        public static void Save(string filePath, string val)
        {
            using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.GetEncoding("shift_jis")))
            {
                sw.Write(val);
            }
        }

        public void Read(string filePath)
        {
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
                    profiles.Add(profile);
                }
            }
            
            Profiles =  profiles;

        }

        public IList<Profile> GetActiveUsers(int count)
        {
            return this.Profiles.Where(c => c.Count <= count).ToList();
        }

        public void CountUp()
        {
            foreach (var profile in Profiles)
            {
                profile.Count++;
                Console.WriteLine("次回 " + profile.Name + " -> [" + profile.Count.ToString() + "]回目");
            }
        }

    }
}
