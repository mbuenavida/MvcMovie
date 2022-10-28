using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models
{
    [Table("Movies", Schema = "customSchema")]
    public class MovieModel
    {
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 3)
            ,Required,Column(TypeName = "varchar(100)")]
        public string Title { get; set; }

        [Display(Name = "Release Date"),DataType(DataType.Date)
            ,DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$"),Required
            ,StringLength(30),Column(TypeName = "varchar(100)")]
        public string Genre { get; set; }

        [Range(1, 100),DataType(DataType.Currency)
            ,Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")
            ,StringLength(5),Required] 
        public string Rating { get; set; }
    }
}
