using DatabaseApplication.Command;
using DatabaseApplication.DataBase;
using DatabaseApplication.Models;
using DatabaseApplication.UserControls;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace DatabaseApplication.ViewModels
{
    internal class ChooseCoursePageViewModel : BaseViewModel
    {
        public ChooseCoursePageViewModel(Student student)
        {
            this.student = student;
            var db = new DBService();
            List<Course> courses = db.GetAllCourses();
            Courses = new ObservableCollection<SelectableViewModel>();
            SelectedCourse = new ObservableCollection<BriefCourse>();
            foreach (var course in courses)
                Courses.Add(new SelectableViewModel(course));

            AddCommand = new CommandImplementation(Add);
            SubmitCommand = new CommandImplementation(SubmitAsync);
        }

        public ICommand AddCommand { get; set; }
        public ICommand SubmitCommand { get; set; }

        private void Add(object obj)
        {
            SelectedCourse.Clear();
            var targets = GetSelectedCourses();
            foreach (var target in targets)
            {
                if (!CheckExist(target))
                {
                    SelectedCourse.Add(new BriefCourse(target.SelectCourse));
                }
            }
        }

        private async void SubmitAsync(object obj)
        {
            ConfirmDialog samMessageDialog = new ConfirmDialog
            {
                Message = { Text = "Do you really want to choose these courses?" }
            };
            var result = await DialogHost.Show(samMessageDialog);
            if (Equals(result, true))
            {
                DBService dbs = new DBService();
                string errorString = "";
                int errorNum = 0;
                string dupString = "";
                int dupNum = 0;
                if (SelectedCourse.Count() == 0)
                {
                    ShowMessageInfo("You did not choose any courses");
                    return;
                }
                for (int i = 0; i < SelectedCourse.Count(); i++)
                {
                    BriefCourse course = SelectedCourse[i];
                    if (dbs.CheckDuplicate(course.course, student))
                    {
                        dupNum++;
                        dupString += course.course.cname + " ";
                    }
                    else
                    {
                        if (dbs.CheckRemained(course.course))
                        {
                            dbs.Add(new Grade(student.sid, course.course.cid));
                            var c = course.course;
                            c.exist -= 1;
                            dbs.Update(c);
                            SelectedCourse.Remove(course);
                        }
                        else
                        {
                            errorNum++;
                            errorString += course.course.cname + " ";
                        }
                    }
                }
                if (errorNum != 0 || dupNum != 0)
                {
                    string info = "";
                    if (dupNum != 0)
                    {
                        info += "There are " + dupNum
                        + " courses which you have chosen. Please choose others. They are " + dupString + ".";
                    }
                    if (errorNum != 0)
                    {
                        info += "There are " + errorNum
                        + " courses having been full. Please choose others. They are " + errorString + ".";
                    }
                    ShowMessageInfo(info);
                }
                else
                {
                    ShowMessageInfo("Course selection successful!");
                }
                ResetSelect();
            }
        }

        private Student student;

        private void ResetSelect()
        {
            foreach (var item in Courses)
            {
                item.IsSelected = false;
            }
        }

        private bool CheckExist(SelectableViewModel target)
        {
            foreach (var item in SelectedCourse)
            {
                if (item.course.cid == target.SelectCourse.cid)
                {
                    return true;
                }
            }
            return false;
        }

        private List<SelectableViewModel> GetSelectedCourses()
        {
            List<SelectableViewModel> res = new List<SelectableViewModel>();
            foreach (var course in Courses)
            {
                if (course.IsSelected)
                {
                    res.Add(course);
                }
            }
            return res;
        }

        public ObservableCollection<SelectableViewModel> Courses { get; set; }

        private ObservableCollection<BriefCourse> _SelectedCourse;

        public ObservableCollection<BriefCourse> SelectedCourse
        {
            get { return _SelectedCourse; }
            set
            {
                if (_SelectedCourse == value) return;
                _SelectedCourse = value;
            }
        }

        private async void ShowMessageInfo(string message)
        {
            MessageDialog samMessageDialog = new MessageDialog
            {
                Message = { Text = message }
            };
            await DialogHost.Show(samMessageDialog);
        }
    }
}