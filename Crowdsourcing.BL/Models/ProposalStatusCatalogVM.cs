﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.DL.Models
{
    public class ProposalStatusCatalogVM
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(128)"),Required(ErrorMessage ="Requried Name")]
        public string Name { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<Proposal> Proposals { get; set; }

    }
}