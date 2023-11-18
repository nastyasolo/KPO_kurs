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
        public MenuForm()
        {
            InitializeComponent();
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
            LookUserForm lookUserForm = new LookUserForm();
            lookUserForm.Show();

        }

        private void buttonAddData_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddTrainForm addTrainForm = new AddTrainForm();
            addTrainForm.Show();
        }

        private void buttonDeleteData_Click(object sender, EventArgs e)
        {
            this.Hide();
            DeleteTrainForm deleteTrainForm = new DeleteTrainForm();
            deleteTrainForm.Show();
        }

        private void buttonRedactData_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditTrainForm editTrainForm = new EditTrainForm();
            editTrainForm.Show();
        }

        private void buttonLookData_Click(object sender, EventArgs e)
        {
            this.Hide();
            LookTrainForm lookTrainForm = new LookTrainForm();
            lookTrainForm.Show();
        }
    }
}
