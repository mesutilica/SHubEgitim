using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace WindowsFormsAppAdoNetCRUD
{
    public class ProductDAL : OrtakDAL
    {
        public List<Product> GetAll()
        {
            var products = new List<Product>();
            ConnectionKontrol();
            SqlCommand sqlCommand = new SqlCommand("select * from products", _connection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                var product = new Product()
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString(),
                    Description = reader["Description"].ToString(),
                    IsActive = (bool)reader["IsActive"],
                    Price = Convert.ToDecimal(reader["Price"]),
                    Stock = (int)reader["Stock"],
                    CreateDate = Convert.ToDateTime(reader["CreateDate"])
                };
                products.Add(product);
            }
            reader.Close();
            _connection.Close();
            sqlCommand.Dispose();
            return products;
        }

        public int Add(Product product)
        {
            int sonuc = 0;
            ConnectionKontrol(); // bağlanto kontrolü yap
            SqlCommand cmd = new SqlCommand("insert into Products (Name, Description, IsActive, CreateDate, Stock, Price) values (@Name, @Description, @IsActive, @CreateDate, @Stock, @Price)", _connection);
            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@Description", product.Description);
            cmd.Parameters.AddWithValue("@IsActive", product.IsActive);
            cmd.Parameters.AddWithValue("@CreateDate", product.CreateDate);
            cmd.Parameters.AddWithValue("@Stock", product.Stock);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            sonuc = cmd.ExecuteNonQuery(); // sql komutunu çalıştır ve etkilenen kayıt sayısını sonuc a ata
            cmd.Dispose();
            _connection.Close();
            return sonuc;
        }
        public int Update(Product product)
        {
            int sonuc = 0;
            ConnectionKontrol(); // bağlanto kontrolü yap
            SqlCommand cmd = new SqlCommand("update Products set Name=@Name, Description=@Description, IsActive=@IsActive, CreateDate=@CreateDate, Stock=@Stock, Price=@Price where Id=@Id", _connection);
            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@Description", product.Description);
            cmd.Parameters.AddWithValue("@IsActive", product.IsActive);
            cmd.Parameters.AddWithValue("@CreateDate", product.CreateDate);
            cmd.Parameters.AddWithValue("@Stock", product.Stock);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            cmd.Parameters.AddWithValue("@Id", product.Id);
            sonuc = cmd.ExecuteNonQuery(); // sql komutunu çalıştır ve etkilenen kayıt sayısını sonuc a ata
            cmd.Dispose();
            _connection.Close();
            return sonuc;
        }
        public int Delete(int id)
        {
            int sonuc = 0;
            ConnectionKontrol(); // bağlanto kontrolü yap
            SqlCommand cmd = new SqlCommand("delete from Products where Id=@Id", _connection);
            cmd.Parameters.AddWithValue("@Id", id);
            sonuc = cmd.ExecuteNonQuery(); // sql komutunu çalıştır ve etkilenen kayıt sayısını sonuc a ata
            cmd.Dispose();
            _connection.Close();
            return sonuc;
        }

    }
}
