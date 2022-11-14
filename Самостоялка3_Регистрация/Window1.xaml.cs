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
using System.IO;

namespace Самостоялка3_Регистрация
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void enter_Click(object sender, RoutedEventArgs e)
        {
            bool AllGood = true;
            if (textBox_login.Text.Length > 0)
            {
                string[] dataLogin = textBox_login.Text.Split('@');
                if (dataLogin.Length == 2)
                {
                    string[] data2Login = dataLogin[1].Split('.');
                    if (data2Login.Length == 2)
                    {

                    }
                    else MessageBox.Show("Укажите логин в форме х@x.x");
                }
                else MessageBox.Show("Укажите логин в форме х@x.x");
            }
            else MessageBox.Show("Укажите логин");

            bool en = true; // английская раскладка
            bool symbol = false; // символ
            bool number = false; // цифра

            if (password.Password.Length > 0)
            {
                if (password.Password.Length >= 6)
                {
                    for (int i = 0; i < password.Password.Length; i++) // перебираем символы
                    {
                        if (password.Password[i] >= 'А' && password.Password[i] <= 'Я') en = false; // если русская раскладка
                        if (password.Password[i] >= '0' && password.Password[i] <= '9') number = true; // если цифры
                        if (password.Password[i] == '_' || password.Password[i] == '-' || password.Password[i] == '!') symbol = true; // если символ
                    }

                    if (!en)
                    { MessageBox.Show("Доступна только английская раскладка"); AllGood = false; }
                    else if (!symbol)
                    { MessageBox.Show("Добавьте один из следующих символов: _ - !"); AllGood = false; }
                    else if (!number)
                    { MessageBox.Show("Добавьте хотя бы одну цифру"); AllGood = false; }
                    if (en && symbol && number)
                    {

                    }
                }
                else { MessageBox.Show("пароль слишком короткий, минимум 6 символов"); AllGood = false; }
            }
            else { MessageBox.Show("Укажите пароль"); AllGood = false; }


            if (password_Copy.Password.Length > 0)
            {
                if (password.Password == password_Copy.Password) // проверка на совпадение паролей
                {
                    string[] Mass = File.ReadAllLines(@"C:\Users\Nadya\Desktop\Самостоялка\пользователи.txt", System.Text.Encoding.Default);
                    for (int i = 0; i < Mass.Length - 1; i++)
                    {
                        string[] words = Mass[i].Split('*');
                        if (words[0] == textBox_login.Text)
                        {
                            MessageBox.Show("Пользователь уже существует!"); AllGood = false;
                            break;
                        }
                    }

                    if (AllGood == true)
                    {
                        StreamWriter f = new StreamWriter(@"C:\Users\Nadya\Desktop\Самостоялка\пользователи.txt", true);
                        string result = (textBox_login.Text + "*" + password.Password);
                        f.WriteLine(result);
                        f.Close();
                        MessageBox.Show("Пользователь зарегистрирован");
                    }
                    else MessageBox.Show("Видимо, что-то пошло не так(");
                }
                else MessageBox.Show("Пароли не совпадают");
            }
            else MessageBox.Show("Повторите пароль");
        }
        

        private void exit_click(object sender, RoutedEventArgs e)
        {
            MainWindow Window1 = new MainWindow();
            this.Close();
            Window1.ShowDialog();
        }
    }
}
