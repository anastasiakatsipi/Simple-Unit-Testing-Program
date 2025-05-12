using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HRLibDll
{
    public class HRLibDLL
    {
        //Η δομή δεδομένων του Employee
        public struct Employee
        {
            public string Name;
            public string HomePhone;
            public string MobilePhone;
            public DateTime Birthday;
            public DateTime HiringDate;

            public Employee(string Name, string HomePhone, string MobilePhone, DateTime Birthday, DateTime HiringDate)
            {
                this.Name = Name;
                this.HomePhone = HomePhone;
                this.MobilePhone = MobilePhone;
                this.Birthday = Birthday;
                this.HiringDate = HiringDate;
            }
        }

        //Ερώτημα Α.1
        public bool ValidName(string Name)
        {
            // Check if the name is not null or empty
            if (string.IsNullOrEmpty(Name))
            {
                return false;
            }

            // Check if the name contains only letters and spaces
            if (!Regex.IsMatch(Name, @"^[A-Za-z\s]+$"))
            {
                return false;
            }

            // Add more criteria as needed

            // If all criteria pass, consider the name valid
            return true;

        }

        //Ερώτημα Β.2
        public bool ValidPassword(string Password)
        {
            //Β.2.α Εξετάζω εάν έχει τουλάχιστον 12 αριθμούς
            if (Password.Length < 12)
            {
                return false;
            }

            //Β.2.β
            char[] symbols = { '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '-', '=', '{', '}', '[', ']', ';', ':', '<', '>', ',', '.' };
            bool hasSymbol = symbols.Any(Password.Contains);
            bool hasUppercase = Password.Any(char.IsUpper);
            bool hasLowercase = Password.Any(char.IsLower);
            bool hasDigit = Password.Any(char.IsDigit);

            //Β.2.γ
            foreach (char c in Password)
            {
                if (char.IsLetter(c) && !((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z')))
                {
                    return false;
                }
            }

            if (!(char.IsUpper(Password[0]) && (char.IsLetter(Password[0]))))
            {
                return false;

            }

            if (!char.IsDigit(Password[Password.Length - 1]))
            {
                return false;
            }


            return hasSymbol && hasUppercase && hasLowercase && hasDigit;
        }

        /*the conversion from characters to ASCII values and vice versa is implicitly handled by the programming language.In C#, 
         * characters are represented using the Unicode character encoding, which is an extension of ASCII. The ASCII values for characters 
         * in the basic ASCII set (32-127) align with their Unicode values.
         So, when you access a character in a C# string using indexing, like passwordChars[i], you are actually getting the Unicode 
        (and thus ASCII) value of that character.*/


        /*public string ΕncryptPassword(string Password, ref string ΕncryptedPW)
        {
            int shift = 5; // Η ολίσθηση κατά 5 θέσεις

            // Κρυπτογράφηση του κωδικού πρόσβασης
            char[] passwordChars = Password.ToCharArray();
            for (int i = 0; i < passwordChars.Length; i++)
            {
                if (passwordChars[i] >= 32 && passwordChars[i] <= 126)
                {
                    char originalChar = passwordChars[i]; // Debugging: Store the original character
                    passwordChars[i] = (char)(((passwordChars[i] - 32 + shift) % 95) + 32);

                    if (originalChar != passwordChars[i])
                    {
                        Console.WriteLine($"Character at position {i} changed: Original '{originalChar}', Encrypted '{passwordChars[i]}'");
                    }
                }
                // Αν ο χαρακτήρας δεν είναι στο εύρος, δεν γίνεται κρυπτογράφηση
            }

            ΕncryptedPW = new string(passwordChars);

            return ΕncryptedPW;
        }
        */


    }
}
