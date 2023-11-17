using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace курсовая_кпо
{
    public partial class AddUserForm : Form
    {
        public AddUserForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            

        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            if (loginField.Text == "")
            {
                MessageBox.Show("Введите логин");
                return;
            }
            if (roleField.Text != "1" && roleField.Text != "0")
            {
                MessageBox.Show("Неверная роль");
                return;
            }
            if (isUserExists())
                return;
            ////
            //////проверки
            //////

            DataBase db = new DataBase();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users` ( `login`, `password`, `role`) VALUES( @log, @pass, @role)",db.getConnection());

            command.Parameters.Add("@log", MySqlDbType.VarChar).Value = loginField.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = passField.Text;
            command.Parameters.Add("@role", MySqlDbType.VarChar).Value = roleField.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Пользователь добавлен");
            }
            else
                MessageBox.Show("Пользователь не добавлен");

            db.closeConnection();

        }
        public Boolean isUserExists()
        {
            DataBase db = new DataBase();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login`=@uL ", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginField.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

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

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
        }

        private void label6_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
        }
    }
}
