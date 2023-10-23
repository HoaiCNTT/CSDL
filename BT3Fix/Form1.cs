using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT3Fix
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=SALES;user Id=sa;Password=sa");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * form customerX", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    drvCustomer.Rows.Add(reader.GetInt32(0), reader.GetString(1));
                }
            }
            conn.Close();
        }
        private void drvCustomer_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            tbId.Text = drvCustomer.Rows[idx].Cells[0].Value.ToString();
            tbName.Text = drvCustomer.Rows[idx].Cells[1].Value.ToString();
        }
        private void New_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source = localhost; Initial Catalog=SALES; User Id=sa; Password= sa";
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into customerX values(@id,@name)", conn);
            cmd.Parameters.Add(new SqlParameter("@id", tbId.Text));
            cmd.Parameters.Add(new SqlParameter("@name", tbName.Text));
            cmd.ExecuteNonQuery();
            conn.Close();
            drvCustomer.Rows.Add(tbId.Text, tbName.Text);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source = localhost; Initial Catalog=SALES; User Id=sa; Password= sa";
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from customerX where id=@id", conn);
            cmd.Parameters.Add(new SqlParameter("@id", tbId.Text));
            cmd.ExecuteNonQuery();
            conn.Close();
            int idx = drvCustomer.CurrentCell.RowIndex;
            drvCustomer.Rows.RemoveAt(idx);
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source = localhost; Initial Catalog=SALES; User Id=sa; Password= sa";
            conn.Open();
            SqlCommand cmd = new SqlCommand("update customerX set Name=@name where id=@id", conn);
            cmd.Parameters.Add(new SqlParameter("@id", tbId.Text));
            cmd.Parameters.Add(new SqlParameter("@name", tbName.Text));
            cmd.ExecuteNonQuery();
            conn.Close();
            int idx = drvCustomer.CurrentCell.RowIndex;
            drvCustomer.Rows[idx].Cells[1].Value = tbName.Text;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
