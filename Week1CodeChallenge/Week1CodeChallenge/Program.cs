using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1CodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {

            //creates a loop to ''FizzBuzz' numbers 0-20
            for (int i = 0; i <= 20; i++)
            {
                Console.WriteLine(FizzBuzz(i));
            }

            //creates a loop to ''FizzBuzz' numbers 79-92
            for (int i = 79; i <= 92; i++)
            {
                Console.WriteLine(FizzBuzz(i));
            }

            //call Yodaizer
            Console.WriteLine(Yodaizer("I like code"));

            //call TextStats
            Console.WriteLine(TextStats("I look just like Buddy Holly, and you're Mary Tyler Moore. I don't care what they say about us anyway. I don't care about that."));

            //call isPrime for 1-25
            for (int i = 1; i <= 25; i++)
                if (IsPrime(i) == false)
                {
                    Console.WriteLine(i);
                }
                else
                {
                    Console.WriteLine(i + " is a prime number");
                }

            //call DashInsert
            Console.WriteLine(DashInsert(454793));
            Console.WriteLine(DashInsert(8675309));
            Console.ReadKey();

        }
        public static string FizzBuzz(int number)
        {

            // if parameter is divisible by 3 and 5 return string "FizzBuzz"
            if ((number % 3) == 0 && (number % 5) == 0)
            {
                return ("FizzBuzz");
            }

            // if parameter is divisible by 3 return string "Buzz"
            else if ((number % 3) == 0)
            {
                return ("Buzz");
            }

            // if parameter is divisible by 5 return string "Fizz"
            else if ((number % 5) == 0)
            {
                return ("Fizz");
            }

            //handles negative number cases
            else if (number < 0)
            {

                //returns empty string but needs to return number
                return string.Empty;
            }

            //converts int parameter number to string
            else
            {
                return (number.ToString());
            }
        }
        public static string Yodaizer(string text)
        {

            //splits up the words from the 'text' parameters and put them in a list called 'words'
            List<string> words = new List<string>(text.Split(' ')).ToList();

            //variable used for tracking index number of a word
            int wordsIndex = words.Count - 1;

            //set empty string
            string tempString = string.Empty;

            //makes sure text has been enetered for text parameter
            if (text != null)
            {

                //loops while index is greater than zero
                for (int i = wordsIndex; i >= 0; i--)
                    if (i == 0)
                    {
                        //does not add space to that word at index 0 
                        tempString += (words[wordsIndex]);
                    }
                    else if (words.Count == 3)
                    {
                        return (words[2] + ", " + words[0] + " " + words[1]);
                    }
                    else
                    {
                        //writes each word to console and deincrements wordIndex
                        tempString += (words[wordsIndex] + " ");
                        wordsIndex--;
                    }
            }
            //returns new backwards string
            return tempString;
        }

        public static string TextStats(string input)
        {

            int consonants = 0;
            int vowels = 0;
            int specialChars = 0;
            int words = 0;

            //get total number of characters
            int characters = input.Length;

            //for each char, check if letter or number
            foreach (char c in input)
            {
                //IsLetterOrDigit check completes and if it is not a letter or digit +1 is added to special chars count
                if (!char.IsLetterOrDigit(c.ToString(), 0))
                {
                    specialChars++;
                }

                //vowel check
                if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u' ||
                    c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U')
                {
                    vowels++;
                }
                //count spaces and increase word count
                if (c == ' ')
                {
                    words++;
                }
            }

            //add +1 for first word
            words = words + 1;

            //Take all charcters and subtract specials and vowels to get consonants
            consonants = characters - specialChars - vowels;

            //return each count on a new line
            return ("Characters: " + characters + "\nConsonants: " + consonants + "\nSpecial: " + specialChars + "\nVowels: "
                + vowels + "\nWords: " + words);
        }

        public static bool IsPrime(int number)
        {
            //varibale will be used to see if a number is divisible by another
            int divisor = 0;

            //Edge case, 1 is prime, return true
            if (number == 1)
            {
                return true;
            }
            for (int i = 2; i <= number; i++)
            {
                if (number % i == 0)
                {
                    //add +1 to divisor
                    divisor++;
                }
            }

            //Prime check - If divisor > 1, it's not prime (for negtive numbers)
            if (number != 1 && divisor == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string DashInsert(int number)
        {
            //convert number input to string numbers
            string numbers = number.ToString();
            
            //convert first number to float
            int lastDigit = (int)Char.GetNumericValue(numbers[0]);

            //initialize currentDigit for use in for loop
            int currentDigit;

            // declare empty string for output
            string output = string.Empty;

            //loop checks if number is odd
            for (int i = 1; i < numbers.Length; i++)
            {
                //set currentDigit to the next number
                currentDigit = (int)Char.GetNumericValue(numbers[i]);

                //determine if lastDigit and currentDigit are odd
                if ((lastDigit % 2 != 0 && lastDigit != 0) && (currentDigit % 2 != 0 && currentDigit != 0))
                {
                    //places dash after lastDigit
                    output = output + lastDigit + "-";
                }
                else
                {
                    //output digit without dash
                    output = output + lastDigit;
                }
                
                //set lastDigit to currentDigit
                lastDigit = currentDigit;
            }

            //return output with last number
            return output + lastDigit;
        }
    }
}
