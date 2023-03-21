using Autorization.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace Autorization.Pages
{
    /// <summary>
    /// Логика взаимодействия для AutorizationPage.xaml
    /// </summary>
    public partial class AutorizationPage : Page
    {
        DispatcherTimer timer = new DispatcherTimer();
        public int d = 10;
        string roleUser = "";
        int password = 0;
        public string code = "";
        
        public AutorizationPage()
        {
            InitializeComponent();
            //times.Visibility = Visibility.Hidden;
            TbPass.IsEnabled = false;
            imgRef.IsEnabled = false;
        }
        public AutorizationPage(string code, string login, int password)
        {
            InitializeComponent();
            TbNumber.Text = login;
            TbPass.Password = Convert.ToString(password);
            TbCode.IsEnabled = true;
            imgRef.IsEnabled = false;
            TbCode.Focus();

            timer.Interval = new TimeSpan(0, 0, 1);

            timer.Start();
            timer.Tick += new EventHandler(close_timer1);
            this.code = code;


        }
        void close_timer1(object sender, EventArgs e)
        {

 
            if (d != 0)
            {
                times.Visibility = Visibility.Visible;
                times.Text = "Осталость до окончания ввода " + d.ToString();
                d--;

            }
            else
            {

                timer.Stop();
              
                MessageBox.Show("Вы не успели ввести код");
                times.Visibility = Visibility.Hidden;
                TbPass.IsEnabled = false;
                TbCode.IsEnabled = false;
                imgRef.IsEnabled = true;

            }
        }
        private void TbNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                // int paswordCode = TbPasAvto.Password.GetHashCode();
                USERS User = BaseClass.EM.USERS.FirstOrDefault(z => z.CODE == TbNumber.Text);
                if (User == null)
                {
                    MessageBox.Show("Вы не зарегистрированы");

                }
                else
                {
                    
                    
                    
                    TbPass.IsEnabled = true;
                    TbPass.Focus();
                }


            }
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {

            if (FrameClass.counterDo == 0)
            {
                try
                {
                    password = Convert.ToInt32(TbPass.Password);
                    USERS user = BaseClass.EM.USERS.FirstOrDefault(z => z.CODE == TbNumber.Text && z.PASSWORD == Convert.ToInt32(password));
                    if (user == null)
                        MessageBox.Show(TbPass.Password + "   Пароль введен неверно   ");
                    else
                    {
                        ViewCode viewCode = new ViewCode(TbNumber.Text, password);
                        viewCode.ShowDialog();

                    }
                }
                catch
                {
                    MessageBox.Show("Пароль введен неверно");
                }


            }
            else
            {
                if (code == TbCode.Text)
                {
                    USERS user = BaseClass.EM.USERS.FirstOrDefault(z => z.CODE == TbNumber.Text);

                    ROLES role = BaseClass.EM.ROLES.FirstOrDefault(z => z.ID_ROLES == user.ID_ROLE);
                    MessageBox.Show("Вход выполнен, Ваша роль:  " + role.ROLE);
                    timer.Stop();
                    times.Visibility = Visibility.Hidden;
                }
                else
                {
                    MessageBox.Show("Код введен не верно");
                }
            }
        }

        private void TbPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    password = Convert.ToInt32(TbPass.Password);
                    USERS user = BaseClass.EM.USERS.FirstOrDefault(z => z.CODE == TbNumber.Text && z.PASSWORD == password);
                    if (user == null)
                        MessageBox.Show("Пароль введен неверно");
                    else
                    {
                        ViewCode viewCode = new ViewCode(TbNumber.Text, password);
                        viewCode.Show();
                    }
                }
                catch
                {
                    MessageBox.Show("ошибка" + TbPass.Password);
                }


            }
         
        }

        private void btnError_Click(object sender, RoutedEventArgs e)
        {
            TbNumber.Text = "";
            TbPass.Password = null;
            TbCode.Text = "";
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ViewCode viewCode = new ViewCode(TbNumber.Text, password);
            viewCode.Show();

        }

        private void TbCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (code == TbCode.Text)
                {
                    timer.Stop();
                    USERS user = BaseClass.EM.USERS.FirstOrDefault(z => z.CODE == TbNumber.Text);

                 ROLES role = BaseClass.EM.ROLES.FirstOrDefault(z => z.ID_ROLES == user.ID_ROLE);
                    MessageBox.Show("Вход выполнен, Ваша роль: " + role.ROLE );

                    times.Visibility = Visibility.Hidden;
                }
                else
                {
                    MessageBox.Show("Код введен не верно");
                }
            }
        }
    }
}
    

