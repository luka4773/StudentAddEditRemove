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
       
        private readonly string _currentStudentName = "CurrentStudent";
        private readonly string _listStudents = "Students";

        private ObservableCollection<Student> asdasdad = new ObservableCollection<Student>(); 
        private DataAccess _access = new DataAccess();
        private Student _currentStudent;
        private List<Student> _Students;
        private ICommand _removeStudentCommand;
        private ICommand _editStudentCommand;
        private ICommand _addStudentCommand;

        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }

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
               // ObservableCollection<Student> students = new ObservableCollection<Student>();
               /* foreach (var Student in _Students)
                {
                    students.Add(Student);
                }
                */
                return asdasdad;
            }
            set
            {
                asdasdad = value;
                OnPropertyChanged("Students");
            }
        }


      
        public StudentViewModel()
        {
           
            
            
           
        /*    _Students = new List<Student>
            {
                
                
                new Student(){Name = "A", Address = "G", Age = 23},
                new Student(){Name = "B", Address = "H", Age = 21},
                new Student(){Name = "C", Address = "I", Age = 24},
                new Student(){Name = "D", Address = "J", Age = 25},
                new Student(){Name = "E", Address = "K", Age = 29},
                new Student(){Name = "F", Address = "L", Age = 27}
                
                
            };
        
         */
           Students = _access.GetStudents();
           MessageBox.Show(""+ Students.Count);
            

           // _currentStudent = _Students[0];

            _removeStudentCommand = new RelayCommand(RemoveStudentCommand) { IsEnabled = true };
            _editStudentCommand = new RelayCommand(EditStudentCommand) { IsEnabled = true };
            _addStudentCommand = new RelayCommand(AddStudentCommand) { IsEnabled = true };

        }
        

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
            _Students.Add(new Student());
            OnPropertyChanged(_listStudents);
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
