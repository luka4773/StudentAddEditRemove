using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using LetsDoThis.Annotations;


namespace LetsDoThis
{
    class StudentViewModel : INotifyPropertyChanged
    {
        private string _name;
        private string _address;
        private int _age;
        private readonly string _currentStudentName = "CurrentStudent";
        private readonly string _listStudents = "Students";

        private ObservableCollection<Student> _getStudents = new ObservableCollection<Student>(); 
        private DataAccess _access = new DataAccess();
        private Student _currentStudent;
        private List<Student> _Students;
        private ICommand _removeStudentCommand;
        private ICommand _editStudentCommand;
        private ICommand _addStudentCommand;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged("Address");
            }
        }
        public int Age
        {
          get { return _age; }
            set
            {
                _age = value; 
                OnPropertyChanged("Age");
            } 
        }

        public Student CurrentStudent
        {
            get { return _currentStudent; }
            set
            {
                if (value != _currentStudent)
                {
                    _currentStudent = value;
                    OnPropertyChanged(_currentStudentName);
                }
            } 
        }

        

        public ICommand AddStudent
        {
            get { return _addStudentCommand; }
        }

        public ICommand EditStudent
        {
            get { return _editStudentCommand; }
        }

        public ICommand RemoveStudent
        {
            get { return _removeStudentCommand; }
        }
        public ObservableCollection<Student> Students
        {
            get
            {
             
                return _getStudents;
            }
            set
            {
                _getStudents = value;
                OnPropertyChanged("Students");
            }
        }


      //ctor
        public StudentViewModel()
        {
           
            
      
           Students = _access.GetStudents();
           MessageBox.Show(""+ Students.Count);
            

            _currentStudent = Students[0];

            _removeStudentCommand = new RelayCommand(RemoveStudentCommand) { IsEnabled = true };
            _editStudentCommand = new RelayCommand(EditStudentCommand) { IsEnabled = true };
            _addStudentCommand = new RelayCommand(AddStudentCommand) { IsEnabled = true };

        }
        
        //Icommands for add/remove/edit - not working 1oo% yet
        private void RemoveStudentCommand()
        {
            _Students.Remove(_currentStudent);
            OnPropertyChanged(_listStudents);
        }

        private void EditStudentCommand()
        {
            _Students.Add(_currentStudent);
            _Students.Remove(_currentStudent);
            OnPropertyChanged(_listStudents);
        }

        private void AddStudentCommand()
        {
            var s = new Student
            {
                Name = Name,
                Age = Age,
                Address = Address
            };
            _access.AddStudent(s);
            
        }
       
      

        #region InotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
