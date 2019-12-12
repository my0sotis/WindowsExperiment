using DatabaseApplication.Command;
using DatabaseApplication.DataBase;
using DatabaseApplication.UserControls;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DatabaseApplication.ViewModels
{
    class WithdrawalPageViewModel:BaseViewModel
    {
		public WithdrawalPageViewModel(Student student)
		{
			this.student = student;
			Courses = new ObservableCollection<SelectableViewModel>();
			DBService dbs = new DBService();
			grades = dbs.GetGradesByStudent(student);
			foreach (var item in grades)
			{
				Courses.Add(new SelectableViewModel(dbs.GetCourseByCid(item.cid)));
			}
			WithdrawCommand = new CommandImplementation(Withdraw);
		}

		public ICommand WithdrawCommand { set; get; }

		private List<Grade> grades;

		private async void Withdraw(object obj)
		{
			ConfirmDialog samMessageDialog = new ConfirmDialog
			{
				Message = { Text = "Do you really want to withdraw these courses? They are " + GetSelectedCourseString() }
			};
			var result = await DialogHost.Show(samMessageDialog);
			if (Equals(result, true))
			{
				var list = GetSelectedCourses();
				var dbs = new DBService();
				foreach (var item in list)
				{
					Courses.Remove(item);
					dbs.Delete(grades.Where(g => g.cid == item.SelectCourse.cid).Single());
					var c = dbs.GetCourseByCid(item.SelectCourse.cid);
					c.exist++;
					dbs.Update(c);
				}
				ShowMessageInfo("Successful withdrawal!");
			}
		}

		private readonly Student student;

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

		private string GetSelectedCourseString()
		{
			var list = GetSelectedCourses();
			string res = "";
			foreach (var item in list)
			{
				res += item.SelectCourse.cname + " ";
			}
			return res;
		}

		public ObservableCollection<SelectableViewModel> Courses { get; set; }

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
