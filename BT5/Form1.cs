using BT5.BAL;
using BT5.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT5
{
    public partial class Form1 : Form
    {
        CustomerBAL cusBAL= new CustomerBAL();
        AreaBAL areaBAL = new AreaBAL();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<CustomerBEL> lstCus = cusBAL.ReadCustomer();
            foreach (CustomerBEL cus in lstCus)
            {
                dataGridView1.Rows.Add(cus.Id, cus.Name,cus.AreaName);
            }
            List<AreaBEL> lstArea = areaBAL.ReadAreaList();
            foreach(AreaBEL area in lstArea)
            {
                cbArea.Items.Add(area);
            }
            cbArea.DisplayMember = "Name";
        }
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            DataGridViewRow row= dataGridView1.Rows[idx];
            if (row.Cells[0].Value !=null)
            {
                tbId.Text= row.Cells[0].Value.ToString();
                tbName.Text= row.Cells[1].Value.ToString();
                cbArea.Text= row.Cells[2].Value.ToString();
            }
        }

        private void New_Click(object sender, EventArgs e)
        {
            CustomerBEL cus = new CustomerBEL();
            cus.Id=int.Parse(tbId.Text);
            cus.Name=tbName.Text;
            cus.Area=(AreaBEL)cbArea.SelectedItem;
            cusBAL.NewCustomer(cus);
            dataGridView1.Rows.Add(cus.Id, cus.Name, cus.Area.Name);
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            if(row!=null)
            {
                CustomerBEL cus = new CustomerBEL();
                cus.Id= int.Parse(tbId.Text);
                cus.Name=tbName.Text;
                cus.Area =(AreaBEL)cbArea.SelectedItem;
                cusBAL.EditCustomer(cus);
                row.Cells[0].Value = cus.Id;
                row.Cells[1].Value = cus.Name;
                row.Cells[2].Value = cus.Area.Name;
            }
        }
    }
}
