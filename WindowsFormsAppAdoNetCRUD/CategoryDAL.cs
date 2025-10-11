using System.Data.SqlClient;

namespace WindowsFormsAppAdoNetCRUD
{
    public class CategoryDAL : OrtakDAL
    {
        public int Add(Category category)
        {
            int sonuc = 0;
            ConnectionKontrol(); // bağlanto kontrolü yap
            SqlCommand cmd = new SqlCommand("insert into Categories (Name, Description, IsActive, CreateDate) values (@Name, @Description, @IsActive, @CreateDate)", _connection);
            cmd.Parameters.AddWithValue("@Name", category.Name);
            cmd.Parameters.AddWithValue("@Description", category.Description);
            cmd.Parameters.AddWithValue("@IsActive", category.IsActive);
            cmd.Parameters.AddWithValue("@CreateDate", category.CreateDate);
            sonuc = cmd.ExecuteNonQuery(); // sql komutunu çalıştır ve etkilenen kayıt sayısını sonuc a ata
            cmd.Dispose();
            _connection.Close();
            return sonuc;
        }
        public int Update(Category category)
        {
            int sonuc = 0;
            ConnectionKontrol(); // bağlanto kontrolü yap
            SqlCommand cmd = new SqlCommand("update Categories set Name=@Name, Description=@Description, IsActive=@IsActive, CreateDate=@CreateDate where Id=@Id", _connection);
            cmd.Parameters.AddWithValue("@Name", category.Name);
            cmd.Parameters.AddWithValue("@Description", category.Description);
            cmd.Parameters.AddWithValue("@IsActive", category.IsActive);
            cmd.Parameters.AddWithValue("@CreateDate", category.CreateDate);
            cmd.Parameters.AddWithValue("@Id", category.Id);
            sonuc = cmd.ExecuteNonQuery(); // sql komutunu çalıştır ve etkilenen kayıt sayısını sonuc a ata
            cmd.Dispose();
            _connection.Close();
            return sonuc;
        }
        public int Delete(int id)
        {
            int sonuc = 0;
            ConnectionKontrol(); // bağlanto kontrolü yap
            SqlCommand cmd = new SqlCommand("delete from Categories where Id=@Id", _connection);            
            cmd.Parameters.AddWithValue("@Id", id);
            sonuc = cmd.ExecuteNonQuery(); // sql komutunu çalıştır ve etkilenen kayıt sayısını sonuc a ata
            cmd.Dispose();
            _connection.Close();
            return sonuc;
        }
    }
}
