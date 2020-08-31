using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Animation;
using BusinessLogic;

namespace BikeShop
{
    /// <summary>
    /// TestPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TestPage : Page
    {
        public TestPage()
        {
            InitializeComponent();
            InitListBox();
        }
        private void InitListBox()
        {
            
            List<Car> cars = new List<Car>();
            for (int i = 0; i < 10; i++)
            {
                var red = (byte)(i % 3 == 0 ? 255 : (i * 50) % 255);
                var green = (byte)0;
                var blue = (byte)(i % 3 != 0 ? 255 : (i * 90) % 255);
                cars.Add(new Car()
                {
                    Speed = i * 30,
                    Color = Color.FromRgb(red, green, blue),
                }); 
            }
           // LstCar.DataContext = cars;
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Car car = new Car();
            car.Speed = 100;
            car.Color = Colors.Blue;
            car.Driver = new Human { Name = "Ted", HasDrivingLicense = true };

            this.DataContext = car;
            //car1.Color = Colors.AliceBlue;

        }

    }
}
