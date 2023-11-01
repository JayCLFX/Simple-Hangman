using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;

namespace Hangman
{
    public class Program
    {
        public static string randomWord = RandomWord();
        private static bool donedisplay = false;
        public static List<string> Words = new List<string>();
        public static int Draw_Level = 0;

        static void Main(string[] args) => Play();

        static void Play()
        {
            Console.WriteLine("A little Game of Hangman (Countrys) \n\n");
            if (donedisplay == false) Thread.Sleep(3000); donedisplay=true;
            foreach (var letters in randomWord)
            {

                if (!Words.Contains(letters.ToString()))
                {
                    Console.Write("_.");
                }
                else
                {
                    Console.Write(letters);
                }
            }
            Console.WriteLine("\n");
            string answer = ""; answer = Console.ReadLine();
            Console.Clear();

            bool Check = false;
            foreach (var letters in randomWord)
            {
                if (answer.Contains(letters))
                {
                    Words.Add(letters.ToString());
                    Check = true;
                }
            }

            if (Check == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Good Job");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Meh");
                Thread.Sleep(500); Console.Clear();
                Draw();
            }
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(2000); Console.Clear();
            Play();
        }

        static void Draw()
        {
            switch (Draw_Level)
            {
                case 0:
                    {
                        Console.WriteLine($"  +---+");
                        Console.WriteLine($"  |   |");
                        Console.WriteLine($"      |");
                        Console.WriteLine($"      |");
                        Console.WriteLine($"      |");
                        Console.WriteLine($"      |");
                        Console.WriteLine($"=========");
                        Draw_Level += 1;
                        break;
                    }
                case 1:
                    {
                        Console.WriteLine($"  +---+");
                        Console.WriteLine($"  |   |");
                        Console.WriteLine($"  O   |");
                        Console.WriteLine($"      |");
                        Console.WriteLine($"      |");
                        Console.WriteLine($"      |");
                        Console.WriteLine($"=========");
                        Draw_Level += 1;
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine($"  +---+");
                        Console.WriteLine($"  |   |");
                        Console.WriteLine($"  O   |");
                        Console.WriteLine($"  |   |");
                        Console.WriteLine($"      |");
                        Console.WriteLine($"      |");
                        Console.WriteLine($"=========");
                        Draw_Level += 1;
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine($"  +---+");
                        Console.WriteLine($"  |   |");
                        Console.WriteLine($"  O   |");
                        Console.WriteLine($"  |   |");
                        Console.WriteLine($" /|   |");
                        Console.WriteLine($"      |");
                        Console.WriteLine($"=========");
                        Draw_Level += 1;
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine($"  +---+");
                        Console.WriteLine($"  |   |");
                        Console.WriteLine($"  O   |");
                        Console.WriteLine($"  |   |");
                        Console.WriteLine(@" /|\  |");
                        Console.WriteLine($"      |");
                        Console.WriteLine($"=========");
                        Draw_Level += 1;
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine($"  +---+");
                        Console.WriteLine($"  |   |");
                        Console.WriteLine($"  O   |");
                        Console.WriteLine($"  |   |");
                        Console.WriteLine(@" /|\  |");
                        Console.WriteLine($" /    |");
                        Console.WriteLine($"=========");
                        Draw_Level += 1;
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine($"  +---+");
                        Console.WriteLine($"  |   |");
                        Console.WriteLine($"  O   |");
                        Console.WriteLine($"  |   |");
                        Console.WriteLine(@" /|\  |");
                        Console.WriteLine(@" / \  |");
                        Console.WriteLine($"=========");
                        Draw_Level += 1;
                        break;
                    }
                    case 7:
                    {
                        Console.WriteLine("Game Over!"); Thread.Sleep(5000);
                        Reset();
                        break;
                    }
            }
            Thread.Sleep(2000);
            Console.ForegroundColor = ConsoleColor.White; Console.Clear();
            Play();
        }

        static void Reset()
        {
            randomWord = RandomWord();
            donedisplay = false;
            Words.Clear();
            Draw_Level = 0;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Play();
        }

        static string RandomWord()
        {
            var randomizer = RandomizerFactory.GetRandomizer(new FieldOptionsCountry()); string randomword = randomizer.Generate();
            return randomword;
        }
    }
}
