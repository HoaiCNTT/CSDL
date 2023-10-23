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

namespace BT1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void New_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source = localhost; Initial Catalog=SALES; User Id=sa; Password= sa");
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into customerX values(3,'Nguyen X')",conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source = localhost; Initial Catalog=SALES; User Id=sa; Password= sa");
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from customerX where id=1",conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source = localhost; Initial Catalog=SALES; User Id=sa; Password= sa");
            conn.Open();
            SqlCommand cmd = new SqlCommand("update customerX set Name='Nguyen Z' where id =3",conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void Read_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source = localhost; Initial Catalog=SALES; User Id=sa; Password= sa");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from customerX",conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    dgvCustomer.Rows.Add(reader.GetInt32(0),reader.GetString(1));
                }
            }
            conn.Close();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
