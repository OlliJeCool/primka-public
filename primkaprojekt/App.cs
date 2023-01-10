namespace primkaprojekt
{
    public class App
    {

        private readonly int height = 43;
        private readonly int width = 209;
        private int k;
        private int q;

        public void Run()
        {
            while (true)
            {
                Console.Write("k: ");
                var input = Console.ReadLine();
                if(input != "") { k = inputParser(input); }
                Console.Write("q: ");
                var input2 = Console.ReadLine();
                if(input2 != "") { q = inputParser(input2); }

                if (k == int.MinValue || q == int.MinValue)
                {
                    Console.WriteLine("Incorrect values!");
                    continue;
                }

                string[,] screen = new string[height, width];

                createAxis(screen);

                calculatePointCooridnates(screen, k, q);

                Console.WriteLine($"y = {k} * x + {q}");

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


        private void calculatePointCooridnates(string[,] screen, int k, int q)
        {

            for (int i = -width / 2; i < width / 2 + 1; i += 1)
            {
                int x = i;
                int y = k * x + q;

                if (height / 2 - y < 0 || height / 2 - y > height - 1 || width / 2 + x < 0 || width / 2 + x > width - 1) { continue; }

                screen[height / 2 - y, width / 2 + x] = "x";
            }
        }


        private void Print(string[,] screen)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(String.IsNullOrEmpty(screen[i, j]) ? " " : screen[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static int inputParser(string val)
        {
            if (int.TryParse(val, out int num))
            {
                return num;
            }
            else return int.MinValue;
        }
    }
}
