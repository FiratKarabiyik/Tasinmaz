using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class TasinmazDetailDto : IDto
    {
        public int TasinmazId { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }


        public int UserId { get; set; }

    }
}
