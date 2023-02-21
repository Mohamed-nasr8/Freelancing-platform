using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.DL.Models
{
    public class AttachmentVM
    {
        public int Id { get; set; }
        public string? AttachmentLink { get; set; } 

        // Foreign Key From Class Message
        public int MessageId { get; set; }
        public Message Message { get; set; }

    }
}
