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
    /// Логика взаимодействия для ChangeManufacturer.xaml
    /// </summary>
    public partial class ChangeManufacturer : Window
    {
        public long ID { get; set; }

        public ChangeManufacturer(long id)
        {
            InitializeComponent();

            ID = id;

            using (var db = new OpbdLr22Context())
            {
                var manufacturer = db.Manufacturers.Find(ID);

                if (manufacturer == null)
                {
                    MessageBox.Show("Запись не найдена");
                    return;
                }

                NameManufacturer.Text = manufacturer.ManufacturerName;
                CountryManufacturer.Text = manufacturer.ManufacturerCountry;
                AddressManufacturer.Text = manufacturer.ManufacturerAddress;
                ManufacturerEmployeeId.Text = manufacturer.EmployeeId.ToString();

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ChangeManufacturerButton_Click(object sender, RoutedEventArgs e)
        {
            bool[] bools = { NameManufacturer.isRequired(),
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
                using (var db = new OpbdLr22Context())
                {

                    db.Database.EnsureCreated();

                    var manufacturer = db.Manufacturers.Find(ID);

                    if (manufacturer == null)
                    {
                        MessageBox.Show("Запись не найдена");
                        return;
                    }
                    else
                    {

                        manufacturer.ManufacturerName = NameManufacturer.Text;
                        manufacturer.ManufacturerCountry = CountryManufacturer.Text;
                        manufacturer.ManufacturerAddress = AddressManufacturer.Text;
                        manufacturer.EmployeeId = Convert.ToInt64(ManufacturerEmployeeId.Text);

                    }

                    db.Manufacturers.Update(manufacturer);
                    db.SaveChanges();
                    this.Close();

                }

            }
        }
    }
}
