using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerManagement.CustomException;
using WorkerManagement.Entities;

namespace WorkerManagement.DataAccessLayer
{
    public class DataWorker
    {
        CustomWorker customWorker = new CustomWorker();
        SqlConnection con = null;
        public string InsertWorker(Worker worker)
        {
            string result = null;
            con = customWorker.openConnection();
            try
            {
                string query = "insert into Worker (Worker_id, First_Name, Last_Name, Salary, Joining_Date, Department) values('"+worker.WorkerId+"', '"+ worker.FirstName +"', '"+ worker.LastName +"', '"+ worker.Salary +"', '"+ worker.JoiningDate +"', '"+ worker.Department +"')";
                SqlCommand sqlCommand = new SqlCommand(query, con);
                sqlCommand.ExecuteNonQuery();
                result = "Data Added to the database succesfully!";
                con.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Something went wrong");
                Console.WriteLine(e.Message);
            }
            return result;
        }

        public DataTable ShowWorker()
        {
            con = customWorker.openConnection();
            DataTable dataTable = new DataTable();

            try
            {
                string query = "select * from Worker;";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, con);
                DataSet dataSet = new DataSet();

                dataAdapter.Fill(dataSet);
                dataTable = dataSet.Tables[0];
                con.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Something went wrong!");
                Console.WriteLine(e.Message);
            }
            return dataTable;
        }
    }
}
