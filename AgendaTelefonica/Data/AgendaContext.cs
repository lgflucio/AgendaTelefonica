using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AgendaTelefonica.Data
{
    public class AgendaContext : DbContext
    {
        public System.Data.Entity.DbSet<AgendaTelefonica.Models.Contatos> Contatos { get; set; }
    }
}