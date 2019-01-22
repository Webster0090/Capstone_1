using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] splitWords;
            string userInput, response;
            int length;

            Console.WriteLine("Welcome to the Pig Latin Translator!");

            do
            {
                
                Console.Write("Please enter a line to translate: ");
                userInput = Console.ReadLine().ToLower();
                splitWords = userInput.Split(' ');
                length = splitWords.Length;

                
                for (int i = 0; i < splitWords.Length; i++)
                {
                    string newWords = translateToPigLatin(splitWords[i]);
                    Console.Write(newWords + " ");
                }
                
                Console.WriteLine(" ");
                Console.Write("Would you like to translate a new line? (y/n): ");
                response = Console.ReadLine().ToLower();
            }
            while (YesOrNo(response));
        }
        
        public static bool IsVowel(string letter)
        {
            switch (letter)
            {
                case "a":
                case "e":
                case "i":
                case "o":
                case "u":
                    return true;
                default:
                    return false;
            }
        }
        
        public static int getIndex(string wordArray)
        {
            for (int i = 0; i <= wordArray.Length; i++)
            {
                while (wordArray[i] == 'a' || wordArray[i] == 'e' || wordArray[i] == 'i' || wordArray[i] == 'o' || wordArray[i] == 'u')
                {
                    return i;
                }

            }
            return 0;
        }

        
        public static bool YesOrNo(string response)
        {
            while (response == "y")
            {
                return true;
            }
            if (response == "n")
            {
                Console.WriteLine("Exiting program...");
                Console.ReadLine();
                return false;
            }
            else
            {
                Console.WriteLine("Invalid input, try again later."); 
                Console.ReadLine();
                return false;
            }
        }
        
        public static string translateToPigLatin(string input)
        {

            string firstLetter = input.Substring(0, 1);
            string restOfWord = input.Substring(1);
            string word;
            
            if (!IsVowel(firstLetter))
            {
                int firstVowelIndex = getIndex(input);
                string firstLetters = input.Substring(0, firstVowelIndex);
                restOfWord = input.Substring(firstVowelIndex);
                word = restOfWord + firstLetters + "ay ";
                return word;

            }
            else
            {
                word = input + "way ";
                return word;
            }
        }
    }
}


