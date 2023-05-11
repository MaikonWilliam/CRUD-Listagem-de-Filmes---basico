using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace RazorPagesFilmes.Model
{
    public class Filme
    {
        public int ID { get; set; }
        
        //Se não quiser iniciar nula a propriedade podemos inserir o valor vazio nela com string.Empty
        [Display(Name = "Título")]
        [StringLength(50,MinimumLength = 2)]
        public string Title { get; set; } = string.Empty;


        [Display(Name ="Data de Lançamento")]
        //utilização do DataAnnotations para especificar o parâmetro que deseja informar no DateTime        
        [DataType(DataType.Date)]  
        public DateTime DataLancamento { get; set; }


        [Display(Name = "Gênero")]
        [Required(ErrorMessage ="Digite o gênero do filme!")]
        [StringLength(30,MinimumLength = 3)]
        public string Genero { get; set; } = string.Empty;

        [DataType(DataType.Currency)] 
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Preço")]
        public double Price { get; set; }

        [Range(0,10)]
        public int Avaliacao { get; set; } = 0;



    }
}
