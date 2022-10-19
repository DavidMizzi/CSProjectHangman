using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CSProjectHangman
{

    internal class Program
    {
        static void Main(string[] args)
        {
            // User intro display message

            Console.Write("Welcome to the game of Hangman.\n" +
                "Prepare to be... ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("mentally ");
            Console.ResetColor();
            Console.Write(
                "tested.\n");
            Console.WriteLine();
            Console.WriteLine(
                "Hangman rules:\n" +
                "The game will randomly select a word. Depending on the length of the word,\n" +
                "you will be given a number of chances to guess the letters in the word.\n" +
                "If you guess a letter correctly, it will be revealed to you.");
            Console.WriteLine();
            Console.WriteLine("If you have not guessed the entire word before your chances are up - " +
                "then it will be ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("GAME OVER ");
            Console.ResetColor();
            Console.WriteLine("for you!");
            Console.WriteLine();
            Console.WriteLine(
                "If however, you happen to win this game of wit and chance,\n" +
                "then you may bask in the glory of having conquored the game of hangman\n" +
                "and escaped the wrath of the hangman's noose.\n" +
                "\n" +
                "Press ENTER when ready... if you dare.");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadKey();
            Console.Clear();


            // String array1 as word database
            string[] words = {"trampoline","lumberjack","binoculars","palindrome","artichokes","background","earthlings","aftershock",
                              "algorithms","abductions","bankruptcy","bankrupted","birthplace","blueprints","boyfriends","breakdowns",
                              "clipboards","compatible","complained","complaints","completing","cornflakes","decorating","defaulting",
                              "despicably","destroying","educations","exhausting","exhaustion","flamingoes","flourished","forgivable",
                              "fruitcakes","godfathers","graciously","harvesting","hospitable","hypnotized","impersonal","importance",
                              "introduces","journalism","lifeguards","lubricated","magnitudes","methodical","microwaves"};

            // Array count variable
            var totalCount = 0;

            // Invoking count function on array elements
            totalCount = words.Count();

            // Display array count
            // Console.WriteLine(totalCount);   //Array count execution commented out for non-execution.
            // Array word count total = 47 words in array 

            // Randomised word selection from array1
            Random rnd = new Random();
            int index = rnd.Next(0, words.Count());
            // Console.WriteLine($"Word: {words[index]}");  // commented out but retained for further study

            // Log word selected from array1 to embed the random word into the game as variable
            string gameWord = words[index];
            // Console.WriteLine($"The (array) word for this game is: {gameWord}");   // commented out but retained for further study

            // Count number of chars in selected game word
            int length = gameWord.Length;
            Console.WriteLine($"The number of letters in the word are {length}");
            Console.WriteLine();

            // Blank array to be populated by char guesses

            char[] blankArray = new char[gameWord.Length];  // creates array of string length
          
            // Establish amount of character guesses
            int guesses = 0;

            if (length <= 6)
            {
                guesses = 9;
            }

            else if (length == 7)
            {
                guesses = 11;
            }

            else if (length == 8)
            {
                guesses = 11;
            }

            else if (length >= 9)
            {
                guesses = 13;
            }

            else
            {
                guesses = 13;
            }


            // @userinput field, char guess check and character guess counter deductor utilising while loop
            while (guesses != -1)
            {

                int guessesRemaining = guesses--;

                Console.WriteLine("What is your guess?");
                Console.WriteLine();
                var charGuess = Console.ReadKey(true);
                //var charGuessLower = charGuess.ToLower();
                Console.WriteLine("You chose: " + charGuess.KeyChar);

                if (gameWord.Contains(charGuess.KeyChar))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Correct. ");
                    Console.ResetColor();
                    Console.WriteLine($"{charGuess.KeyChar} is in the word.");
                    // find index of guessed char
                    int index1 = gameWord.IndexOf(charGuess.KeyChar); 
                    // convert charGuess to string. charGuess in string is letterChar
                    string letterChar = charGuess.KeyChar.ToString();
                    // Console.WriteLine($"letterChar is: {letterChar}"); // commented out but retained for further study


                    foreach (char letter in gameWord)
                    {
                        //Console.Write(charGuess.KeyChar);
                    }

                    // Console.WriteLine(charGuess + "is in index position: " + index1); // commented out but retained for further study

                    int setIndex = index1;

                    blankArray[setIndex] = charGuess.KeyChar;
                    // Console.WriteLine("Blank array index and char is: " + blankArray[setIndex]); // commented out but retained for further study

                    // iterate array indexes to reveal user guessed chars
                    int newIndex = -1;
                    for (newIndex = -1; newIndex != index1; newIndex++)
                    {
                        {
                            Console.Write("");

                        }
                    }

                    Console.Write($"Letters revealed: ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(blankArray);
                    Console.ResetColor();
                    Console.WriteLine();

                    Console.WriteLine();

                    // break loop if guessed letters for game word
                    if (words[index].SequenceEqual(blankArray))
                    {
                        break;
                    }

                    Console.WriteLine($"You have {guessesRemaining} guesses remaining.");
                }

                else if (blankArray.Equals(gameWord))
                {
                    break;
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Incorrect.");
                    Console.ResetColor();
                    Console.WriteLine($"{charGuess.KeyChar} is NOT in the word.");
                    Console.WriteLine($"You have {guessesRemaining} guesses remaining.");
                    Console.WriteLine();

                }
            }

            // Win or lose messages
            if (words[index].SequenceEqual(blankArray))
            {   // Win game message
                Console.Write("You");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" WIN!!");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("It appears that on this occasion, by what I expect is a fluke," +
                    " you have beaten the game.");
                Console.WriteLine();
                Console.WriteLine("Good job and remember: Stay in school.");
                Console.WriteLine();
            }
            else
            {   // Lose game message
                Console.Write("You");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(" LOSE!!");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Judging by your performance, it may not be worth you coming back.");
                Console.WriteLine("Remember: Stay in school.");
                Console.WriteLine();
            }
     
        }
    }
}




            