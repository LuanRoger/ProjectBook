using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProjectBook.Tipos;

namespace ProjectBook.Livros
{
    [Table("Alugueis")]
    public class AluguelModel
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        
        [Required]
        [MaxLength(100)]
        [Column("Titulo")]
        public string titulo { get; set; }
        
        [Required]
        [MaxLength(100)]
        [Column("Autor")]
        public string autor { get; set; }
        
        [Required]
        [MaxLength(100)]
        [Column("AlugadoPor")]
        public string alugadoPor { get; set; }
        
        [Required]
        [Column("DataEntrega")]
        public DateTime dataEntrega { get; set; }
        
        [Required]
        [Column("DataDevolucao")]
        public DateTime dataDevolucao { get; set; }
        
        [MaxLength(9)]
        [Column("Status")]
        public StatusAluguel status { get; set; }
    }
}
