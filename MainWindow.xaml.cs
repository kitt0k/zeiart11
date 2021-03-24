using System;
using System.Collections.Generic;
using System.IO;
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

namespace zeiart11
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        List<User> peoplelist = new List<User>();

        public MainWindow()
        {
            for (int i = 1; i < 99999; i++)
            {
                peoplelist.Add(new User
                {
                    ID = i,
                    Name = $"Пользователь{i}",
                    Login = $"User{i}",
                    Password = $"Pass{i}",
                }
                  );

            }

            InitializeComponent();
        }

        private void captcha_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BTNcapthca_Click(object sender, RoutedEventArgs e)
        {
            String allowchar = "";
            allowchar += "1,2,3,4,5,6,7,8,9,0";
            char[] a = { ',' };
            string[] ar = allowchar.Split(a);
            String pwd = "";
            String temp = "";
            Random r = new Random();

            for (int i = 0; i < 5; i++)
            {
                temp = ar[(r.Next(0, ar.Length))];
                pwd += temp;

            }
            Captcha.Text = pwd;


        }

        private void BTNexit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void login_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private void BTNenter_Click(object sender, RoutedEventArgs e)
        {

            string login1 = global::zeiart11.Properties.Resources.login1;
            string password1 = global::zeiart11.Properties.Resources.password1;

            string login2 = global::zeiart11.Properties.Resources.login2;
            string password2 = global::zeiart11.Properties.Resources.password2;


            var user = peoplelist.Where(i => i.Login == login.Text && i.Password == pass.Text).FirstOrDefault();



            if ((user != null)  | ((Captcha.Text == CaptchaEnter.Text) & (login.Text == login1) & (pass.Text == password1)) | ((Captcha.Text == CaptchaEnter.Text) & (login.Text == login2) & (pass.Text == password2)))
            {
                UserWindow userWindow = new UserWindow(user);
                this.Close();
                userWindow.ShowDialog();
                this.Hide();

                Lose.Visibility = Visibility.Hidden;
                Done.Visibility = Visibility.Visible;


            }
            else
            {

                {
                    String allowchar = "";
                    allowchar += "1,2,3,4,5,6,7,8,9,0";
                    char[] a = { ',' };
                    string[] ar = allowchar.Split(a);
                    String pwd = "";
                    String temp = "";
                    Random r = new Random();

                    for (int i = 0; i < 5; i++)
                    {
                        temp = ar[(r.Next(0, ar.Length))];
                        pwd += temp;

                    }
                    Captcha.Text = pwd;


                }

             

                Done.Visibility = Visibility.Hidden;
                Lose.Visibility = Visibility.Visible;
                //MessageBox.Show("Пользователь не найден");

            }



            //if (((Captcha.Text == CaptchaEnter.Text) & (login.Text == login1) & (pass.Text == password1)) | ((Captcha.Text == CaptchaEnter.Text) & (login.Text == login2) & (pass.Text == password2)))

            //{
            //    Lose.Visibility = Visibility.Hidden;
            //    Done.Visibility = Visibility.Visible;

            //    UserWindow UserWindow = new UserWindow(user);
            //    this.Hide();
            //    UserWindow.ShowDialog();
            //    this.Close();


            //}

            //else
            //{

            //    Done.Visibility = Visibility.Hidden;
            //    Lose.Visibility = Visibility.Visible;


            //    {
            //        String allowchar = "";
            //        allowchar += "1,2,3,4,5,6,7,8,9,0";
            //        char[] a = { ',' };
            //        string[] ar = allowchar.Split(a);
            //        String pwd = "";
            //        String temp = "";
            //        Random r = new Random();

            //        for (int i = 0; i < 5; i++)
            //        {
            //            temp = ar[(r.Next(0, ar.Length))];
            //            pwd += temp;

            //        }
            //        Captcha.Text = pwd;






            //    }

            }



        }

    }






