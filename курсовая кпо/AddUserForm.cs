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
    public partial class AddUserForm : Form
    {
        String role;

        public AddUserForm(string role) // Конструктор формы добавления пользователя
        {
            InitializeComponent(); // Инициализация компонентов формы
            this.role = role; // Присвоение переданной роли полю role
        }
        private string HashPassword(string password) // Метод для хеширования пароля с использованием SHA-256
        {
            using (SHA256 sha256 = SHA256.Create()) // Использование SHA-256 для вычисления хеша
            {
                // Получение массива байт хеша
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                // Преобразование массива байт в строку и приведение к нижнему регистру
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        private void buttonAddUser_Click(object sender, EventArgs e) // Обработчик события нажатия кнопки "Добавить пользователя"
        {
            if (loginField.Text == "")  // Проверка наличия введенного логина
            {
                MessageBox.Show("Введите логин");
                return;
            }
            // Проверка корректности введенной роли (допустимые значения: "0" или "1")
            if (roleField.Text != "1" && roleField.Text != "0")
            {
                MessageBox.Show("Неверная роль");
                return;
            }
            if (isUserExists()) // Проверка наличия пользователя с таким логином
                return;

            try
            {

                DataBase db = new DataBase(); // Создание объекта для работы с базой данных
                // Создание SQL-команды для вставки нового пользователя в таблицу 'users'
                MySqlCommand command = new MySqlCommand("INSERT INTO `users` ( `login`, `password`, `role`) VALUES( @log, @pass, @role)",db.getConnection());

                // Передача параметров команды
                command.Parameters.Add("@log", MySqlDbType.VarChar).Value = loginField.Text;
                command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = HashPassword(passField.Text);
                command.Parameters.Add("@role", MySqlDbType.VarChar).Value = roleField.Text;

                db.openConnection(); // Открытие соединения с базой данных

                if (command.ExecuteNonQuery() == 1) // Выполнение команды 
                {
                    MessageBox.Show("Пользователь добавлен");
                }
                else
                    MessageBox.Show("Пользователь не добавлен");

                db.closeConnection(); // Закрытие соединения с базой данных

            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }

        }
        public Boolean isUserExists() // Метод проверки существования пользователя с введенным логином
        {
            DataBase db = new DataBase(); // Создание объекта для работы с базой данных

            DataTable table = new DataTable(); // Создание таблицы для хранения результатов запроса

            MySqlDataAdapter adapter = new MySqlDataAdapter(); // Создание адаптера для выполнения запроса

            // Создание SQL-команды для выбора пользователя с указанным логином
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login`=@uL ", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginField.Text;

            adapter.SelectCommand = command; // Назначение команды адаптеру
            adapter.Fill(table); // Заполнение таблицы результатами запроса

            // Проверка наличия пользователя с таким логином
            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Такой логин уже есть введите другой");
                return true;
            }
            else
            {
                return false;
            }

        }

        private void closeButton_Click(object sender, EventArgs e) // Обработчик события нажатия кнопки закрытия
        {
            Application.Exit();
        }

        private void label6_Click_1(object sender, EventArgs e) // Обработчик события нажатия на метку для возврата в главное меню
        {
            this.Hide();
            MenuForm menuForm = new MenuForm(role);
            menuForm.Show();
        }
    }
}
