using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HRLibSDLL
{
    public class HRLibSDLL
    {
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
            if (string.IsNullOrEmpty(Name))
            {
                return false;
            }

            if (!Regex.IsMatch(Name, @"^[A-Za-z\s]+$"))
            {
                return false;
            }

            /*int wordCount = Name.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
            if (wordCount < 2)
            {
                return false;
            }*/

            return true;

        }

        //Ερώτημα Β.2
        public bool ValidPassword(string Password)
        {
            //Β.2.α Εξετάζω εάν έχει τουλάχιστον 12 αριθμούς
            /*if (Password.Length < 12)
            {
                return false;
            }*/

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


        public void EncryptPassword(string password, ref string encryptedPW)
        {
            int shift = 6;
            StringBuilder EncryptedPassword = new StringBuilder();

            foreach (char c in password)
            {
                char encryptedChar = c;

  
                if (c >= 32 && c <= 126)
                {
    
                    encryptedChar = (char)(c + shift);

                    if (encryptedChar > 126)
                    {
                        encryptedChar = (char)(encryptedChar - 95);
                    }
                }

                EncryptedPassword.Append(encryptedChar);
            }

            encryptedPW = EncryptedPassword.ToString();
        }

        public void CheckPhone(string Phone, ref int TypePhone, ref string InfoPhone)
        {
            if (Phone.Length == 10)
            {
                string numberString = Phone.ToString();
                string pattern1 = @"^2[0-9][0-9]{8}$";
                Boolean HomeNumber = Regex.IsMatch(Phone, pattern1);
                string peraeus = @"^21[0-9]{8}$";
                string attica = @"^22[0-9]{8}$";
                string centralMacedonia = @"^23[0-9]{8}$";
                string thessalia_WestMacedonia = @"^24[0-9]{8}$";
                string thrakh_EastMacedonia = @"^25[0-9]{8}$";
                string Epirus_WesternCentralGreece_WesternPeloponnese_IonianIslands = @"^26[0-9]{8}$";
                string easternPeloponnese_Kythira = @"^27[0-9]{8}$";
                string crete = @"^28[0-9]{8}$";

                bool isPeraeus = Regex.IsMatch(Phone, peraeus);
                bool isAttica = Regex.IsMatch(Phone, attica);
                bool isCentralMacedonia = Regex.IsMatch(Phone, centralMacedonia);
                bool isThessalia_WestMacedonia = Regex.IsMatch(Phone, thessalia_WestMacedonia);
                bool isThrakh_EastMacedonia = Regex.IsMatch(Phone, thrakh_EastMacedonia);
                bool isEpirus_WesternCentralGreece_WesternPeloponnese_IonianIslands = Regex.IsMatch(Phone, Epirus_WesternCentralGreece_WesternPeloponnese_IonianIslands);
                bool isEasternPeloponnese_Kythira = Regex.IsMatch(Phone, easternPeloponnese_Kythira);
                bool isCrete = Regex.IsMatch(Phone, crete);


                string novaPattern = @"^69[069][0-9]{7}$";
                string vodafonePattern = @"^69[45][0-9]{7}$";
                string cosmotePattern = @"^69[8][0-9]{7}$";

                bool isNova = Regex.IsMatch(Phone, novaPattern);
                bool isVodafone = Regex.IsMatch(Phone, vodafonePattern);
                bool isCosmote = Regex.IsMatch(Phone, cosmotePattern);

                if (HomeNumber)
                {
                    TypePhone = 0;
                    Console.WriteLine("This is a home number.");
                    if (isPeraeus)
                    {
                        InfoPhone = "Ζώνη21.ΜητροπολιτικήΠεριοχήΑθήνας–Πειραιά";
                    }
                    else if (isAttica)
                    {

                        InfoPhone = "Ζώνη22.ΑνατολικήΣτερεάΕλλάδα,Αττική,ΝησιάΑιγαίου";

                    }
                    else if (isCentralMacedonia)
                    {

                        InfoPhone = "Ζώνη23.ΚεντρικήΜακεδονία";

                    }
                    else if (isThessalia_WestMacedonia)
                    {

                        InfoPhone = "Ζώνη24.Θεσσαλία,ΔυτικήΜακεδονία";

                    }
                    else if (isThrakh_EastMacedonia)
                    {
                        InfoPhone = "Ζώνη25.Θράκη,ΑνατολικήΜακεδονία";

                    }
                    else if (isEpirus_WesternCentralGreece_WesternPeloponnese_IonianIslands)
                    {

                        InfoPhone = "Ζώνη26.Ήπειρος,ΔυτικήΣτερεάΕλλάδα,ΔυτικήΠελοπόννησος,Ιόνια Νησιά";

                    }
                    else if (isEasternPeloponnese_Kythira)
                    {
                        Console.WriteLine("Ζώνη 27. Ανατολική Πελοπόννησος, Κύθηρα");
                        InfoPhone = "Ζώνη27.ΑνατολικήΠελοπόννησος,Κύθηρα";

                    }
                    else if (isCrete)
                    {
                        Console.WriteLine("Ζώνη28. Κρήτη");

                        InfoPhone = "Ζώνη 28.Κρήτη";

                    }
                }
                else if (isNova || isVodafone || isCosmote)
                {
                    TypePhone = 1;
                    Console.WriteLine("This is a mobile number.");
                    if (isNova)
                    {
                        Console.WriteLine("NOVA");
                        InfoPhone = "NOVA";
                    }
                    else if (isVodafone)
                    {

                        Console.WriteLine("VODAFONE");
                        InfoPhone = "VODAFONE";

                    }
                    else if (isCosmote)
                    {
                        Console.WriteLine("COSMOTE");
                        InfoPhone = "COSMOTE";

                    }
                }
                else
                {
                    TypePhone = -1;
                    InfoPhone = null;
                    Console.WriteLine("This is not a valid number.");

                }

            }
            else
            {

                TypePhone = -1;
                InfoPhone = null;
                Console.WriteLine("Invalid phone number length.");

            }

        }

        public void InfoEmployee(Employee EmplX, ref int Age, ref int YearsOfExperience)
        {

            DateTime currentDate = DateTime.Now;
            Age = currentDate.Year - EmplX.Birthday.Year;


            if (EmplX.Birthday.Date > currentDate.AddYears(-Age))
            {
                Age--;
            }


            YearsOfExperience = currentDate.Year - EmplX.HiringDate.Year;

            if (EmplX.HiringDate.Date > currentDate.AddYears(-YearsOfExperience))
            {
                YearsOfExperience--;
            }

        }

        public int LiveInAthens(Employee[] Empls)
        {

            int numberOfEmployeesInAthens = 0;

            foreach (Employee employee in Empls)
            {
                string phone = employee.HomePhone;
   
                int phoneType = -1; 
                string info = null;

                CheckPhone(phone, ref phoneType, ref info);

                if (phoneType == 0 && info == "Ζώνη21.ΜητροπολιτικήΠεριοχήΑθήνας–Πειραιά")
                {
                    numberOfEmployeesInAthens++;
                }
            }

            return numberOfEmployeesInAthens;
        }

    }
}
