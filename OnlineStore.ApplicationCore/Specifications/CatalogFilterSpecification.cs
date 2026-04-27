using OnlineStore.ApplicationCore.Entities;
using OnlineStore.ApplicationCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.ApplicationCore.Specifications
{
    public class CatalogFilterSpecification : ISpecification<CatalogItem>
    {
        public int? BrandId { get; }
        public int? TypeId { get; }

        public CatalogFilterSpecification(int? brandId, int? typeId)
        {
            BrandId = brandId;
            TypeId = typeId;
        }

        public Expression<Func<CatalogItem, bool>>
            Criteria => i => 
            (!BrandId.HasValue || i.CatalogBrandId == BrandId)
            && 
            (!TypeId.HasValue || i.CatalogTypeId == TypeId);


        public List<Expression<Func<CatalogItem, object>>> Includes { get; }
            = new List<Expression<Func<CatalogItem, object>>>();

        public void AddIncludes(Expression<Func<CatalogItem, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
    }
}
