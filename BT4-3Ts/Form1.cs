using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT4_3Ts
{
    public partial class Form1 : Form
    {
        CustomerBAL cusBAL = new CustomerBAL();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<CustomerBEL> lstCus = cusBAL.ReadCustomer();
            foreach (CustomerBEL cus in lstCus)
            {
                drvCustomer.Rows.Add(cus.Id, cus.Name, cus.AreaName);
            }
        }

        private void New_Click(object sender, EventArgs e)
        {
            CustomerBEL cus = new CustomerBEL();
            cus.Id = int.Parse(tbId.Text);
            cus.Name = tbName.Text;
            cusBAL.NewCustomer(cus);
            drvCustomer.Rows.Add(cus.Id, cus.Name,cus.AreaName);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            CustomerBEL cus = new CustomerBEL();
            cus.Id = int.Parse(tbId.Text);
            cus.Name = tbName.Text;
            cusBAL.NewCustomer(cus);
            int idx = drvCustomer.CurrentCell.RowIndex;
            drvCustomer.Rows.RemoveAt(idx);
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            CustomerBEL cus = new CustomerBEL();
            cus.Id = int.Parse(tbId.Text);
            cus.Name = tbName.Text;
            cusBAL.NewCustomer(cus);
            DataGridViewRow row = drvCustomer.CurrentRow;
            row.Cells[0].Value = cus.Id;
            row.Cells[1].Value = cus.Name;
            row.Cells[2].Value = cus.AreaName;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
