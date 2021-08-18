using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectBook.Livros
{
    [Table("Clientes")]
    public class ClienteModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int id { get; init; }
        
        [Required]
        [MaxLength(100)]
        [Column("NomeCompleto")]
        public string nomeCompleto { get; set; }
        
        [Required]
        [MaxLength(100)]
        [Column("Endereco")]
        public string endereco { get; set; }
        
        [Required]
        [MaxLength(100)]
        [Column("Cidade")]
        public string cidade { get; set; }
        
        [Required]
        [MaxLength(2)]
        [Column("Estado")]
        public string estado { get; set; }
        
        
        [MaxLength(9)]
        [Column("Cep")]
        public string cep { get; set; }
        
        [Required]
        [MaxLength(18)]
        [Column("Telefone1")]
        public string telefone1 { get; set; }
        
        [MaxLength(18)]
        [Column("Telefone2")]
        public string telefone2 { get; set; }
        
        [MaxLength(100)]
        [Column("Email")]
        public string email { get; set; }
    }
}
