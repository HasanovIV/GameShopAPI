using System;
using System.Collections.Generic;

namespace GameWebApi.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
