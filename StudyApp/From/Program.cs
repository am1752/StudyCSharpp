using static System.Console;
using System.Linq;
using System.Collections.Generic;

namespace From
{
    class Profile
    {
        public string Name { get; set; }

        public int Height { get; set; }
    }

    class Subject
    {
        public string Name { get; set; }

        public int[] Score { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region Sample
            int[] numbers = { 9, 2, 6, 4, 5, 3, 7, 8, 1, 10 };
            var result = from n in numbers  //IEnumerable<int> result도 가능
                         where n % 2 == 0
                         orderby n ascending
                         select n;


            //foreach (var item in result) WriteLine(item);
            #endregion

            #region
            List<Profile> profiles = new List<Profile>
            {
                new Profile {Name = "박서준" , Height = 184},
                new Profile {Name = "윤두준",  Height = 176},
                new Profile {Name = "제니" ,   Height = 172},
                new Profile {Name = "지수" ,   Height = 167},
                new Profile {Name = "톰홀랜드",Height = 168}
            };

            var newProfiles = from item in profiles
                              where item.Height > 170
                              orderby item.Name
                              select new
                              {
                                  Name = item.Name,
                                  InchHeight = item.Height * 0.393
                              };

            //foreach (var item in newProfiles) WriteLine($"{item.Name}의 키 {item.InchHeight}Inch");
            #endregion

            List<Subject> subjects = new List<Subject>
            {
                new Subject() { Name = "연두반", Score = new int[] {99,80,70,24,52}},
                new Subject (){ Name = "분홍반", Score = new int[] {60,45,87,72}},
                new Subject (){ Name = "파랑반", Score = new int[] {9,30,85,94}},
                new Subject (){ Name = "노랑반", Score = new int[] {90,88,0}}
            };

            var newSubjects = from c in subjects
                              from s in c.Score
                              where s < 60
                              orderby s
                              select new { c.Name, Lowest = s };

            foreach (var item in newSubjects) WriteLine($"{item.Name}, {item.Lowest}");
        }
    }
}
