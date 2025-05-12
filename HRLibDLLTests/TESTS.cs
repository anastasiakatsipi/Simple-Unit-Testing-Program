using Microsoft.VisualStudio.TestTools.UnitTesting;
using HRLibSDLL;
using System;
using System.Security.Policy;
using static HRLibSDLL.HRLibSDLL;

namespace HRLibDLLTests
{
    [TestClass]
    public class TESTS
    {
        [TestMethod]
        public void ValidName()
        {

            HRLibSDLL.HRLibSDLL hl = new HRLibSDLL.HRLibSDLL();

            //Δημιουργία Περιπτώσεων Ελέγχου
            object[,] testcases =
            {
                { 1, "John Doe", true, "Valid name" },
                { 2, null, false, "Null input" },
                { 3, "John123", false, "Invalid characters" },
                { 4, "John", false, "Should be more than one word!" },
                { 5, "Maria Dollores Ermoza", true, "Valid Name" },


            };

            // Act & Assert
            for (int i = 0; i < testcases.GetLength(0); i++)
            {
                try
                {
                    // Arrange
                    string input = (string)testcases[i, 1];
                    bool expectedResult = (bool)testcases[i, 2];

                    // Act
                    bool result = hl.ValidName(input);

                    // Assert
                    Assert.AreEqual(expectedResult, result, $"Test Case {testcases[i, 0]} failed. Reason: {testcases[i, 3]}");
                }
                catch (AssertFailedException e)
                {
                    // Log failure
                    Console.WriteLine($"Failed Test Case: {testcases[i, 0]} - {e.Message}");
                    throw; // Re-throw exception to mark the test as failed
                }
            }
        }

        [TestMethod]
        public void ValidPassword()
        {
            
            HRLibSDLL.HRLibSDLL hl = new HRLibSDLL.HRLibSDLL();

            //Δημιουργία Περιπτώσεων Ελέγχου
            object[,] testcases =
            {
                { 1, "SDFGHgfyrsFF_43566789gfdstjf3", true, "Valid Password" },
                { 2, "sDFGyrsFF_3566789gfdstjf3", false, "Starts with small character" },
                { 3, "SDFGHgμsFF_43566789gfdstjf3", false, "Only latin characters accepted" },
                { 4, "SDFGHgμsFF_43566789gfdstjf", false, "Doesnt end with number" },
                { 5, "SDFGHgμsFF43566789gfdstjf", false, "Doesnt have special character" },
                { 6, "SDFG_66tjf4", false, "Should be more that 11 characters" },



            };

            // Act & Assert
            for (int i = 0; i < testcases.GetLength(0); i++)
            {
                try
                {
                    // Arrange
                    string input = (string)testcases[i, 1];
                    bool expectedResult = (bool)testcases[i, 2];

                    // Act
                    bool result = hl.ValidPassword(input);

                    // Assert
                    Assert.AreEqual(expectedResult, result, $"Test Case {testcases[i, 0]} failed. Reason: {testcases[i, 3]}");
                }
                catch (AssertFailedException e)
                {
                    // Log failure
                    Console.WriteLine($"Failed Test Case: {testcases[i, 0]} - {e.Message}");
                    throw; 
                }
            }
        }

        [TestMethod]
        public void EncryptPassword_ShouldEncryptPasswords()
        {
            // Arrange
            HRLibSDLL.HRLibSDLL hl = new HRLibSDLL.HRLibSDLL();

            var testCases = new (int, string, string,  string)[]
            {
            (1, "ABCD10", "FGHI65", "Correct encryption"),
            (2, "abcd10", "fghi65", "Correct encryption"),
            (3, "abcd10", "abcd10",  "The password stays the same!"),
            
            };

            // Act & Assert
            for (int i = 0; i < testCases.GetLength(0); i++)
            {
                try
                {
                    // Arrange
                    string input = (string)testCases[i].Item2;
                    string expectedResult = (string)testCases[i].Item3;

                    // Act
                    string encryptedPassword = string.Empty;
                    hl.EncryptPassword(input, ref encryptedPassword);

                    // Assert
                    Assert.AreEqual(expectedResult, encryptedPassword);
                }
                catch (AssertFailedException e)
                {
                    // Log failure
                    Console.WriteLine($"Failed Test Case: {testCases[i].Item1} - {e.Message}");
                    throw; 
                }
            }
        }


        [TestMethod]
        public void CheckPhone_should()
        {
            // Arrange
            HRLibSDLL.HRLibSDLL hl = new HRLibSDLL.HRLibSDLL();

            var testCases = new (int, string, int, string, string)[]
            {
            (1, "2104009764", 0, "Ζώνη21.ΜητροπολιτικήΠεριοχήΑθήνας–Πειραιά", "Correct number"),
            (2, "2104764", -1, null, "Correct number"),
            (3, "6947446196", 1, "VODAFONE", "Correct number"),
            (4, "6977446196", 1, "COSMOTE", "Correct number"),
            (5, "2304009764", 0, "Ζώνη23.ΚεντρικήΜακεδονία", "Correct number"),


            };

            // Act & Assert
            for (int i = 0; i < testCases.GetLength(0); i++)
            {
                try
                {
                    // Arrange
                    string input = (string)testCases[i].Item2;
                    int expectedTypePhone = (int)testCases[i].Item3;
                    string expectedInfoPhone = (string)testCases[i].Item4;

                    // Act
                    string infoPhone = string.Empty;
                    int typePhone = int.MinValue;
                    hl.CheckPhone(input, ref typePhone, ref infoPhone);

                    // Assert
                    Assert.AreEqual(expectedTypePhone, typePhone, $"Test Case {testCases[i].Item1} - Type of phone is not as expected");
                    Assert.AreEqual(expectedInfoPhone, infoPhone, $"Test Case {testCases[i].Item1} - Info about the phone is not as expected");
                }
                catch (AssertFailedException e)
                {
                   
                    Console.WriteLine($"Failed Test Case: {testCases[i].Item1} - {e.Message}");
                    throw; 
                }
            }
        }


        [TestMethod]
        public void InfoEmployee_CalculateAgeAndExperience_Success()
        {
            // Arrange
            HRLibSDLL.HRLibSDLL library = new HRLibSDLL.HRLibSDLL();

            var testCases = new (int, string, string, string, DateTime, DateTime, int, int)[]
            {
            (1, "John Doe", "1234567890", "9876543210", new DateTime(1990, 1, 15), new DateTime(2010, 3, 1), 34, 14),
            (2, "Jane Smith", "5551234567", "9998887777", new DateTime(1985, 5, 20), new DateTime(2012, 8, 10), 38, 11),
            (3, "Lana Del Rey", "5551262567", "9998882377", new DateTime(1983, 2, 20), new DateTime(2015, 8, 10), 41, 8),



            };

            // Act & Assert
            for (int i = 0; i < testCases.GetLength(0); i++)
            {
                try
                {
                    // Arrange
                    Employee employee = new Employee(testCases[i].Item2, testCases[i].Item3, testCases[i].Item4, testCases[i].Item5, testCases[i].Item6);

                    // Act
                    int age = 0;
                    int yearsOfExperience = 0;
                    library.InfoEmployee(employee, ref age, ref yearsOfExperience);

                    // Assert
                    Assert.AreEqual(testCases[i].Item7, age, $"Age is not as expected for employee {testCases[i].Item2}");
                    Assert.AreEqual(testCases[i].Item8, yearsOfExperience, $"Years of experience is not as expected for employee {testCases[i].Item2}");
                }
                catch (AssertFailedException e)
                {
                    // Log failure
                    Console.WriteLine($"Failed Test Case: {testCases[i].Item1} - {e.Message}");
                    throw;
                }
            }
        }

            [TestMethod]
        public void LiveInAthens_ReturnsCorrectNumberOfEmployees()
        {
            // Arrange
            HRLibSDLL.HRLibSDLL library = new HRLibSDLL.HRLibSDLL();

            Employee[] employees0 = new Employee[]
            {
                new Employee("John Doe", "2452345678", "69453458901", new DateTime(1985, 1, 15), new DateTime(2010, 3, 1)),
                new Employee("Sam Smith", "2104009764", "6954277098", new DateTime(1990, 5, 10), new DateTime(2015, 7, 20)),
            };

            Employee[] employees1 = new Employee[]
            {
                new Employee("Margaret Luck", "2104009768", "6945629321", new DateTime(1960, 9, 18), new DateTime(2015, 6, 17)),
                new Employee("Jane Sparrow", "2109876543", "6951266098", new DateTime(1999, 8, 10), new DateTime(2012, 2, 25)),
            };

            Employee[] employees2 = new Employee[]
            {
                new Employee("Maria Dolorez", "2348264738", "6945678901", new DateTime(1975, 1, 28), new DateTime(2020, 3, 11)),
                new Employee("Nick Kayanas", "2228473848", "6952384928", new DateTime(1976, 5, 2), new DateTime(2019, 7, 23)),
            };

            var testCases = new (int, Employee[], int)[] 
            {
                (1, employees0, 1),
                (2, employees1, 2),
                (3, employees2, 0),

            };

            // Act & Assert
            for (int i = 0; i < testCases.GetLength(0); i++)
            {
                try
                {
                    // Act
                    int numberOfEmployeesInAthens = library.LiveInAthens(testCases[i].Item2); 

                    // Assert
                    Assert.AreEqual(testCases[i].Item3, numberOfEmployeesInAthens);

                }
                catch (AssertFailedException e)
                {
                    // Log failure
                    Console.WriteLine($"Failed Test Case: {testCases[i].Item1} - {e.Message}");
                    throw; 
                }
            }
        }
    }
}
