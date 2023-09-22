using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectricAssignmentyear2.Forms
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            EmployeeForms employeeForms = new EmployeeForms();
            employeeForms.Show();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            CustomerForm customerform = new CustomerForm();
            customerform.Show();
        }

        private void btnItems_Click(object sender, EventArgs e)
        {
            ItemForm itemform = new ItemForm();
            itemform.Show();
        }
    }
}
