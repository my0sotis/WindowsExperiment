﻿using DatabaseApplication.DataBase;
using DatabaseApplication.Command;
using DatabaseApplication.Views;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseApplication.ViewModels
{
    class StudentMainPageViewModel
    {
        public StudentMainPageViewModel(ISnackbarMessageQueue snackbarMessageQueue, Student student)
        {
            if (snackbarMessageQueue == null) throw new ArgumentNullException(nameof(snackbarMessageQueue));
            Student = student;

            PageItems = new[]
            {
                new PageItem("Home Page", new HomePage()),
                new PageItem("Student Information", new StudentInfoPage(Student)),
                new PageItem("Choose Course", new ChooseCoursePage(Student)),
                new PageItem("Withdrawal", new WithdrawalPage(Student)),
                new PageItem("Grade", new GradePage(Student))
            };
        }

        public PageItem[] PageItems { get; }

        public Student Student;
    }
}
