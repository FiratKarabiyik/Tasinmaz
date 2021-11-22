using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Entities.Concrete
{
    public class Sehir:IEntity
    {
        [Key]
        public int Sid { get; set; }
        public string Sname { get; set; }
    }
}
