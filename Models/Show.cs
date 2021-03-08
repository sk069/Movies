using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Models
{
    public class Show
    {

        public int Id { get; set; }

        [Required]
        public string Shows { get; set; }

        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }


        public int MovieId { get; set; }

        public Movie Movie { get; set; }

        public int Kids_CollectionId { get; set; }

        public Kids_Collection Kids_Collection { get; set; }

        [Required]
        public int Available_Shows { get; set; }

        [Required]
        public decimal Ticket_Price { get; set; }
    }
}
