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
    public partial class LookUserForm : Form
    {
        String role;

        public LookUserForm(string role) // Конструктор формы просмотра данных о пользователях
        {
            InitializeComponent();
            this.role = role;
            panel3.Visible = false;
            FillUserList(); // Заполнение списка пользователей при загрузке формы

        }
        private void FillUserList() // Метод для заполнения списка пользователей
        {
            // Очистка всех ListBox'ов перед обновлением
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            
            List<User> ListUser = new List<User>(); // Создаем список для хранения данных о пользователях
            try
            {
                // Создаем объект для работы с базой данных и получаем данные из базы и сохраняем их в DataTable
                DataBase dataBase = new DataBase();
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT * FROM users", dataBase.getConnection());
                adapter.SelectCommand = command;
                adapter.Fill(table);

                // Проходим по строкам таблицы и заполняем список пользователей
                foreach (DataRow row in table.Rows)
                {
                    User user = new User();
                    user.id = Convert.ToInt32(row.ItemArray[0]);
                    user.login = Convert.ToString(row.ItemArray[1]);
                    user.password = Convert.ToString(row.ItemArray[2]);
                    user.role = Convert.ToString(row.ItemArray[3]);

                    //Добавляем пользователей в список
                    ListUser.Add(user);
                }
                // Заполняем ListBox'ы данными из списка пользователей
                for (int i = 0; i < ListUser.Count; i++)
                {
                    listBox1.Items.Add($"{ListUser[i].id}");
                    listBox2.Items.Add($"{ListUser[i].login}");
                    listBox3.Items.Add($"{ListUser[i].password}");
                    listBox4.Items.Add($"{ListUser[i].role}");
                }
            }
            catch { }
        }

        private void closeButton_Click(object sender, EventArgs e) // Обработчик события для кнопки закрытия приложения
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e) // Обработчик события для метки возврата в главное меню
        {
            // Скрываем текущую форму и открываем главное меню с учетом роли пользователя
            this.Hide();
            MenuForm menuForm = new MenuForm(role); 
            menuForm.Show();
        }

        private void label7_Click(object sender, EventArgs e) // Обработчик события для метки добавления нового пользователя
        {
            // Скрываем текущую форму и открываем форму добавления нового пользователя 
            this.Hide();
            AddUserForm addUserForm = new AddUserForm(role);
            addUserForm.Show();
        }
        private string HashPassword(string password) // Метод для хеширования пароля с использованием SHA-256
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Вычисляем хеш пароля и возвращаем его в виде строки
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e, ListBox listBox) // Обработчик события выбора элемента в ListBox
        {
            try
            {
                var indexSelect = listBox.SelectedIndex;  // Получаем индекс выбранного элемента в ListBox

                // Вызываем метод для выделения соответствующего элемента в других ListBox'ах
                SelectItemInListBox(listBox1, indexSelect);
                SelectItemInListBox(listBox2, indexSelect);
                SelectItemInListBox(listBox3, indexSelect);
                SelectItemInListBox(listBox4, indexSelect);

                // Заполняем текстовые поля данными из выбранного элемента в ListBox
                idField.Text = listBox1.Items[indexSelect].ToString();
                loginField.Text = listBox2.Items[indexSelect].ToString();
                passField.Text = listBox3.Items[indexSelect].ToString();
                roleField.Text = listBox4.Items[indexSelect].ToString();

                panel3.Visible = true; // Отображаем панель редактирования

            }
            catch { }
        }


        // Обработчики событий выбора элемента в ListBox для конкретных ListBox'ов :
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox_SelectedIndexChanged(sender, e, listBox2);
            
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox_SelectedIndexChanged(sender, e, listBox1);
        }
        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox_SelectedIndexChanged(sender, e, listBox3);
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox_SelectedIndexChanged(sender, e, listBox4);
        }
        private void SelectItemInListBox(ListBox listBox, int index) // Метод для выделения элемента в ListBox по индексу
        {
            if (index >= 0 && index < listBox.Items.Count)  // Проверяем, что индекс находится в допустимых пределах
            {
                listBox.SelectedIndex = index; // Устанавливаем выделение выбранного элемента в ListBox
            }
        }


        private void buttonEditUser_Click_1(object sender, EventArgs e) // Обработчик события кнопки редактирования пользователя
        {
            if (!ValidateInput()) return;  // Проверяем валидность введенных данных перед редактированием


            DataBase db = new DataBase();  // Создаем объект для работы с базой данных
            try
            {
                // Создаем SQL-команду для обновления данных пользователя в базе
                MySqlCommand command = new MySqlCommand("UPDATE `users` SET `login` = @newLog, `password` = @newPass, `role` = @newRole WHERE `users`.`id` = @id", db.getConnection());

                // Задаем параметры для SQL-команды на основе введенных данных
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = idField.Text;
                command.Parameters.Add("@newLog", MySqlDbType.VarChar).Value = newLoginField.Text;
                command.Parameters.Add("@newPass", MySqlDbType.VarChar).Value = HashPassword(newPasswordField.Text);
                command.Parameters.Add("@newRole", MySqlDbType.VarChar).Value = newRoleField.Text;

                db.openConnection(); // Открываем соединение с базой данных

                if (command.ExecuteNonQuery() == 1) // Выполняем SQL-команду и проверяем результат
                {
                    MessageBox.Show("Изменено");
                }
                else
                    MessageBox.Show("Ошибка!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при редактировании пользователя: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.closeConnection(); // Закрываем соединение с базой данных
                panel3.Visible = false;

                // Скрываем панель редактирования, обновляем список пользователей и очищаем поля ввода
                FillUserList();
                newLoginField.Text = "";
                newPasswordField.Text = "";
                newRoleField.Text = "";
            }
        }

        private void buttonDeleteUser_Click(object sender, EventArgs e) // Обработчик события кнопки удаления пользователя
        {
            // Проверяем подтверждение пользователя перед удалением
            if (MessageBox.Show("Вы уверены, что хотите удалить пользователя?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataBase db = new DataBase();  // Создаем объект для работы с базой данных
                try
                {
                    // Создаем SQL-команду для удаления пользователя из базы
                    MySqlCommand command = new MySqlCommand("DELETE FROM `users` WHERE `users`.`id` = @id", db.getConnection());

                    // Задаем параметр для SQL-команды на основе ID пользователя
                    command.Parameters.Add("@id", MySqlDbType.Int32).Value = idField.Text;

                    db.openConnection(); // Открываем соединение с базой данных

                    if (command.ExecuteNonQuery() == 1) // Выполняем SQL-команду и проверяем результат
                    {
                        MessageBox.Show("Пользователь удален");
                    }
                    else
                        MessageBox.Show("Пользователь не удален");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении пользователя: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    db.closeConnection(); // Закрываем соединение с базой данных

                    // Скрываем панель редактирования, обновляем список пользователей
                    panel3.Visible = false;
                    FillUserList();
                }
            }
        }

        private void unVPanel_Click(object sender, EventArgs e) // Обработчик события клика на закрытие панели
        {
            panel3.Visible = false; // Скрываем панель редактирования
        }

        private bool ValidateInput() // Метод для проверки введенных данных
        {
            // Проверка наличия данных в текстовых полях
            if (string.IsNullOrWhiteSpace(newLoginField.Text) || string.IsNullOrWhiteSpace(newPasswordField.Text) || string.IsNullOrWhiteSpace(newRoleField.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

    }
}
