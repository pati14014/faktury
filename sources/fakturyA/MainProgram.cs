using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace fakturyA
{
    static class MainProgram
    {
        /* Ustawienia aplikacji */
        public static void LoggIn(int id)
        {
            LoggeUserID = id;
            LoggedUser = "Edytuj mnie!";
        }
        public static string LoggedUser { get; private set; }
        public static int LoggeUserID { get; private set; }
        public static bool PermissionsLevel { get; private set; }

        /* MySQL */
        public static MySqlConnection Connection { get; set; }
        public static string DatabaseName {get; set; }

        /* okienka aplikacji */
        public static FormInvoicesList InvoiceWindow { get; set; } 
        public static FormArticles ArticlesWindow { get; set; }

        /* Listy */
        public static List<Invoice> InvoiceObjectsList { get; set; }


        public static string EditedInvoiceNumber { get; set; }
    }
}
