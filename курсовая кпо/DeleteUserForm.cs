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
        public DeleteUserForm()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void buttonDeleteUser_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show($"Вы действительно хотите удалить данного пользователя [{idField.Text}]  ?", "УДАЛЕНИЕ",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                String idUser = idField.Text;
                try
                {
                    DataBase dataBase = new DataBase();
                    MySqlCommand command = new MySqlCommand("DELETE FROM users WHERE id = @uID ", dataBase.getConnection());
                    command.Parameters.Add("@uID", MySqlDbType.VarChar).Value = idUser;
                    dataBase.openConnection();
                    //command.ExecuteNonQuery();
                    if (command.ExecuteNonQuery() == 1)
                        MessageBox.Show("Успешно !", "УДАЛЕНИЕ", MessageBoxButtons.OK, MessageBoxIcon.None);
                    else
                        MessageBox.Show("Ошибка !", "УДАЛЕНИЕ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataBase.closeConnection();
                   
                }
                catch
                {
                    MessageBox.Show("Ошибка !", "УДАЛЕНИЕ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }
        }

        private void idField_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
