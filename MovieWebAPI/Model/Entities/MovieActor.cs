using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public class MovieActor
    {
        public int ActorId { get; set; }
        public int MovieId { get; set; }
        public Person Actor { get; set; }
        public Movie Movie { get; set; }
    }
}
