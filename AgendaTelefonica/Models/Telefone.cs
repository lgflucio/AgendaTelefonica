using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgendaTelefonica.Models
{
    public class Telefone : BaseTable
    {
        public string Numero { get; set; }
        public string Tipo { get; set; }
    }
}