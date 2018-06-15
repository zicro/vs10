using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqTest
{
    class phones {
        private int _Number;

        public int Number
        {
            get { return _Number; }
            set { _Number = value; }
        }
        
        private string _Phone;

        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
        
    }
    class employe
    {
        public employe() {
            this.Sons = null;
        }

        private int _Number;

        public int Number
        {
            get { return _Number; }
            set { _Number = value; }
        }

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _City;

        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        private int _Salary;

        public int Salary
        {
            get { return _Salary; }
            set { _Salary = value; }
        }

        private string[] _Sons;

        public string[] Sons
        {
            get { return _Sons; }
            set { _Sons = value; }
        }
        
        
        
    }
}
