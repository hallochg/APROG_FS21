using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW2_OOP_ARRAYS_VARIABLEN
{
    class UebungVokale
    {
        public UebungVokale()
        {

        }

        public void process()
        {
            Console.WriteLine("please type in a string -> letters");
            string input = Console.ReadLine();
            input = input.ToLower();
            int vowel = 0, consonant = 0;
            string vowels = "aeiou";
            foreach(char letter in input)
            {
                if (Char.IsLetter(letter))
                {
                    if (vowels.Contains(letter))
                    {
                        vowel++;
                    }
                    else
                    {
                        consonant++;
                    }
                }
            }
            Console.WriteLine($"The number of vowels is: {vowel}, the number of consonants is: {consonant}");
        }
    }
}
