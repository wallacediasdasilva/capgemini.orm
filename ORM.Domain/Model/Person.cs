﻿using System;

namespace ORM.Domain.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string CPF { get; set; }
        public string Address { get; set; }
    }
}
