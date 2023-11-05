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
    /// Логика взаимодействия для AddManufacturer.xaml
    /// </summary>
    public partial class AddManufacturer : Window
    {
        public AddManufacturer()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddManufacturerButton_Click(object sender, RoutedEventArgs e)
        {
            bool[] bools = { ManufacturerId.isRequired(), 
                NameManufacturer.isRequired(), 
                CountryManufacturer.isRequired(), 
                AddressManufacturer.isRequired(),
                ManufacturerEmployeeId.isRequired()};

            if (bools.Contains(false))
            {
                MessageBox.Show("Некоторые поля заполнены неправильно");
                return;
            }
            else
            {
                var db = new OpbdLr22Context();
                db.Database.EnsureCreated();
                var Manufacture = new Manufacturer
                {
                    ManufacturerId = Convert.ToInt64(ManufacturerId.Text),
                    ManufacturerName = NameManufacturer.Text,
                    ManufacturerCountry = CountryManufacturer.Text,
                    ManufacturerAddress = AddressManufacturer.Text,
                    EmployeeId = Convert.ToInt64(ManufacturerEmployeeId.Text)
                };
                db.Manufacturers.Add(Manufacture);
                db.SaveChanges();
                this.Close(); 
            }
        }
    }
}
