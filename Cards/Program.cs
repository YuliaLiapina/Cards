using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cards.Objects;
using Cards.Shared;

namespace Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            var deck = new Deck();

            deck.Shuffle();
            Console.WriteLine("\n--Shuffled\n");
            deck.Print();

            deck.Sort();
            Console.WriteLine("\n--Sorted\n");
            deck.Print();

            Console.ReadLine();
        }
    }
}
