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
    public partial class EditUserForm : Form
    {
        String role;
        public EditUserForm(string role)
        {
            InitializeComponent();
            this.role = role;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            //LookUserForm lookUserForm = new LookUserForm();
            //lookUserForm.Hide();
            MenuForm menuForm = new MenuForm(role);
            menuForm.Show();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonEditUser_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            MySqlCommand command = new MySqlCommand("UPDATE `users` SET `login` = @newLog, `password` = @newPass, `role` = @newRole WHERE `users`.`id` = @id", db.getConnection());

            command.Parameters.Add("@id", MySqlDbType.Int32).Value = idField.Text;
            command.Parameters.Add("@newLog", MySqlDbType.VarChar).Value = newLoginField.Text;
            command.Parameters.Add("@newPass", MySqlDbType.VarChar).Value = newPasswordField.Text;
            command.Parameters.Add("@newRole", MySqlDbType.VarChar).Value = newRoleField.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Изменено");
            }
            else
                MessageBox.Show("Ошибка!");

            db.closeConnection();
        }
    }
}
