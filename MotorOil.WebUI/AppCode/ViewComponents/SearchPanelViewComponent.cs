using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotorOil.Domain.Models.DataContexts;
using MotorOil.Domain.Models.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MotorOil.WebUI.AppCode.ViewComponents
{
    public class SearchPanelViewComponent : ViewComponent
    {
        private readonly MotorOilDbContext db;

        public SearchPanelViewComponent(MotorOilDbContext db)
        {
            this.db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var vm = new SearchPanelViewModel();

            vm.Viscosities = db.ProductCatalog
                .Include(pv => pv.ProductViscosity)
                .Select(pv => pv.ProductViscosity)
                .Where(pv => pv.DeletedDate == null)
                .Distinct()
                .ToArray();

            vm.Liters = db.ProductCatalog
                .Include(pl => pl.ProductLiter)
                .Select(pl => pl.ProductLiter)
                .Where(pl => pl.DeletedDate == null)
                .Distinct()
                .ToArray();

            vm.Apis = db.ProductCatalog
                .Include(pa => pa.ProductApi)
                .Select(pa => pa.ProductApi)
                .Where(pa => pa.DeletedDate == null)
                .Distinct()
                .ToArray();

            vm.Types = db.ProductCatalog
                .Include(pt => pt.ProductType)
                .Select(pt => pt.ProductType)
                .Where(pt => pt.DeletedDate == null)
                .Distinct()
                .ToArray();

            vm.Brands = db.ProductCatalog
                .Include(pb => pb.Product)
                .ThenInclude(pb => pb.Brand)
                .Select(pb => pb.Product.Brand)
                .Where(pb => pb.DeletedDate == null)
                .Distinct()
                .ToArray();

            vm.Categories = db.ProductCatalog
                .Include(c => c.Product)
                .ThenInclude(c => c.Category)
                .Select(c => c.Product.Category)
                .Where(c => c.DeletedDate == null)
                .Distinct()
                .ToArray();




            var priceRange = db.ProductCatalog
                .Include(pc => pc.Product)
                .Select(pc => pc.Product.Price)
                .ToArray();

            vm.Min = (int)Math.Floor(priceRange.Min());
            vm.Max = (int)Math.Floor(priceRange.Max());

            return View(vm);
        }
    }
}
