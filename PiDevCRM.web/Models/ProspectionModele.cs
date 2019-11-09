using PiDevCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PiDevCRM.Web.Models
{
    public class ProspectionModele
    {
        public List<Prospection> ListProspection { get; set; }
        public List<Agent> ListAgent { get; set; }
    }
}

