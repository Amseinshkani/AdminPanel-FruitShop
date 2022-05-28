using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

    public class MVFactor
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public int Count { get; set; }

        public int Requestedweight { get; set; }
        
        public int totalweight { get; set; }

        public IFormFile upimg { get; set; }
        public int sum { get; set; }
    }
