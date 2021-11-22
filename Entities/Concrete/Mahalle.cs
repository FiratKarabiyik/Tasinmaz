using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Mahalle:IEntity
    {
        [Key]
        public int Kid { get; set; }

        public int IlceId { get; set; }
        public virtual Ilce Ilce { get; set; }

        public string Kname { get; set; }
    }
}
