using QL_HocSinh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_HocSinh.DAO
{
    public class HocSinhDAO
    {
        private string connectionString = @"Data Source=.\sqlexpress;Initial Catalog=QLHS;Integrated Security=True";

        public DataSet LoadData()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string sql = "SELECT * FROM HocSinh";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                connection.Close();

                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool Insert(HocSinh hocSinh)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string sql = "INSERT INTO HocSinh(MaHS, TenHS, DiaChi) VALUES(@maHS, @tenHS, @diaChi)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@maHS", hocSinh.MaHS);
                command.Parameters.AddWithValue("@tenHS", hocSinh.TenHS);
                command.Parameters.AddWithValue("@diaChi", hocSinh.DiaChi);
                if (command.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                connection.Close();

            }
            catch (Exception e)
            {
                return false;
            }
            return false;
        }

        public bool Update(HocSinh hocSinh)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string sql = "UPDATE HocSinh SET TenHS = @tenHS, DiaChi = @diaChi WHERE MaHS = @maHS";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@maHS", hocSinh.MaHS);
                command.Parameters.AddWithValue("@tenHS", hocSinh.TenHS);
                command.Parameters.AddWithValue("@diaChi", hocSinh.DiaChi);
                if (command.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                connection.Close();

            }
            catch (Exception e)
            {
                return false;
            }
            return false;
        }

        public bool Delete(HocSinh hocSinh)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string sql = "DELETE FROM HocSinh  WHERE MaHS = @maHS";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@maHS", hocSinh.MaHS);
                if (command.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                connection.Close();

            }
            catch (Exception e)
            {
                return false;
            }
            return false;
        }

        public bool IsExisted(string maHS)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string sql = "SELECT * FROM HocSinh WHERE MaHS = @msHS";
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@msHS", maHS);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                connection.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }
    }
}
