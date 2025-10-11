using System;

namespace WindowsFormsAppAdoNetCRUD
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
    }
}
