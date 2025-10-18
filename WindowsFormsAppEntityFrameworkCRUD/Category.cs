using System;
using System.Collections.Generic;

namespace WindowsFormsAppEntityFrameworkCRUD
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual List<Product> Products { get; set; } // 1 kategoride 1 den çok product olabilir. Bire çok ilişki.
    }
}
