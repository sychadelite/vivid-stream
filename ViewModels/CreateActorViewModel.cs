using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vivid.ViewModels
{
    public class CreateActorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bio is required")]
        public string Bio { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
    }
}