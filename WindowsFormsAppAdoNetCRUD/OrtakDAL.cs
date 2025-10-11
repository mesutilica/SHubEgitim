using System.Data; // veritabanı işlemleri için gerekli kütüphane
using System.Data.SqlClient; // sql işlemleri için ado.net kütüphanesi

namespace WindowsFormsAppAdoNetCRUD
{
    public class OrtakDAL
    {
        internal SqlConnection _connection = new SqlConnection(@"server=(localdb)\MSSQLLocalDB; database=WindowsFormsAppAdoNetCRUD; Integrated Security=True;"); // veritabanımın bulunduğu server bilgisini connection string olarak burada tanımlıyorum.

        internal void ConnectionKontrol()//Veritabanı bağlantımızı kontrol edecek olan metot
        {
            if (_connection.State == ConnectionState.Closed)//Eğer veritabanı bağlantımızın durumu kapalı ise
            {
                _connection.Open();//Veritabanı bağlantısını aç
            }
        }

        public DataTable GetDataTable(string sqlSorgu)
        {
            DataTable dt = new DataTable();

            ConnectionKontrol();

            SqlCommand command = new SqlCommand(sqlSorgu, _connection);

            SqlDataReader reader = command.ExecuteReader();

            dt.Load(reader);

            reader.Close();
            _connection.Close();
            command.Dispose();

            return dt;
        }

    }
}
