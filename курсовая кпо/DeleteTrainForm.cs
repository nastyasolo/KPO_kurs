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
    public partial class DeleteTrainForm : Form
    {
        String role;

        public DeleteTrainForm(String role)
        {
            InitializeComponent();
            this.role = role;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void goToMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuForm menuForm = new MenuForm(role);
            menuForm.ShowDialog();
        }

        private void buttonDeleteUser_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            MySqlCommand command = new MySqlCommand("DELETE FROM `trains` WHERE `trains`.`number` = @number", db.getConnection());

            command.Parameters.Add("@number", MySqlDbType.VarChar).Value = numberTrainField.Text;


            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Поезд удален");
            }
            else
                MessageBox.Show("Поезд не удален");

            db.closeConnection();
        }
    }
}
