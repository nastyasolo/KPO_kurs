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
    public partial class MenuForm : Form
    {
        String role;

        public MenuForm(String role)
        {
            InitializeComponent();
            this.role = role;
            if (role =="0" ) {
             AdminPanel.Visible = false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       

        private void buttonSortData_Click(object sender, EventArgs e)
        {

        }

       

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            LookUserForm lookUserForm = new LookUserForm(role);
            lookUserForm.Show();

        }

        private void buttonAddData_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddTrainForm addTrainForm = new AddTrainForm(role);
            addTrainForm.Show();
        }

        private void buttonDeleteData_Click(object sender, EventArgs e)
        {
            this.Hide();
            DeleteTrainForm deleteTrainForm = new DeleteTrainForm(role);
            deleteTrainForm.Show();
        }

        private void buttonRedactData_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditTrainForm editTrainForm = new EditTrainForm(role);
            editTrainForm.Show();
        }

        private void buttonLookData_Click(object sender, EventArgs e)
        {
            this.Hide();
            LookTrainForm lookTrainForm = new LookTrainForm(role);
            lookTrainForm.Show();
        }

        private void buttonSearchData_Click(object sender, EventArgs e)
        {
            this.Hide();
            SearchTrainForm searchTrainForm = new SearchTrainForm(role);
            searchTrainForm.Show();
        }

        private void SearchTaskTrainButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            SearchTaskTrainForm searchTaskTrainForm = new SearchTaskTrainForm(role);
            searchTaskTrainForm.Show();
        }
    }
}
