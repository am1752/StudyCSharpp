using Caliburn.Micro;

namespace SecondCliburnApp.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHaveDisplayName
    {
        public override string DisplayName { get; set; }
        //public string FirstName { get; set; }

        string firstName;

        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                NotifyOfPropertyChange(() => FirstName);
            }
        }

        string lastName;

        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                NotifyOfPropertyChange(() => LastName);
            }
        }

        public string FullName
        {
            get => $"{firstName} {lastName}";
        }


        public ShellViewModel()
        {
            DisplayName = "Second Caliburn App";
            FirstName = "CHAE";
        }

    }
}