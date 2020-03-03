using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Entities
{
    public class Viewing
    {
        [Key]
        public int ViewingId { get; set; }

        [Required]
        [Column("When")]
        public DateTime CommentDateTime { get; set; }

        [Required]
        [Range(0, 20, ErrorMessage = "La note doit être comprise entre 0 et 20")]
        public int Score { get; set; }

        [DefaultValue("sans commentaire")]
        public string Comment { get; set; }

        //Clés étrangères
        public int MovieId { get; set; }  //clé étrangère SQL
        public virtual Movie Movie { get; set; }  //propriété de navigation ou propriété relationnelle qui sert à EF pour lier les entités

        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}
