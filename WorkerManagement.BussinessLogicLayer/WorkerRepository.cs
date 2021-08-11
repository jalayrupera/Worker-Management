using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using WorkerManagement.Entities;

namespace WorkerManagement.BussinessLogicLayer
{
    public class WorkerRepository
    {
        List<Worker> workers = new List<Worker>();

        public void AddWorker(Worker worker)
        {

            workers.Add(worker);
        }

        public List<Worker> SortByName(List<Worker> listWorker)
        {
            return listWorker.OrderBy(e => e.FirstName).ToList();
        }
    }
}
