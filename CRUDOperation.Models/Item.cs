using CRUDOperation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDOperation.Models
{
    public class Item
    {

        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
