using System.ComponentModel.DataAnnotations;

namespace RazorPagesFilmes.Model
{
    public class Filme
    {
        public int ID { get; set; }
        //Se não quiser iniciar nula a propriedade podemos inserir o valor vazio nela com string.Empty
        public string Title { get; set; } = string.Empty;
        //utilização do DataAnnotations para especificar o parâmetro que deseja informar no DateTime        
        [DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }
        public string Genero { get; set; } = string.Empty;
        public double Price { get; set; }


    }
}
