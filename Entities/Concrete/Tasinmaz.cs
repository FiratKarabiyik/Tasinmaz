using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Tasinmaz : IEntity
    {
        public int TasinmazId { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string Mahalle { get; set; }
        public string Ada { get; set; }
        public string Parsel { get; set; }
        public int Kordinat { get; set; }
        public string Nitelik { get; set; }

        public string Adres { get; set; }

        public int UserId { get; set; }
    }
}
