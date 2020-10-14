using System;
using System.ComponentModel.DataAnnotations;

namespace DataSort.Models
{
    public class Image
    {
        [Required]
        public string ScaneId { get; set; }

        [Required]
        public DateTime PassingDate { get; set; }

        [Required]
        public long Latitude { get; set; }

        [Required]
        public long Longitude { get; set; }
    }
}
