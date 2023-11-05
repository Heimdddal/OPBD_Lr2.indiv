using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;

namespace OPBD_Lr2.indiv
{
    /// <summary>
    /// Логика взаимодействия для AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {

        public AddEmployee()
        {
            InitializeComponent();

            BirthDateEmployee.BlackoutDates.Add(new CalendarDateRange(DateTime.Today.AddYears(-18),
                             new DateTime(9999, 12, 31)));
            BirthDateEmployee.BlackoutDates.Add(new CalendarDateRange(new DateTime(1, 1, 1), DateTime.Today.AddYears(-60)));

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {

            bool[] textBoxBool = { EmployeeId.isRequired(), SNameEmployee.isRequired(), NameEmployee.isRequired(), PassportSeries.isLenghtCorrect(), 
                PassportNumber.isLenghtCorrect(), PositionId.isRequired() };


            if (textBoxBool.Contains(false))
            {
                MessageBox.Show("Какое то из полей заполнено непрпавильно");
                return;
            }
            else
            {
                var db = new OpbdLr22Context();
                db.Database.EnsureCreated();
                db.Employees.Add(new Employee
                {
                    EmployeeId = Convert.ToInt64(EmployeeId.Text),
                    SecondName = SNameEmployee.Text,
                    FirstName = NameEmployee.Text,
                    Patronymic = PatronymicEmployee.Text,
                    BirthDate = BirthDateEmployee.Text,
                    Gender = Gender.Text,
                    Address = Address.Text,
                    PhoneNumber = PhoneNumber.Text,
                    PassportSeries = PassportSeries.Text,
                    PassportNumber = PassportNumber.Text,
                    PositionId = Convert.ToInt64(PositionId.Text)
                });
                
                db.SaveChanges();
                this.Close();
            }

        }
    }
}
