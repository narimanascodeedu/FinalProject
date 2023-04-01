using MotorOil.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorOil.Domain.Models.ViewModels
{
    public class ContactPostInfoViewModel
    {
        public ContactPost ContactPosts { get; set; }
        public ContactInfo ContactInfos { get; set; }
    }
}
