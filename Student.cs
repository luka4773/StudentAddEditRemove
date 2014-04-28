using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LetsDoThis
{
    class Student
    {
        private string _name;
        private string _address;
        private int _age;


        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Address
        {
            get { return _address; } 
            set { _address = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

       
    }
}
