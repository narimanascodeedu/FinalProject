using MotorOil.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorOil.Domain.Models.ViewModels
{
    public class SearchPanelViewModel
    {
        public ProductViscosity[] Viscosities { get; set; }
        public ProductLiter[] Liters { get; set; }
        public ProductApi[] Apis { get; set; }
        public ProductType[] Types { get; set; }
        public Brand[] Brands { get; set; }

        public Category[] Categories { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
    }
}
