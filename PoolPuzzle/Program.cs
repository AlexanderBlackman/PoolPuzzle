using System;

namespace PoolPuzzle
{
    class Question
    {
        /// <summary>
        /// Generates two random numbers and the operator (times/add).
        /// </summary>
        /// <param name="add">will we add? (false for multiply)</param>
        public Question(bool add)
        {
            if (add) Op = "+";
            else Op = "*";
            N1 = random.Next(1,10);
            N2 = random.Next(1,10);
        }

        public static Random random = new Random();
        // Set to private, just to prevent accidental overwriting.
        public int N1 { get; private set; }
        public string Op { get; private set; }
        public int N2 { get; private set; }
        /// <summary>
        /// Checks if the answer is correct or not
        /// </summary>
        /// <param name="playerAnswer">The integer answer given by the player</param>
        /// <returns>true for correct, false for incorrect</returns>
        public bool Check(int playerAnswer)
        {
            if (Op == "+") return (playerAnswer == N1 +N2);
        else return (playerAnswer  == N1 * N2 );
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            // random.Next(2) == 1, randomly returns either true or false
            Question currentQ = new Question(Question.random.Next(2) == 1);
            while (true)
            {
                //Writes out a question for the player
                Console.Write($"{currentQ.N1 } {currentQ.Op } {currentQ.N2} = ");
                if (!int.TryParse(Console.ReadLine(), out int i))
                {
                    Console.WriteLine("Thanks for playing!");
                    //exits the game if an integer isn't provided
                    return;
                }
                if (currentQ.Check(i))
                {
                    Console.WriteLine("Right!");
                    //generates a new question
                    currentQ = new Question(Question.random.Next(2) == 1);
                }
                else Console.WriteLine("Wrong! Try again.");
            }
        }
    }
}
