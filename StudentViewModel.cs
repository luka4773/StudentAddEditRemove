using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using LetsDoThis.Annotations;


namespace LetsDoThis
{
    class StudentViewModel : INotifyPropertyChanged
    {
       
        private readonly string _currentStudentName = "CurrentStudent";
        private readonly string _listStudents = "Students";


        private Student _currentStudent;
        private List<Student> _Students;
        private RelayCommand _removeStudentCommand;

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


        public RelayCommand RemoveStudent
        {
            get { return _removeStudentCommand; }
        }
        public ObservableCollection<Student> Students
        {
            get
            {
                ObservableCollection<Student> students = new ObservableCollection<Student>();
                foreach (var Student in _Students)
                {
                    students.Add(Student);
                }
                return students;
            }
        }



        public StudentViewModel()
        {
            _Students = new List<Student>()
            {
                new Student(){Name = "asadd", Address = "asqedad", Age = 23},
                new Student(){Name = "asd", Address = "adsgsdad", Age = 23},
                new Student(){Name = "asdads", Address = "asxvdad", Age = 23},
                new Student(){Name = "adwdasd", Address = "asdad", Age = 23},
                new Student(){Name = "asadsd", Address = "asdafeqad", Age = 23},
                new Student(){Name = "asadsd", Address = "asdafeqad", Age = 23}

            };



            _currentStudent = _Students[0];

            _removeStudentCommand = new RelayCommand(RemoveStudentCommand){ IsEnabled = true };
        }

        private void RemoveStudentCommand()
        {
            _Students.Remove(_currentStudent);
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
