using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace intprogödev.Models
{

    public class Ders
    {
        public int Id { get; set; }

        [Required]
        public string DersKodu { get; set; }

        [Required]
        public string DersAdi { get; set; }

        public byte Kredi { get; set; }
    }

}
