using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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


        public void AddStudent(Student student)
        {
            Connect();
            var command = new SqlCommand()
            {
                Connection = _connection,
                CommandType = CommandType.Text,
                CommandText = "INSERT INTO StudentTable VALUES (@Name, @Age, @Address)"
            };
            command.Parameters.Add(new SqlParameter("Name", student.Name));
            command.Parameters.Add(new SqlParameter("Age", student.Age));
            command.Parameters.Add(new SqlParameter("Address", student.Address));
            command.ExecuteNonQuery();           
            MessageBox.Show("Student added.");
            Disconnect();
        }

        public void EditStudent(Student student)
        {
            Connect();
            var command = new SqlCommand()
            {
                Connection = _connection,
                CommandType = CommandType.Text,
                CommandText = "UPDATE StudentTable SET Name = @Name, Age = @Age, Address = @Address"
            };
            command.Parameters.Add(new SqlParameter("Name", student.Name));
            command.Parameters.Add(new SqlParameter("Age", student.Age));
            command.Parameters.Add(new SqlParameter("Address", student.Address));
            command.ExecuteNonQuery();
            Disconnect();
        }

        public void RemoveStudent()
        {
            Connect();
            var command = new SqlCommand()
            {
                Connection = _connection,
                CommandType = CommandType.Text,
                CommandText = "DELETE FROM StudentTable WHERE Name = @Name"
            };
            command.Parameters.Add(new SqlParameter("Name", Student.Name));
            command.ExecuteNonQuery();
            Disconnect();
        }
       
        

        public ObservableCollection<Student> GetStudents()
        {
            Connect();
            var command = new SqlCommand
            {
                Connection = _connection,
                CommandType = CommandType.Text,
                CommandText = "SELECT * FROM StudentTable"
            };
            var reader = command.ExecuteReader();
            var collection = new ObservableCollection<Student>();
            while (reader.Read())
            {
                var student = new Student
                {
                    Name = (string)reader[0],
                    Age = (int) reader[2],
                    Address = (string)reader[1],
                };
                collection.Add(student);
            }
            Disconnect();
            return collection;
        }
       

    }


      








}
