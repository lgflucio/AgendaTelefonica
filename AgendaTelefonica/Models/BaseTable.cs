using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgendaTelefonica.Models
{
    public class BaseTable
    {
        public BaseTable()
        {
        }
        [Key]
        public int Id { get; set; }
        [Display(Name = "Data Criação")]
        public DateTime DataCriacao { get; set; }
        public DateTime? Modificado { get; set; }
        public bool Ativo { get; set; }
    }
}