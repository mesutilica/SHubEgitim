using System.Data.SqlClient;

namespace WindowsFormsAppAdoNetCRUD
{
    public class UserDAL : OrtakDAL
    {
        public int Add(User user)
        {
            int sonuc = 0;
            ConnectionKontrol();
            SqlCommand cmd = new SqlCommand("insert into users (Name, Surname, IsActive, CreateDate, Email, Password) values (@Name, @Surname, @IsActive, @CreateDate, @Email, @Password)", _connection);
            cmd.Parameters.AddWithValue("@Name", user.Name);
            cmd.Parameters.AddWithValue("@Surname", user.Surname);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@IsActive", user.IsActive);
            cmd.Parameters.AddWithValue("@CreateDate", user.CreateDate);
            sonuc = cmd.ExecuteNonQuery(); // sql komutunu çalıştır ve etkilenen kayıt sayısını sonuc a ata
            cmd.Dispose();
            _connection.Close();
            return sonuc;
        }
        public int Update(User user)
        {
            int sonuc = 0;
            ConnectionKontrol();
            SqlCommand cmd = new SqlCommand("update users set Name=@Name, Surname=@Surname, Email=@Email, Password=@Password, IsActive=@IsActive, CreateDate=@CreateDate where Id=@Id", _connection);
            cmd.Parameters.AddWithValue("@Name", user.Name);
            cmd.Parameters.AddWithValue("@Surname", user.Surname);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@IsActive", user.IsActive);
            cmd.Parameters.AddWithValue("@CreateDate", user.CreateDate);
            cmd.Parameters.AddWithValue("@Id", user.Id);
            sonuc = cmd.ExecuteNonQuery(); // sql komutunu çalıştır ve etkilenen kayıt sayısını sonuc a ata
            cmd.Dispose();
            _connection.Close();
            return sonuc;
        }
        public int Delete(int id)
        {
            int sonuc = 0;
            ConnectionKontrol();
            SqlCommand cmd = new SqlCommand("delete from users where Id=@Id", _connection);
            cmd.Parameters.AddWithValue("@Id", id);
            sonuc = cmd.ExecuteNonQuery(); // sql komutunu çalıştır ve etkilenen kayıt sayısını sonuc a ata
            cmd.Dispose();
            _connection.Close();
            return sonuc;
        }
    }
}
