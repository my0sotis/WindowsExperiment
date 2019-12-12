using DatabaseApplication.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseApplication.ViewModels
{
    class GradeViewModel : BaseViewModel
    {
        public GradeViewModel(Grade grade)
        {
			this.grade = grade;
			var dbs = new DBService();
			course = dbs.GetCourseByCid(grade.cid);
        }

		private Course _course;

		public Course course
		{
			get { return _course; }
			set
			{
				if (_course == value) return;
				_course = value;
				OnPropertyChanged();
			}
		}

		private Grade _grade;

		public Grade grade
		{
			get { return _grade; }
			set
			{
				if (_grade == value) return;
				_grade = value;
				OnPropertyChanged();
			}
		}

	}
}
