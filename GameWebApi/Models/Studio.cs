﻿using System;

namespace GameWebApi.Models
{
    public class Studio
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
