using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyTask.Model
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

    }
}
