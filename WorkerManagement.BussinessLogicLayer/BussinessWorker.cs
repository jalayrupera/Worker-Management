using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using WorkerManagement.DataAccessLayer;
using WorkerManagement.Entities;

namespace WorkerManagement.BussinessLogicLayer
{
    public class BussinessWorker
    {
        DataWorker dataWorker = null;

        public string AddWorker(Worker worker)
        {
            dataWorker = new DataWorker();
            string result = dataWorker.InsertWorker(worker);
            return result;
        }

        public DataTable ShowWorker()
        {
            dataWorker = new DataWorker();
            return dataWorker.ShowWorker();
        }
    }
}
