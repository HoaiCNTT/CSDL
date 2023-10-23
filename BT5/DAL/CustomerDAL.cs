using BT5.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT5.DAL
{
    internal class CustomerDAL : DBConnection
    {
        public List<CustomerBEL> ReadCustomer()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from custom5", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<CustomerBEL> lstCus = new List<CustomerBEL>() ;
            AreaDAL area = new AreaDAL() ;
            while(reader.Read()){
                CustomerBEL cus = new CustomerBEL() ;
                cus.Id = int.Parse(reader["id"].ToString());
                cus.Name = reader["name"].ToString();
                cus.Area = area.ReadArea(int.Parse(reader["id_area"].ToString()));  
                lstCus.Add(cus);
            }
            conn.Close();
            return lstCus;
        }
        public void EditCustomer(CustomerBEL cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("update custom5 set name =@name,id_area=@id_area where id=@id", conn);
            cmd.Parameters.Add(new SqlParameter("@id",cus.Id));
            cmd.Parameters.Add(new SqlParameter("@name",cus.Name));
            cmd.Parameters.Add(new SqlParameter("@id_area", cus.Area.Id));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void DeleteCustomer(CustomerBEL cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from custom5 where id=@id", conn);
            cmd.Parameters.Add(new SqlParameter("@id", cus.Id));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void NewCustomer(CustomerBEL cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into custom5 value(@id,@name,@id_area )", conn);
            cmd.Parameters.Add(new SqlParameter("@id", cus.Id));
            cmd.Parameters.Add(new SqlParameter("@name", cus.Name));
            cmd.Parameters.Add(new SqlParameter("@id_area", cus.Area.Id));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
    
}
