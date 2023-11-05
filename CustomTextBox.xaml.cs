using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для CustomTexBox.xaml
    /// </summary>
    public partial class CustomTextBox : UserControl
    {
        public CustomTextBox()
        {
            InitializeComponent();
            lenghtOfText = -1;
            required = false;
        }

        public string placeholder
        {
            get { return (string)GetValue(TextBlockTextProperty); }
            set { SetValue(TextBlockTextProperty, value); }
        }

        public static readonly DependencyProperty TextBlockTextProperty =
            DependencyProperty.Register("placeholder", typeof(string), typeof(CustomTextBox));

        public string Text
        {
            get { return (string)GetValue(TextBoxTextProperty); }
            set { SetValue(TextBoxTextProperty, value); }
        }

        public static readonly DependencyProperty TextBoxTextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(CustomTextBox));

        public Brush underlineColor
        {
            get { return (Brush)GetValue(UnderlineColorProperty); }
            set { SetValue(UnderlineColorProperty, value); }
        }

        public static readonly DependencyProperty UnderlineColorProperty =
            DependencyProperty.Register("underlineColor", typeof(Brush), typeof(CustomTextBox));

        protected void hidePlaceholder(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(UserTBox.Text)) UserPlaceholder.Visibility = Visibility.Visible;
            else UserPlaceholder.Visibility = Visibility.Hidden;
            validationText.Text = "";
        }

        public int lenghtOfText
        {
            get { return (int)GetValue(NeedLenght); }
            set { SetValue(NeedLenght, value); }
        }

        public static readonly DependencyProperty NeedLenght =
            DependencyProperty.Register("lenghtOfText", typeof(int), typeof(CustomTextBox));

        public bool required
        {
            get { return (bool)GetValue(Required); }
            set { SetValue(Required, value); }
        }

        public static readonly DependencyProperty Required =
            DependencyProperty.Register("required", typeof(bool), typeof(CustomTextBox));

        public bool isLenghtCorrect()
        {
            if (UserTBox.Text.Length == lenghtOfText || lenghtOfText == -1)
            {
                return true;
            }
            else 
            {
                validationText.Text = "Поле заполнено неправильно";
                return false;
            }
        }

        public bool isRequired()
        {
            if (required)
            {
                if (string.IsNullOrWhiteSpace(UserTBox.Text))
                {
                    validationText.Text = "Это поле необходимо к заполнению";
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

    }
}
