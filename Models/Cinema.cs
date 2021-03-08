using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Models
{
    public class Cinema
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Website { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
