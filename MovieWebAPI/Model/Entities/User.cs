using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Entities
{

    [Table("User")]
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [Column("Firstname", TypeName = "varchar(50)")]
        public string FirstName { get; set; }

        [Required]
        [Column("Lastname", TypeName = "varchar(50)")]
        public string LastName { get; set; }

        [Required]
        [Column("Email", TypeName = "varchar(100)")]
        public string Email { get; set; }

        public virtual Collection<Viewing> Viewings { get; set; }
    }
}
