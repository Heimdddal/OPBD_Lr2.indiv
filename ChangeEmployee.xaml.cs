using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OPBD_Lr2.indiv
{
    /// <summary>
    /// Логика взаимодействия для ChangeEmployee.xaml
    /// </summary>
    public partial class ChangeEmployee : Window
    {
        public long ID { get; set; }

        public ChangeEmployee(long id)
        {
            InitializeComponent();

            ID = id;

            using (var db = new OpbdLr22Context())
            {
                var employee = db.Employees.Find(ID);

                SNameEmployee.Text = employee.SecondName;
                NameEmployee.Text = employee.FirstName;
                PatronymicEmployee.Text = employee.Patronymic;
                BirthDateEmployee.Text = employee.BirthDate;
                Gender.Text = employee.Gender;
                Address.Text = employee.Address;
                PhoneNumber.Text = employee.PhoneNumber;
                PassportSeries.Text = employee.PassportSeries;
                PassportNumber.Text = employee.PassportNumber;
                PositionId.Text = employee.PositionId.ToString();
            }
        }

        private void ChangeEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            bool[] textBoxBool = { SNameEmployee.isRequired(), NameEmployee.isRequired(), PassportSeries.isLenghtCorrect(),
                PassportNumber.isLenghtCorrect(), PositionId.isRequired() };

            if (textBoxBool.Contains(false))
            {
                MessageBox.Show("Какое то из полей заполнено непрпавильно");
                return;
            }
            else
            {
                using (var db = new OpbdLr22Context())
                {
                    db.Database.EnsureCreated();

                    var employee = db.Employees.Find(ID);

                    if (employee == null)
                    {
                        MessageBox.Show("Запись не найдена");
                        return;
                    }
                    else
                    {
                        employee.SecondName = SNameEmployee.Text;
                        employee.FirstName = NameEmployee.Text;
                        employee.Patronymic = PatronymicEmployee.Text;
                        employee.BirthDate = BirthDateEmployee.Text;
                        employee.Gender = Gender.Text;
                        employee.Address = Address.Text;
                        employee.PhoneNumber = PhoneNumber.Text;
                        employee.PassportSeries = PassportSeries.Text;
                        employee.PassportNumber = PassportNumber.Text;
                        employee.PositionId = Convert.ToInt64(PositionId.Text);

                    }

                    db.Employees.Update(employee);
                    db.SaveChanges();
                    this.Close();
                }
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
