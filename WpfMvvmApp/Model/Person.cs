using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMvvmApp.Helpers;

namespace WpfMvvmApp.Model
{
    public class Person
    {
        public string FirstName { get; set; } // table상 필드
        public string LastName { get; set; }  // table상 필드
        private string email; // table상 필드
        public string Email
        {
            get { return email; }
            set
            {
                if (Commons.IsValidEmail(value))
                    email = value;
                else
                    throw new Exception("Invalid email");
                
            }
        }
        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set
            {
                var result = Commons.CalcAge(value);
                if (result > 135 || result < 0)
                    throw new Exception("Invalid date");
                else
                    date = value;
            }
        }

        public Person(string firstName, string lastName, string email, DateTime date)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Date = date;
        }

        public string Zodiac { get; set; }
        public string ChnZodiac { 
            get {
                return Commons.GetChineseZodiac(Date);
            }  
        }

        public string CalcZodiac
        {
            get
            {
                return Commons.Getcalczodiac(Date);
            }
        }


        public bool IsBirthday
        {
            get
            {
                return DateTime.Now.Month == Date.Month &&
                       DateTime.Now.Day == Date.Day;
            }
        }
        public bool IsAdult
        {
            get
            {
                return Commons.CalcAge(date) > 18;
            }
        }
        

    }
}
