using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
   public class Display
    {
        public string Prop { get; set; }
        public Display()
        {
            ShowMenu();
        }
        private void ShowMenu()
        {
            Console.Write(new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.Write(new string(' ', 18));
            Console.WriteLine(new string(' ', 18) + "MENU" + new string(' ', 18));
            Console.Write(new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.Write(new string(' ', 25));
            Console.WriteLine("Welcome to Game Of Life!");
            //Console.Write(new string(' ', 5));
            Console.WriteLine("This is a remake of the popular cellular automata by John Conway.");
            Console.WriteLine("What do you want to see today?");
            Console.Write("Toad Blinker Beacon Gun Glasses Random");
            Console.WriteLine();
            Console.WriteLine("Type below:");
            string thing = Console.ReadLine();
            this.Prop = thing;
            Console.Clear();
        }
    }
}
