using Microsoft.Data.SqlClient;

namespace SUT24_Lektion_250120_ADOdotnet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var mainMenu = new MainMenu();
            mainMenu.FrontPage();
        }
    }
}
