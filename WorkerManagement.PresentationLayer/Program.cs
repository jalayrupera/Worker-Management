using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerManagement.Entities;
using WorkerManagement.BussinessLogicLayer;
using System.Data;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace WorkerManagement.PresentationLayer
{
    class Program
    {
        List<Worker> listWorkers = new List<Worker>();

        public static void Main(string[] args)
        {
            List<Worker> listofWorkers;
            Console.Write("Enter the number of Worker: ");
            int num = Int32.Parse(Console.ReadLine());
            PopulateWorker(num);

            ShowWorkers();
            listofWorkers = SortWorkers();

            Serialize(listofWorkers);
            DeSerialize();
            Console.ReadLine();
        }

        public static void PopulateWorker(int num)
        {
            BussinessWorker bussinessWorker = new BussinessWorker();
            Worker worker = new Worker();
            WorkerRepository workerRepository = new WorkerRepository();

            for (int i = 0; i < num; i++)
            {
                Console.Write("Enter the WorkerId: ");
                worker.WorkerId = Int32.Parse(Console.ReadLine());
                Console.Write("Enter the Worker Firstname: ");
                worker.FirstName = Console.ReadLine().ToString();
                Console.Write("Enter the Worker Lastname: ");
                worker.LastName = Console.ReadLine().ToString();
                Console.Write("Enter the Worker Salary: ");
                worker.Salary = Int64.Parse(Console.ReadLine());
                Console.Write("Enter the Worker Joining Date(YYYY-MM-DD): ");
                worker.JoiningDate = Console.ReadLine().ToString();
                Console.Write("Enter the Worker Department: ");
                worker.Department = Console.ReadLine().ToString();
                workerRepository.AddWorker(worker);
                Console.WriteLine(bussinessWorker.AddWorker(worker));
            }
        }

        public static void ShowWorkers()
        {
            BussinessWorker bussinessWorker = new BussinessWorker();
            DataTable dataTable = bussinessWorker.ShowWorker();

            WorkerRepository workerRepository = new WorkerRepository();


            Console.WriteLine("The table content is: ");
            Console.WriteLine("Worker Id" + " " + "First Name" + " " + "Last Name" + " " + "Salary" + " " + "Joining Date" + " " + "Department");
            foreach (DataRow dataRow in dataTable.Rows)
            {
                Console.WriteLine(dataRow["Worker_Id"] + " " + dataRow["First_Name"] + " " + dataRow["Last_Name"] + " " + dataRow["Salary"] + " " + dataRow["Joining_Date"] + " " + dataRow["Department"]);
            }
            
        }

        public static List<Worker> SortWorkers()
        {
            BussinessWorker bussinessWorker = new BussinessWorker();
            WorkerRepository workerRepository = new WorkerRepository();

            DataTable dataTable = bussinessWorker.ShowWorker();
            List<Worker> listWorkers = new List<Worker>();
            List<Worker> sortedWorkers;

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Worker worker = new Worker();
                worker.WorkerId = Convert.ToInt32(dataRow[0]);
                worker.FirstName = dataRow[1].ToString();
                worker.LastName = dataRow[2].ToString();
                worker.Salary = Convert.ToInt64(dataRow[3]);
                worker.JoiningDate = dataRow[4].ToString();
                worker.Department = dataRow[5].ToString();

                listWorkers.Add(worker);
            }

            sortedWorkers = workerRepository.SortByName(listWorkers);


            Console.WriteLine("Sorted list of Worker table");
            foreach (var worker in sortedWorkers)
            {
                Console.WriteLine(worker.FirstName + "\t" + worker.LastName);
            }
            return listWorkers;
        }

        public static void Serialize(List<Worker> listofWorkers)
        {
            GenericSerialize<Worker>(listofWorkers);
        }

        public static void GenericSerialize<T> (List<Worker> listofWorkers)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            TextWriter tw = new StreamWriter(@"C:\Users\Jalay Rupera\source\repos\WorkerManagement\WorkerManagement.PresentationLayer\Worker.xml");
            serializer.Serialize(tw, listofWorkers);
            tw.Close();
        }

        public static void DeSerialize()
        {
            List<Worker> workers = GenericDeSerialize<Worker>();

            foreach (Worker worker in workers)
            {
                Console.WriteLine(worker.FirstName);
                Console.WriteLine(worker.LastName);
            }
        }

        public static List<T> GenericDeSerialize<T>()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            TextReader tr = new StreamReader("Worker.xml");
            List<T> b = (List<T>)serializer.Deserialize(tr);
            tr.Close();
            return b;
        }
    }
}
