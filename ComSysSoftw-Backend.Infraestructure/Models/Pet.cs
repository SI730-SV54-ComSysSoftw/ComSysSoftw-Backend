﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string description { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }
}
