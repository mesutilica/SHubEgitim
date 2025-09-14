namespace Konu08SiniflarClasses
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public DateTime CreateDate { get; set; }
        public bool KullaniciGiris(string mail, string sifre)
        {
            if (mail == "admin@user.co" && sifre == "123456")
            {
                return true;
            }
            return false;
        }
    }
}
