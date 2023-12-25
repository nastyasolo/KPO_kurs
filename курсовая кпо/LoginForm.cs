using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace курсовая_кпо
{
    public partial class LoginForm : Form
    {
        public LoginForm() // Конструктор формы авторизации
        {
            InitializeComponent(); // Инициализация компонентов формы

            // Настройка поля для пароля
            this.passField.AutoSize = false; 
            this.passField.Size = new Size(this.passField.Size.Width,45);
        }


        private void closeButton_Click(object sender, EventArgs e) // Обработчик события кнопки закрытия приложения
        {
            Application.Exit();
        }

        private string HashPassword(string password) // Метод для хеширования пароля с использованием SHA-256
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        private void closeButton_MouseEnter(object sender, EventArgs e) // Обработчик события наведения курсора на кнопку закрытия
        {
            closeButton.ForeColor = Color.White;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e) // Обработчик события ухода курсора с кнопки закрытия
        {
            closeButton.ForeColor = Color.Black;
        }
         
        Point lastPoint; // Переменная для хранения последней точки для перемещения формы
        private void panel1_MouseMove(object sender, MouseEventArgs e) // Обработчик события перемещения мыши над панелью
        {
            if(e.Button == MouseButtons.Left) // Проверка нажатия левой кнопки мыши
            {
                // Изменение положения формы на основе разницы текущей и последней позиции
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e) // Обработчик события нажатия кнопки мыши над панелью
        {
            lastPoint = new Point(e.X, e.Y);    // Запоминание текущей позиции при нажатии левой кнопки мыши  
        }

        private void buttonLogin_Click(object sender, EventArgs e) // Обработчик события нажатия кнопки входа
        {
            try
            {
                // Получаем введенные данные пользователя
                String loginUser = loginField.Text;
                String passUser = HashPassword(passField.Text);
                String roleUser = "0"; // Значение по умолчанию (роль пользователя)

                DataBase db = new DataBase(); // Создаем объект для работы с базой данных

                DataTable table = new DataTable(); // Создаем таблицу для хранения результата запроса

                MySqlDataAdapter adapter = new MySqlDataAdapter();// Создаем адаптер для выполнения запроса к базе данных

                // Создаем SQL-команду для выбора пользователя с указанными логином и паролем
                MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login`=@uL AND `password`=@uP", db.getConnection());
                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
                command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;

                adapter.SelectCommand = command;// Назначаем команду адаптеру

                adapter.Fill(table);// Заполняем таблицу результатами запроса

                db.openConnection(); // Открываем соединение с базой данных для использования другой команды
               
                MySqlDataReader reader = command.ExecuteReader();// Создаем читатель данных для получения дополнительной информации

                // Читаем роль пользователя из результатов запроса
                while (reader.Read())
                {
                    roleUser = Convert.ToString(reader[3]);
                }
                db.closeConnection();// Закрываем соединение с базой данных

                // Проверяем наличие пользователя в базе данных
                if (table.Rows.Count > 0)
                {
                    // Если пользователь найден, скрываем текущую форму и открываем главное меню с указанной ролью
                    this.Hide();
                    MenuForm menuForm = new MenuForm(roleUser);
                    menuForm.Show();

                }
                else
                {
                    // Если пользователь не найден, выводим сообщение об ошибке
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при авторизации: {ex.Message}");
            }
        }

        
    }
}
