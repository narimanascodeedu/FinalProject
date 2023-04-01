using MotorOil.Domein.AppCode.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorOil.Domain.Models.Entities
{
    public class ContactInfo : BaseEntity
    {
        public string ContactUs { get; set; }
        public string PhoneNumber { get; set; }

        public string Location { get; set; }

        public string EmailAddress { get; set; }
    }
}

