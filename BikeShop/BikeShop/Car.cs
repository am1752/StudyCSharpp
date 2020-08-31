using System.Windows.Media;

namespace BusinessLogic
{
    public class Car:Notifier
    {
        private double speed;

        public double Speed
        {
            get => speed;
            set
            {
                speed = value;
                OnPropertyChanged("Speed");
            }
        }

        public Color Color { get; set; }
      
        public Human Driver { get; set; }
    }
    public class Human
    { 
        public string Name { get; set; }
        public bool HasDrivingLicense { get; set; }
    }
}
