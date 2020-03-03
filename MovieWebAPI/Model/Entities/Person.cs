using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }

        public ICollection<Movie> DirectedMovies { get; set; }
        public ICollection<MovieActor> PlayedMovies { get; set; }
    }
}
