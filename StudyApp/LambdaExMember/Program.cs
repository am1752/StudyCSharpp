using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExMember
{
    class FriendList
    {
        private List<string> list = new List<string>();

        public void Add(string name) => list.Add(name);
        public void Remove(string name) => list.Remove(name);


        public void PrintAll()
        {
            foreach (var item in list) WriteLine(item);
        }

        public FriendList() => WriteLine("FriendList()");

        //public int Capacity => list.Capacity;
        public int Capacity
        {
            get => list.Capacity;
            set => list.Capacity = value;

        }

        public string this[int index]
        {
            get => list[index];
            set => list[index] = value;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            FriendList obj = new FriendList();
            WriteLine($"obj Capacity : {obj.Capacity}");
            obj.Add("Emey");
            obj.Add("Meeny");
            obj.Add("Hyory");
            obj.Add("Emey");
            WriteLine($"obj Capacity : {obj.Capacity}");

            obj.PrintAll();
            WriteLine("-----------");

            obj.Remove("Emey");
            obj.PrintAll();
            WriteLine();

            WriteLine($"obj Capacity : {obj.Capacity}");
            obj.Capacity = 10;
            WriteLine("-----------");
            obj[0] = "CHAE";
            obj.PrintAll();

            WriteLine($"obj Capacity : {obj.Capacity}");


        }
    }
}
