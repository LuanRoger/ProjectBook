using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectBook.Livros
{
    [Table("Livros")]
    public class LivroModel
    {
        [Key]
        [Required]
        [Column("ID")]
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
        [Column("Editora")]
        public string editora { get; set; }
        
        [MaxLength(100)]
        [Column("Edicao")]
        public string edicao { get; set; }
        
        [MaxLength(100)]
        [Column("Ano")]
        public int ano { get; set; }
        
        [MaxLength(100)]
        [Column("Titulo")]
        public string genero { get; set; }
        
        [Required]
        [MaxLength(100)]
        [Column("DataCadastro")]
        public DateTime dataCadastro { get;  set; }
        
        [MaxLength(17)]
        [Column("ISBN")]
        public string isbn { get; set; }
        
        [Column("Observacoes", TypeName = "varchar(MAX)")]
        public string observacoes { get; set; }
    }
}
