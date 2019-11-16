using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDOperation.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual List<ProductOrder> Products { get; set; }
    }
}
