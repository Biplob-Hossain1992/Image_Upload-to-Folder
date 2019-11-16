using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDOperation.Models
{
    public class ProductOrder
    {
        public long ProductId { get; set; }
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
