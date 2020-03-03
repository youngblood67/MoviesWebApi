using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }

        public Movie Movie { get; set; }
    }
}
