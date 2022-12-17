using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgendaTelefonica.Models
{
    public class BaseTable
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? Modificado { get; set; }
        public bool Ativo { get; set; }
    }
}