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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace курсовая_кпо
{
    public partial class DeleteUserForm : Form
    {

        String role;
        public DeleteUserForm(string role)
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

        private void buttonDeleteUser_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            MySqlCommand command = new MySqlCommand("DELETE FROM `users` WHERE `users`.`id` = @id", db.getConnection());

            command.Parameters.Add("@id", MySqlDbType.Int32).Value = idField.Text;
            

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Пользователь удален");
            }
            else
                MessageBox.Show("Пользователь не удален");

            db.closeConnection();


        }

        private void idField_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
