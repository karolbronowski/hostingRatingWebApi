using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hostingRatingWebApi.Models
{
 public class Entity
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id {get; protected set;}

        protected Entity()
        {
            Id = Guid.NewGuid();
        } 
    }
}