using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.Entities
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime ReleasedAt { get; set; }
        public float Duration { get; set; }
        public Person Director { get; set; }
        public ICollection<MovieActor> Actors { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
