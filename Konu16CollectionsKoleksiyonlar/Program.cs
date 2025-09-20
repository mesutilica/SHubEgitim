using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace Konu16CollectionsKoleksiyonlar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Konu16-Collections-Koleksiyonlar");
            // Ornek1();
            // Ornek2();
            // Ornek3();
            // Ornek4();
            // Ornek5();
            ListKullanimi();
        }
        static void Ornek1()
        {
            ArrayList arrayList = new();
            arrayList.Add(1);
            arrayList.Add("iki");
            arrayList.Add(3.0);
            arrayList.Add(true);
            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine("ArrayList ilk eleman : " + arrayList[0]);// listede index ini verdiğimiz elemana ulaşma
        }
        static void Ornek2()
        {
            ArrayList arrayList = new();
            arrayList.Add("İstanbul"); // arrayList e Add metoduyla veri eklenir
            arrayList.Add("Ankara");
            arrayList.Add("İzmir");
            arrayList.Add("Elazığ");
            arrayList.Add("Çankırı");
            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine("ArrayList de sıralama yapabiliriz");
            arrayList.Sort(); // a-z sıralama
            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            arrayList.Reverse(); // tersten sıralama
            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }
        }
        static void Ornek3()
        {
            var strings = new StringCollection();
            strings.Add("İstanbul");
            strings.Add("Ankara");
            strings.Add("Bursa");
            // strings.Add(34); // sadece string veri eklenebilir!
            Console.WriteLine("String Collection");
            foreach (var item in strings)
            {
                Console.WriteLine(item);
            }
        }
        static void Ornek4()
        {
            var dictionary = new StringDictionary(); // key value şeklinde veri saklayabilir
            dictionary.Add("18", "Çankırı");
            dictionary.Add("06", "Angara");
            dictionary.Add("34", "İstanbul");
            dictionary.Add("01", "Adana");
            dictionary.Add("58", "Sivas");
            Console.WriteLine();
            foreach (var item in dictionary)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("dictionary.Keys");
            foreach (var item in dictionary.Keys)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("dictionary.Values:");
            foreach (var item in dictionary.Values)
            {
                Console.WriteLine(item);
            }
        }
        static void Ornek5()
        {
            Dictionary<string, string> dictionary = new(); // hangi veri tipinden oluşacağını bizim belirleyebildiğimiz liste sistemi
            dictionary.Add("book", "kitap");
            dictionary.Add("18", "Çankırı");
            dictionary.Add("34", "İstanbul");
            Console.WriteLine(dictionary["book"]);

            Console.WriteLine();

            Dictionary<int, string> dictionary2 = new(); // hangi veri tipinden oluşacağını bizim belirleyebildiğimiz liste sistemi
            dictionary2.Add(1, "Adana");
            dictionary2.Add(18, "Çankırı");
            dictionary2.Add(34, "İstanbul");

            Console.WriteLine();

            Console.WriteLine("dictionary2 values");

            foreach (var item in dictionary2)
            {
                Console.WriteLine(item.Value);
            }

            Console.WriteLine();

            Console.WriteLine("dictionary2 keys");

            foreach (var item in dictionary2)
            {
                Console.WriteLine(item.Key);
            }
        }
        static void ListKullanimi()
        {
            Console.WriteLine("List Kullanimi");
            List<string> sehirler = new(); // string veri tipi alabilen bir liste
            sehirler.Add("Ankara");
            sehirler.Add("İstanbul");
            sehirler.Add("Kocaeli");
            sehirler.Add("Sivas 58");
            Console.WriteLine("Şehirler:");
            foreach (var item in sehirler)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            List<User> users = new();
            users.Add(new User
            {
                Id = 1,
                Name = "Hüseyin",
                Password = "123"
            });
            users.Add(new User
            {
                Id = 2,
                Name = "Serdar",
                Password = "123"
            });
            Console.WriteLine("Kullanıcılar:");
            foreach (var item in users)
            {
                Console.WriteLine(item.Name + " " + item.Password);
            }
            Console.WriteLine();
            List<User> kullanicilar = new()
            {
                new User
                {
                    Id = 3,
                    Name = "Kamil",
                    Password = "1234"
                },
                new User
                {
                    Id = 4,
                    Name = "Yunus",
                    Password = "12345"
                }
            };
            Console.WriteLine("Kullanıcılar 2:");
            foreach (var item in kullanicilar)
            {
                Console.WriteLine(item.Name + " " + item.Password);
            }
            var yeniKullanici = new User()
            {
                Id = 5,
                Name = "Alp",
                Password = "789"
            };
            Console.WriteLine("Kullanıcılar listesinde yeniKullanici var mı? :");
            Console.WriteLine(kullanicilar.Contains(yeniKullanici));
            kullanicilar.Add(yeniKullanici);
            Console.WriteLine(kullanicilar.Contains(yeniKullanici));
        }
    }
}
