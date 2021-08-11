using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerManagement.CustomException
{
    public class CustomWorker
    {

        public SqlConnection openConnection()
        {
            SqlConnection con = null;
            string cm = ConfigurationManager.ConnectionStrings["SchoolDB"].ConnectionString;
            try
            {
                con = new SqlConnection(cm);
                Console.WriteLine("Connected to the database");
                con.Open();
                Console.WriteLine("Connection is Open");
            }
            catch(Exception e)
            {
                Console.WriteLine("Something wrong went with the connection!");
                Console.WriteLine(e.StackTrace.ToString());
            }
            return con;
        }

    }
}
