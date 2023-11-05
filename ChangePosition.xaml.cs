using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
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
    /// Логика взаимодействия для ChangePosition.xaml
    /// </summary>
    public partial class ChangePosition : Window
    {
        public long ID { get; set; }

        public ChangePosition(long id)
        {
            InitializeComponent();

            ID = id;

            using (var db = new OpbdLr22Context())
            {
                var position = db.Positions.Find(ID);

                if (position == null)
                {
                    MessageBox.Show("Запись не найдена");
                    return;
                }

                NamePosition.Text = position.PositionName;
                SalaryPosition.Text = position.Salary.ToString();
                Responsibilities.Text = position.Responsibilities;
                Requirements.Text = position.Requirements;

            }
        }

        private void ChangePositon_Click(object sender, RoutedEventArgs e)
        {
            bool[] boolsTextBox = { NamePosition.isRequired(),
                SalaryPosition.isRequired(), Responsibilities.isRequired(), Requirements.isRequired() };

            if (boolsTextBox.Contains(false))
            {
                MessageBox.Show("Некоторые поля заполнены неправильно");
                return;
            }
            else
            {
                using (var db = new OpbdLr22Context())
                {
                    db.Database.EnsureCreated();

                    var position = db.Positions.Find(ID);

                    if (position == null)
                    {
                        MessageBox.Show("Запись не найдена");
                        return;
                    }
                    else
                    {
                        position.PositionName = NamePosition.Text;
                        position.Salary = Convert.ToInt64(SalaryPosition.Text);
                        position.Responsibilities = Responsibilities.Text;
                        position.Requirements = Requirements.Text;

                    }

                    db.Positions.Update(position);
                    db.SaveChanges();
                    this.Close();
                }

            }
        }

        private void Close_window(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
