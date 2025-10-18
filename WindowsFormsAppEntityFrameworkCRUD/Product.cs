using System;

namespace WindowsFormsAppEntityFrameworkCRUD
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        // ürün ve kategori arasında ilişki kurma
        public int? CategoryId { get; set; } // ürünün kategori bilgisini tutacak
        public virtual Category Category { get; set; } // navigation property
    }
}
