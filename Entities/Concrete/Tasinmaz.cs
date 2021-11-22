using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Tasinmaz : IEntity
    {
        public int TasinmazId { get; set; }
        public int Il { get; set; }
        public virtual Mahalle Mahalle{ get; set; }
        public int Ilce { get; set; }
        public int MahalleId { get; set; }
        public string Ada { get; set; }
        public string Parsel { get; set; }
        public int Kordinat { get; set; }
        public string Nitelik { get; set; }

        public string Adres { get; set; }

        public int UserId { get; set; }
        public string coorX { get; set; }

        public string  coorY { get; set; }
    }
}
