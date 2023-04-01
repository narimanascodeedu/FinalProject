using MotorOil.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorOil.Domain.AppCode.Extensions
{
    public static partial class Extension
    {
        static public IEnumerable<Category> GetAllChilds(this Category parent)
        {
            if (parent.ParentId != null)
                yield return parent;

            foreach (var item in parent.Children.SelectMany(c => c.GetAllChilds()))
            {
                yield return item;
            }
        }

        static public IEnumerable<Category> GetAllChildren(this Category category)
        {
            if (category.ParentId != null)
            {
                yield return category;
            }


            if (category.Children != null)
            {
                foreach (var item in category.Children.SelectMany(c => c.GetAllChildren()))
                {
                    yield return item;
                }
            }


        }
    }
}
