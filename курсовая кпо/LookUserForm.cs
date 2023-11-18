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
    public partial class LookUserForm : Form
    {
        public LookUserForm()
        {
            InitializeComponent();
            FillUserList();
        }
        private void FillUserList()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            
            List<User> ListUser = new List<User>();
            try
            {
                DataBase dataBase = new DataBase();
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT * FROM users", dataBase.getConnection());
                adapter.SelectCommand = command;
                adapter.Fill(table);
                
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
                //ListUser.Sort();
                //String columns = "{0, -20}{1, -30}{2, -30}{3, -20}";
                for (int i = 0; i < ListUser.Count; i++)
                {
                    //listBox1.Items.Add(String.Format(columns, $"{ListUser[i].id}-", $"{ListUser[i].login}-", $"{ListUser[i].FIO}-", $"{ListUser[i].role}-"));
                    listBox1.Items.Add($"{ListUser[i].id}");
                    listBox2.Items.Add($"{ListUser[i].login}");
                    listBox3.Items.Add($"{ListUser[i].password}");
                    listBox4.Items.Add($"{ListUser[i].role}");
                }
            }
            catch { }
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

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddUserForm addUserForm = new AddUserForm();
            addUserForm.Show();
        }

        private void deleteUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            DeleteUserForm deleteUserForm = new DeleteUserForm();
            deleteUserForm.Show();
        }

        private void RedactUserRecords_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditUserForm editUserForm = new EditUserForm(); 
            editUserForm.Show();
        }
    }
}
