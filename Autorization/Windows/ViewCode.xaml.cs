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

namespace Autorization.Windows
{
    /// <summary>
    /// Логика взаимодействия для ViewCode.xaml
    /// </summary>
    public partial class ViewCode : Window
    {
        string login = "";
        int password = 0;
        public ViewCode(string login, int password)
        {
            InitializeComponent();
            const string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ?!@#$%^&*()[]";
           
               
                var rnd = new Random();
                //var s = new StringBuilder();
                this.password= password;
            this.login = login;
                StringBuilder sb = new StringBuilder();
                //for (int i = 0; i < 10; i++)
                //    s.Append((char)rnd.Next('a', 'z'));

                //var str = s.ToString();
                for (int i = 0; i < 8; i++)
                {
                    int index = rnd.Next(chars.Length);
                    sb.Append(chars[index]);

                }
               
            
            Code.Text = sb.ToString();

        }

        private void BtnGoEnter(object sender, RoutedEventArgs e)
        {
             FrameClass.MainFrame.Navigate(new Pages.AutorizationPage(Code.Text,login,password));
            FrameClass.counterDo = 1;
            this.Close();
        }
    }
}
