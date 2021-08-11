using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerManagement.Entities
{
    public class Worker
    {
        private int _WorkerId;
        private string _FirstName;
        private string _LastName;
        private long _Salary;
        private string _JoiningDate;
        private string _Department;

        public int WorkerId
        {
            get
            {
                return _WorkerId;
            }
            set
            {
                _WorkerId = value;
            }
        }

        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                _FirstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value;
            }
        }

        public long Salary
        {
            get
            {
                return _Salary;
            }
            set
            {
                _Salary = value;
            }
        }

        public string JoiningDate
        {
            get
            {
                return _JoiningDate;
            }
            set
            {
                _JoiningDate = value;
            }
        }

        public string Department
        {
            get
            {
                return _Department;
            }
            set
            {
                _Department = value;
            }
        }
    }
}
