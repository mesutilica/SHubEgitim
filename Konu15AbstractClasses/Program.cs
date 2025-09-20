namespace Konu15AbstractClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Konu15AbstractClasses");
            //Database database = new Database(); // Abstract class'lardan nesne üretilemez
            Database database1 = new SqlServer();
            database1.Add();
            database1.Delete();
            database1.Get();

            Database database2 = new MySql();
            database2.Add();
            database2.Delete();
            database2.Get();
        }
    }
    abstract class Database
    {
        public void Add()
        {
            Console.WriteLine("Add metodu çalıştı Ekleme yapıldı");
        }
        public abstract void Delete();//crud
        public abstract void Update();//crud
        public abstract void Get();//crud
    }
    class SqlServer : Database
    {
        public override void Delete()
        {
            Console.WriteLine("SqlServer Delete metodu çalıştı Silme yapıldı");
        }
        public override void Get()
        {
            Console.WriteLine("SqlServer Get metodu çalıştı Listeleme yapıldı");
        }
        public override void Update()
        {
            Console.WriteLine("SqlServer Update metodu çalıştı Güncelleme yapıldı");
        }
    }
    class Oracle : Database
    {
        public override void Delete()
        {
            Console.WriteLine("Oracle Delete metodu çalıştı Silme yapıldı");
        }
        public override void Get()
        {
            Console.WriteLine("Oracle Get metodu çalıştı Listeleme yapıldı");
        }
        public override void Update()
        {
            Console.WriteLine("Oracle Update metodu çalıştı Güncelleme yapıldı");
        }
    }
    class MySql : Database
    {
        public override void Delete()
        {
            Console.WriteLine("MySql Delete metodu çalıştı Silme yapıldı");
        }
        public override void Get()
        {
            Console.WriteLine("MySql Get metodu çalıştı Listeleme yapıldı");
        }
        public override void Update()
        {
            Console.WriteLine("MySql Update metodu çalıştı Güncelleme yapıldı");
        }
    }
}
