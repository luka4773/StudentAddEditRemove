using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsDoThis
{
    class DataAccess
    {
        private SqlConnection _connection;
        private const string ConnectionString = @"Server=(LocalDB)\v11.0;AttachDbFilename=""E:\ConstructionSemester2\LetsDoThis\LetsDoThis\StudentsDB.mdf"";Integrated Security=True;";

        public void Connect()
        {
            _connection = new SqlConnection(ConnectionString);
            _connection.Open();
        }

        private void Disconnect()
        {
            _connection.Close();
        }
    }
}
