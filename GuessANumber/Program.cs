namespace GuessANumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
        }
    }
    class Game
    {
        private Random random = new Random();
        private int playersCount;
        private int randomNumber;
        private bool isGuessed;

        public Game()
        {
            playersCount = Input.GetPlayersCount();
            randomNumber = random.Next(1, playersCount * 10);
        }
        public void Start()
        {
            while (!isGuessed)
            {
                for (int player = 1; player < playersCount + 1; player++)
                {
                    int number = Input.GetPlayerAnswer(player);
                    if (randomNumber == number)
                    {
                        Console.WriteLine($"Игрок {player} угадал число! Загаданное число: {number}");
                        isGuessed = true;
                        break;
                    }
                }
            }
        }
    }
    static class Input
    {
        public static int GetPlayersCount()
        {
            Console.WriteLine("Введите кол-во игроков: ");
            int result = GetCorrectInput("Введите кол-во игроков: ");
            return result;
        }
        public static int GetPlayerAnswer(int number)
        {
            Console.WriteLine($"Игрок {number}, введите число:");
            int result = GetCorrectInput($"Игрок {number}, введите число: ");
            return result;
        }
        private static int GetCorrectInput(string message)
        {
        back:
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                if (result <= 0)
                {
                    Console.WriteLine("Число не может быть отрицательным или нулём!");
                    Console.WriteLine(message);
                    goto back;
                }
                return result;
            }
            else
            {
                Console.WriteLine("Неккоректный ввод");
                Console.WriteLine(message);
                goto back;
            }
        }
    }
}