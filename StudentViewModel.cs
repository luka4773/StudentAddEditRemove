using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LetsDoThis.Annotations;

namespace LetsDoThis
{
    class StudentViewModel : INotifyPropertyChanged
    {
        private readonly string _currentStudentName = "CurrentStudent";
        private readonly string _listStudents = "Students";


        private Student _currentStudent;
        private List<Student> _Students;


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
