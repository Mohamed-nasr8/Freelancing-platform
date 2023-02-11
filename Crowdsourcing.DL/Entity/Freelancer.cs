using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.DL.Entity
{
    public class Freelancer
    {
        public int Id { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Overview { get; set; }
        public string CVName { get; set; }
        public string ImageName { get; set; }
        public string Title { get; set; }
        public string Bio { get; set; }
        public decimal Rate { get; set; }
        public float Rating { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public int? Point { get; set; }
        public string VerficationState { get; set; }


    }
}       
