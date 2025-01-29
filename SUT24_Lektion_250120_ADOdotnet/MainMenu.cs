using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUT24_Lektion_250120_ADOdotnet
{
    internal class MainMenu
    {
        public void FrontPage()
        {
            var selections = new Selections();

            Console.WriteLine("1. Hämta alla elever \n" +
                "2. Hämta alla elever i en viss klass \n" +
                "3. Lägg till ny personal");
            int input = Int32.Parse(Console.ReadLine());
            Console.Clear();

            switch (input)
            {
                case 1:
                    ChoiceOne();
                    break;

                case 2:
                    ChoiceTwo();
                    break;

                case 3:
                    ChoiceThree();
                    break;
            }
        }

        public void ChoiceOne()
        {
            var selections = new Selections();
            Console.WriteLine("Sortera efter: \n" +
    "1. Förnamn, fallande \n" +
    "2. Förnamn, stigande \n" +
    "3. Efternamn, fallande \n" +
    "4. Efternamn, stigande \n");
            int sortInput = Int32.Parse(Console.ReadLine());
            switch (sortInput)
            {
                case 1:
                    selections.GetAllStudents("FirstName", "DESC");
                    break;
                case 2:
                    selections.GetAllStudents("FirstName", "ASC");
                    break;
                case 3:
                    selections.GetAllStudents("LastName", "DESC");
                    break;
                case 4:
                    selections.GetAllStudents("LastName", "ASC");
                    break;
            }
        }

        public void ChoiceTwo()
        {
            Console.Clear();
            var selections = new Selections();
            selections.ShowAllClasses();
            var input = Int32.Parse(Console.ReadLine());
            selections.ShowClass(input);
        }
        
        public void ChoiceThree()
        {
            Console.Clear();
            var selections = new Selections();
            Console.WriteLine("Välj ett personal ID:");
            var personnelId = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Välj ett förnamn:");
            var firstName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Välj ett efternamn:");
            var lastName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Välj arbetsroll: \n" +
                "1. Rektor\n" +
                "2. Administratör\n" +
                "3. Lärare");
            int jobInput = Int32.Parse(Console.ReadLine());


            switch (jobInput)
            {
                case 1:
                    string job = "Principal";
                    selections.AddPersonnel(personnelId, firstName, lastName, job);
                    break;
                case 2:
                    job = "Administrator";
                    selections.AddPersonnel(personnelId, firstName, lastName, job);
                    break;
                case 3:
                    job = "Teacher";
                    selections.AddPersonnel(personnelId, firstName, lastName, job);
                    break;

            }


        }
    }
}
