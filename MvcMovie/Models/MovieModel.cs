using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models
{
    [Table("Movies", Schema = "customSchema")]
    public class MovieModel
    {
        public int Id { get; set; }

        [Display(Name = "Título"),
            StringLength(100, MinimumLength = 3),
            Required,
            Column("Title", TypeName = "varchar(100)")]
        public string Title { get; set; }

        [Display(Name = "Fecha Extreno"),
            DataType(DataType.Date),
            DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Género"),
            RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$"),
            Required,
            StringLength(30),
            Column("Genre", TypeName = "varchar(100)")]
        public string Genre { get; set; }

        [Display(Name = "Importe"),
            Range(1, 100),
            DataType(DataType.Currency),
            Column("Price", TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Display(Name = "Rating"),
            RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$"),
            StringLength(5),
            Required] 
        public string Rating { get; set; }     
 
    }
}
