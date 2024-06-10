using System.Collections.Generic;

namespace intprogödev.Models
{
    public class OgrenciDers
    {
        public int Id { get; set; }
        public int OgrenciId { get; set; }
        public int DersId { get; set; }

        public Ders Ders { get; set; }
        public Ogrenci  Ogrenciler { get; set; }
    }
}
