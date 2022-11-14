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
using System.IO;

namespace Самостоялка3_Регистрация
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void enter_Clicl(object sender, RoutedEventArgs e)
        {
            if (textBox_login.Text.Length > 0)   
            {
                if (password.Password.Length > 0)
                {
                    //DataTable dt_user = mainWindow.Select("SELECT * FROM [dbo].[users] WHERE [login] = '" + textBox_login.Text + "' AND [password] = '" + password.Password + "'");
                    string[] Mass = File.ReadAllLines(@"C:\Users\Nadya\Desktop\Самостоялка\пользователи.txt", System.Text.Encoding.Default);
                    bool happy = false;
                    bool wrongP = false;
                    bool wrongL = false;
                    bool noP = false;
                    for (int i = 0; i < Mass.Length; i++)
                    {
                        string[] words = Mass[i].Split('*');

                        if (words[0] == textBox_login.Text && words[1] == password.Password)
                        {
                            happy = true;
                            //break;
                        }
                        else if (words[0] == textBox_login.Text && words[1] != password.Password)
                        {
                            wrongP = true;
                            //break;
                        }
                        else if (words[0] == textBox_login.Text && words[1] != password.Password)
                        {
                            wrongL = true;
                            //break;
                        }
                    }
                    if (happy != true && wrongP != true && wrongL != true)
                        noP = true;

                    if (happy == true)
                        MessageBox.Show("Пользователь авторизовался!");
                    if (wrongP == true)
                        MessageBox.Show("Неверный пароль!");
                    if (wrongL == true)
                        MessageBox.Show("Пользователь с таким логином не найден!");
                    if (noP == true)
                        MessageBox.Show("Пользователь не найден(");
                }
                else MessageBox.Show("Введите пароль");   
            }
            else MessageBox.Show("Введите логин");
        }

        private void register_Click(object sender, RoutedEventArgs e)
        {
            Window1 Window1 = new Window1();
            this.Close();
            Window1.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
