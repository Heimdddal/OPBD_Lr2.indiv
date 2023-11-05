using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OPBD_Lr2.indiv
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Load();
        }


        public void Load()
        {
            var db = new OpbdLr22Context();
            
            var employees = db.Employees.ToList();
            EmployeeData.ItemsSource = employees;

            var positions = db.Positions.ToList();
            PositionData.ItemsSource = positions;

            var manufacturer = db.Manufacturers.ToList();
            ManufacturerData.ItemsSource = manufacturer;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch ((Tables.SelectedItem as TabItem).Name)
            {
                case "Employee":
                    var addEmployee = new AddEmployee();
                    addEmployee.Owner = this;
                    addEmployee.Show();
                    break;
                case "Position":
                    var addPosition = new AddPosition();
                    addPosition.Owner = this;
                    addPosition.Show();
                    break;
                case "Manufacturer":
                    var addManufacturer = new AddManufacturer();
                    addManufacturer.Owner = this;
                    addManufacturer.Show();
                    break;
                default:
                    break;
            }

            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Load();
        }

        private void EmployeeData_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            if (EmployeeData.SelectedIndex == -1)
            {
                return;
            }
            else
            {
                var empl = (Employee)EmployeeData.Items[EmployeeData.SelectedIndex];

                new ChangeEmployee(empl.EmployeeId).Show();
            }

        }

        private void PositionData_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (PositionData.SelectedIndex == -1)
            {
                return;
            }
            else
            {
                var pos = (Position)PositionData.Items[PositionData.SelectedIndex];

                new ChangePosition(pos.PositionId).Show();
            }
        }

        private void ManufacturerData_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ManufacturerData.SelectedIndex == -1)
            {
                return;
            }
            else
            {
                var manufact = (Manufacturer)ManufacturerData.Items[ManufacturerData.SelectedIndex];

                new ChangeManufacturer(manufact.ManufacturerId).Show();
            }
        }

        private void deleteEmployeeRow_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new OpbdLr22Context())
            {
                var empl = (Employee)EmployeeData.Items[EmployeeData.SelectedIndex];

                var employee = db.Employees.Find(empl.EmployeeId);

                if (employee == null)
                {
                    MessageBox.Show("Запись не найдена");
                    return;
                }
                else
                {
                    if (MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Подтверждение удаления", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            db.Employees.Remove(employee);

                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        } 
                    }
                    else
                    {
                        return;
                    }

                    Load();
                }
            }
        }

        private void deletePositionsRow_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new OpbdLr22Context())
            {
                var pos = (Position)PositionData.Items[PositionData.SelectedIndex];

                var position = db.Positions.Find(pos.PositionId);

                if (position == null)
                {
                    MessageBox.Show("Запись не найдена");
                    return;
                }
                else
                {
                    if (MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Подтверждение удаления", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            db.Positions.Remove(position);

                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        } 
                    }

                    Load();
                }
            }
        }

        private void deleteManufactureRow_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new OpbdLr22Context())
            {
                var man = (Manufacturer)ManufacturerData.Items[ManufacturerData.SelectedIndex];

                var manufacture = db.Manufacturers.Find(man.ManufacturerId);

                if (manufacture == null)
                {
                    MessageBox.Show("Запись не найдена");
                    return;
                }
                else
                {
                    if (MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Подтверждение удаления", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            db.Manufacturers.Remove(manufacture);

                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        } 
                    }
                    Load();
                }
            }
        }

        
    }
}
