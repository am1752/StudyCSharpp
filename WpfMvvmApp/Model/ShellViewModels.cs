using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfMvvmApp.Model
{
    public class ShellViewModels : ViewModelBase
    {
        #region
        string inLastName;
        string inFirstName;
        string inEmail;
        DateTime? inDate;

        string outLastName;
        string outFirstName;
        string outEmail;
        string outDate;
        string outAdult;
        string outBirthday;
        string outChnZodiac; // 2020.07.27 16:43 신규 추가
        string outCalcZoidac;

        public string InLastName
        {
            get => inLastName;
            set
            {
                inLastName = value;
                RaisePropertyChanged("InLastName");
            }
        }

        public string InFirstName
        {
            get => inFirstName;
            set
            {
                inFirstName = value;
                RaisePropertyChanged("InFirstName");
            }
        }

        public string InEmail
        {
            get => inEmail;
            set
            {
                inEmail = value;
                RaisePropertyChanged("InEmail");
            }
        }

        public DateTime? InDate
        {
            get => inDate;
            set
            {
                inDate = value;
                RaisePropertyChanged("InDate");
            }
        }

        public string OutLastName
        {
            get => outLastName;
            set
            {
                outLastName = value;
                RaisePropertyChanged("OutLastName");
            }
        }

        public string OutFirstName
        {
            get => outFirstName;
            set
            {
                outFirstName = value;
                RaisePropertyChanged("OutFirstName");
            }
        }

        public string OutEmail
        {
            get => outEmail;
            set
            {
                outEmail = value;
                RaisePropertyChanged("OutEmail");
            }
        }

        public string OutDate
        {
            get => outDate;
            set
            {
                outDate = value;
                RaisePropertyChanged("OutDate");
            }
        }

        public string OutBirthday
        {
            get => outBirthday;
            set
            {
                outBirthday = value;
                RaisePropertyChanged("OutBirthday");
            }
        }

        public string OutAdult
        {
            get => outAdult;
            set
            {
                outAdult = value;
                RaisePropertyChanged("OutAdult");
            }
        }

        public string OutChnZodiac // 2020.07.27 16:43 신규 추가
        {
            get => outChnZodiac;
            set
            {
                outChnZodiac = value;
                RaisePropertyChanged("OutChnZodiac");
            }
        }

        public string OutCalcZoidac // 2020.07.27 16:43 신규 추가
        {
            get => outCalcZoidac;
            set
            {
                outCalcZoidac = value;
                RaisePropertyChanged("OutCalcZoidac");
            }
        }
        #endregion

        ICommand clickCommand;
        public ICommand ClickCommand=>clickCommand?? (clickCommand = new RelayCommand<object>(o => Click(),o => IsClick())) ;

        private bool IsClick()
        {
            return  (!string.IsNullOrEmpty(inEmail) &&
                    !string.IsNullOrEmpty(inDate.ToString()) &&
                    !string.IsNullOrEmpty(inFirstName) &&
                    !string.IsNullOrEmpty(inLastName));
        }

        private void Click()
        {
            try
            {
                DateTime date = inDate ?? DateTime.Now;
                Person person = new Person(inFirstName, inLastName, inEmail, date);

                OutLastName = person.LastName;
                OutFirstName = person.FirstName;
                OutEmail = person.Email;
                OutDate = person.Date.ToShortDateString();
                OutAdult = person.IsAdult.ToString();
                OutBirthday = person.IsBirthday.ToString();
                OutChnZodiac = person.ChnZodiac; // 2020.07.27 16:43 신규 추가
                OutCalcZoidac = person.CalcZodiac;


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error : {ex.Message}");
            }
        }

        
    }
}
