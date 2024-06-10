using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace intprogödev.Models
{

    public class Ogrenci
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Öğrenci Adı gereklidir.")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Öğrenci soyadı gereklidir.")]
        public string Soyad { get; set; }

        [Required(ErrorMessage = "Öğrenci numarası gereklidir.")]
        public int Numara { get; set; }

        public ICollection<OgrenciDers> OgrenciDersler { get; set; }

    }
}


