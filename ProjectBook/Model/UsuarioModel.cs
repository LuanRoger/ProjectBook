﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProjectBook.Tipos;

namespace ProjectBook.Model
{
    [Table("Usuarios")]
    public class UsuarioModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int id { get; set; }
        
        [Required]
        [MaxLength(50)]
        [Column("Usuario")]
        public string usuario { get; set; }
        
        [Required]
        [MaxLength(50)]
        [Column("Senha")]
        public string senha { get; set; }
        
        [Required]
        [MaxLength(3)]
        [Column("Tipo")]
        public TipoUsuario tipo { get; set; }
    }
}