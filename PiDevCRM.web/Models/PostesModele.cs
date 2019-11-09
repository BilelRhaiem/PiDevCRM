using PiDevCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PiDevCRM.Web.Models
{
    public class PostesModele
    {
        public Postes post { get; set; }
        public Client client { get; set; }
        public IEnumerable<Client> ListClients { get; set; }
        public List<Comment> ListComment { get; set; }
    }
}

