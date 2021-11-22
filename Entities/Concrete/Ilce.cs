using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Ilce:IEntity
    {
        [Key]
        public int Iid { get; set; }
        public string Iname { get; set; }
        public virtual Sehir Sehir { get; set; }

        public int SehirId { get; set; }
    }
}
