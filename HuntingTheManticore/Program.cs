namespace HuntingTheManticore
{
    internal class Program
    {
        static void Main(string[] args)
        {

            void LineCreate()
            {
                for (int x = 0; x < Console.WindowWidth;x++)
                {
                    Console.Write("-");
                }
                Console.Write("\n");
            }

            int CalcDis(string text, int min, int max, bool check)
            {

                while (true)
                {
                    Console.Write(text);
                    int userInput = int.Parse(Console.ReadLine());

                    if (userInput > min && userInput < max)
                    {   
                        if (check)
                        {
                            Console.Clear();
                            Console.WriteLine("Player 2, it is your turn.");
                            LineCreate();
                        }

                        return userInput;
                    }
                }
            }

            int CannonDamage(int round) 
            {
                if (round % 3 == 0 && round % 5 == 0)
                {
                    return 10;
                }
                else if (round % 5 == 0 || round % 3 == 0)
                {
                    return 3;
                }
                else
                {
                    return 1;
                }
            }

            void Game()
            {
                int manticore = 10;
                int city = 15;
                int round = 1;
                int manticorePos = CalcDis("Player 1, how far away from the city do you want to station the Manticore? ", 0, 100, true);

                while (manticore > 0 && city > 0)
                {

                    int cannonDamage = CannonDamage(round);
                    int cannonRange = CalcDis($"STATUS: Round: {round}  City: {city}/15  Manticore: {manticore}/10\nThe cannon is expected to deal {cannonDamage} damage this round.\nEnter desired cannon range: ", 0, 100, false);

                    if (cannonRange == manticorePos)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("That round was a DIRECT HIT!");
                        manticore -= cannonDamage; 
                    }
                    else if (cannonRange < manticorePos)
                    {

                        if (manticorePos - cannonRange > 10)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }

                        Console.WriteLine("That round FELL SHORT of the target.");
                    }
                    else if (cannonRange > manticorePos)
                    {

                        if (cannonRange - manticorePos > 10)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }

                        Console.WriteLine("That round OVERSHOT the target.");
                    }

                    Console.ForegroundColor = ConsoleColor.White;

                    LineCreate();

                    round++;
                    city--;

                }

                
                if (manticore <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
                }
                else if (city <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("The city has been destroyed! The city of Consolas is now noting but ruins.");
                }
            }

            Game();

        }
    }
}