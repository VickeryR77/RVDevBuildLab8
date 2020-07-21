using System;
using System.Text.RegularExpressions;

namespace igPayatinLay
{
    class Program
    {
        static void Main(string[] args)
        {
            Build();
        }

        
        public static bool CheckVowel(char letter) 
        //Method that returns true if a vowel is in the char location.
        {
            return (letter == 'a' ||
                    letter == 'A' ||
                    letter == 'e' ||
                    letter == 'E' ||
                    letter == 'i' ||
                    letter == 'I' ||
                    letter == 'o' ||
                    letter == 'O' ||
                    letter == 'u' ||
                    letter == 'U');
        }

        public static bool CheckEmail(char symbol) 
        //Checks for the @ symbol
        {
            return (symbol == '@');
        }

        public static bool CheckNumber(char number) 
        //Checks for #'s
        {
            return (number == '0' ||
                    number == '1' ||
                    number == '2' ||
                    number == '3' ||
                    number == '4' ||
                    number == '5' ||
                    number == '6' ||
                    number == '7' ||
                    number == '8' ||
                    number == '9');
        }

        public static void Build()  
        //Kicks off the program.
        {

            //Initialize & hoist QoL variables.
            string ay = "ay";
            string way = "way";
            string builder;
            string builder2;            
            string output = "";
            bool runAgain = true;

            //Beginning of entry.
            Console.WriteLine("Enter a word or a phrase.");
            Console.WriteLine("");

            //Entry.
            string entry = Console.ReadLine();
            string swapEntry = entry;

            //Try to avoid crashing.
            try
            {
                //While entry is blank, get entry.
                while (entry == "")
                {
                    Console.WriteLine("Please enter a word or sentence.");
                    Console.WriteLine("");
                    entry = Console.ReadLine();
                }

                //Make a string array with words in the phrase divided by spaces.
                string[] words = entry.Split(' ');

                //Run through each word.
                foreach (string word in words)
                {
                    //Split the words, one word at a time, into individual characters.
                    char[] array = word.ToCharArray();

                    //Run through the characters to determine what and where they are.
                    for (int i = 0; i < word.Length; i++)
                    {
                        bool running = true;

                        //Email is up first.
                        for (int emailCheck = 0; emailCheck < word.Length; emailCheck++)
                        {
                            if (CheckEmail(word[emailCheck]))
                            {
                                output += word;
                                output += " ";
                                running = false;
                                break;
                            }
                        }

                        //Tells it to move onto the next word if the word contains an @ symbol.
                        if (running != true)
                        {
                            break;
                        }

                        //Checking for numbers.
                        for (int numberCheck = 0; numberCheck < word.Length; numberCheck++)
                        {
                            if (CheckNumber(word[numberCheck]))
                            {
                                output += word;
                                output += " ";
                                running = false;
                                break;
                            }
                        }

                        //Tells it to move onto the next word if the word contains any numbers.
                        if (running != true)
                        {
                            break;
                        }

                        //If first letter is vowel command.
                        if (CheckVowel(word[0]) == true)
                        {
                            output += word + way;
                            output += " ";
                            break;
                        }

                        //If second letter is vowel command.
                        else if (CheckVowel(word[0]) == false && CheckVowel(word[1]) == true)
                        {
                            int count = word.Length;
                            builder = word.Substring(0, 1);
                            builder2 = word.Substring(1, count - 1);
                            output += builder2 + builder + ay;
                            output += " ";
                            break;
                        }

                        //If third letter is vowel command.
                        else if (CheckVowel(word[0]) == false && CheckVowel(word[1]) == false && CheckVowel(word[2]) == true)
                        {
                            int count = word.Length;
                            builder = word.Substring(0, 2);
                            builder2 = word.Substring(2, count - 2);
                            output += builder2 + builder + ay;
                            output += " ";
                            break;
                        }

                        //If fourth letter is vowel command.
                        else
                        {
                            int count = word.Length;
                            builder = word.Substring(0, 3);
                            builder2 = word.Substring(3, count - 3);
                            output += builder2 + builder + ay;
                            output += " ";
                            break;
                        }

                    }
                }

                Console.WriteLine(output);                
            }

            //No exceptions!
            catch{ Console.WriteLine("Sorry, we encountered an error. Please try again."); Console.WriteLine(""); Console.WriteLine("Press enter to try again."); Console.ReadLine(); Build(); }

            //Ask to run again.
            while (runAgain != false) {
                Console.WriteLine("");
                Console.WriteLine("Want to translate another word or phrase? (Y/N)");
                string answer = Console.ReadLine().ToLower();
                if(answer == "y")
                {
                    Build();
                }
                else if (answer == "n")
                {
                    runAgain = false;
                    break;
                }
                else
                {
                    continue;
                }
            }

        }
    }
}


/*      Failed Methods resulting in crashes for complex input.

        public static bool CheckUpperCase(string word)
        {
            char[] array = word.ToCharArray();

            if (Char.IsUpper(word[0]) && Char.IsUpper(word[1]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckTitleCase(string word)
        {
            char[] array = word.ToCharArray();

            if (Char.IsUpper(word[0]) && Char.IsLower(word[1]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckLowerCase(string word)
        {
            char[] array = word.ToCharArray();

            if (Char.IsLower(word[0]) && Char.IsLower(word[1]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        

                Interesting idea here for output.
 
                if (CheckTitleCase(swapEntry) == true)
                {
                    Console.WriteLine($"{Char.ToUpper(output[0])}{output.ToLower().Substring(1,output.Length-1)}");
                }
                if (CheckLowerCase(swapEntry) == true)
                {
                    Console.WriteLine($"{output.ToLower()}");
                }
                if (CheckUpperCase(swapEntry) == true)
                {
                    Console.WriteLine($"{output.ToUpper()}");
                }
*/
