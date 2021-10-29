using System;

namespace Lab_26_Craps
{
    class Program
    {
        static void Main(string[] args)
        {
            CrapsGame g = new CrapsGame();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine();
                g.Play();
                Console.WriteLine();
            }
            g.DisplayStatus();
        }
    }
}
