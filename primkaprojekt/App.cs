using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace primkaprojekt
{
    public class App
    {

        private readonly int height = 67;
        private readonly int width = 209;
        private double k;
        private double q;

        public void Run()
        {
            while (true)
            {
                Console.Write("k: ");
                k = inputParser(Console.ReadLine());
                Console.Write("q: ");
                q = inputParser(Console.ReadLine());

                if (k == int.MinValue || q == int.MinValue)
                {
                    Console.WriteLine("wrong input");
                    continue;
                }

                string[,] screen = new string[height, width];

                createAxis(screen);
                calculatePointCooridnates(screen, k, q);
                Print(screen);
                Thread.Sleep(6000);
                Console.Clear();
            }
        }

        private void createAxis(string[,] screen)
        {
            for (int i = 0; i < width; i++)
            {
                screen[height / 2, i] = "-";
            }

            for (int i = 0; i < height; i++)
            {
                screen[i, width / 2] = "|";
            }

            screen[height / 2, width / 2] = "+";
        }


        private void calculatePointCooridnates(string[,] screen, double k, double q)
        {
            double step = k == 0 ? 1 : 1 / k;
            if (Math.Abs(k) < 1) { step = 1; }

            for (double i = -width / 2; i < width / 2 + 1; i += step)
            {
                double x = i;
                double y = k * x + q;


                if (height / 2 - y < 0 || height / 2 - y > height - 1 || width / 2 + x < 0 || width / 2 + x > width - 1) { continue; }

                screen[height / 2 - (int)Math.Round(y), width / 2 + (int)Math.Round(x)] = "x";
            }
        }


        private void Print(string[,] screen)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.ForegroundColor = screen[i, j] == "x" ? ConsoleColor.Cyan : ConsoleColor.White;
                    Console.Write(String.IsNullOrEmpty(screen[i, j]) ? " " : screen[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static double inputParser(string val)
        {
            var temp = val.Split("/");

            if (temp.Length == 1)
            {
                if (int.TryParse(val, out int num))
                {
                    return (double)num;
                }
                else return int.MinValue;
            }

            else if (temp.Length == 2)
            {
                if (int.TryParse(temp[0].ToString(), out int a) && int.TryParse(temp[1].ToString(), out int b))
                {
                    return (double)a / b;
                }
                return int.MinValue;
            }
            return int.MinValue;
        }
    }
}