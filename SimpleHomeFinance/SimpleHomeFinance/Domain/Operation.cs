using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleHomeFinance.Domain
{
    public class Operation
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}