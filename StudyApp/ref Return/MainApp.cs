using static System.Console;

namespace ref_Return
{
    class Product
    {
        private int price = 100;

        public void PrintPrice()
        {
            WriteLine($"Price : {price}");
        }
        public ref int GetPrice()
        {
            return ref price;
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            Product carrot = new Product();
            ref int local_price = ref carrot.GetPrice();
            carrot.PrintPrice();

            local_price = 3000;
            carrot.PrintPrice();
            WriteLine(local_price);
        }
    }
}
