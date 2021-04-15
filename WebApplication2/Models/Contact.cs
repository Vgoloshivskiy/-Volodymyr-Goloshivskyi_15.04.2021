using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public List<Phone> Phones { get; set; } = new List<Phone>();
        
    }
}