using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Log :IEntity
    {
        [Key]
        public int logid { get; set; }
        public Boolean durum { get; set; }
        public string  islemtipi { get; set; }
        public string acıklama { get; set; }

        public DateTime tarih { get; set; }

        public string logip { get; set; }

        public int userid { get; set; }
    }
}
