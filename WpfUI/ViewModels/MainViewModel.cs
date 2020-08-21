using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfUI.Models;
using WpfUI.Repository;

namespace WpfUI.ViewModels
{
    class MainViewModel : Screen
    {
        private BindableCollection<EnrollmentModel> _enrollments = new BindableCollection<EnrollmentModel>();
        private BindableCollection<StudentModel> _students = new BindableCollection<StudentModel>();
        private BindableCollection<CourseModel> _courses = new BindableCollection<CourseModel>();
        private readonly string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CourseReport;Integrated Security=True";

        private string _appStatus;
        private EnrollmentModel _selectedEnrollment;
        public MainViewModel()
        {
            SelectedEnrollment = new EnrollmentModel();
            try
            {
                StudentCommand studentCommand = new StudentCommand(_connectionString);
                Students.AddRange(studentCommand.GetList());

                CourseCommand courseCommand = new CourseCommand(_connectionString);
                Courses.AddRange(courseCommand.GetList());
            }
            catch (Exception ex)
            {
                AppStatus = ex.Message;
                NotifyOfPropertyChange(() => AppStatus);
            }
        }
        public BindableCollection<CourseModel> Courses
        {
            get { return _courses; }
            set
            {
                _courses = value;
            }
        }
        public BindableCollection<StudentModel> Students
        {
            get { return _students; }
            set
            {
                _students = value;
            }
        }

        public string AppStatus
        {
            get
            {
                return _appStatus;
            }
            set
            {
                _appStatus = value;
            }
        }

        public EnrollmentModel SelectedEnrollment
        {
            get
            {
                return _selectedEnrollment;
            }
            set
            {
                _selectedEnrollment = value;
            }
        }
    }
}
