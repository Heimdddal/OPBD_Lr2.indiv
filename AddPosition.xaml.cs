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
    /// Логика взаимодействия для AddPosition.xaml
    /// </summary>
    public partial class AddPosition : Window
    {

        public AddPosition()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bool[] boolsTextBox = { PositionId.isRequired(), NamePosition.isRequired(), SalaryPosition.isRequired(), Responsibilities.isRequired(), Requirements.isRequired() };

            if (boolsTextBox.Contains(false))
            {
                MessageBox.Show("Какое то из полей заполнено непрпавильно");
                return;
            }
            else
            {
                var db = new OpbdLr22Context();
                db.Database.EnsureCreated();
                var Position = new Position 
                {
                    PositionId = Convert.ToInt64(PositionId.Text), 
                    PositionName = NamePosition.Text,
                    Salary = Convert.ToInt16(SalaryPosition.Text),
                    Responsibilities = Responsibilities.Text, 
                    Requirements = Requirements.Text 
                };
                db.Positions.Add(Position);
                db.SaveChanges();
                this.Close();

            }
        }
    }
}
