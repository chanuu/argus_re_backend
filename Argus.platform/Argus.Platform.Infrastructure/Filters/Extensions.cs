using Argus.Platform.Core.Common;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Infrastructure.Filters
{
    public static class Extensions
    {
        // ref : https://github.com/pdevito3/MessageBusTestingInMemHarness/blob/main/RecipeManagement/src/RecipeManagement/Databases/RecipesDbContext.cs
        public static void FilterSoftDeletedRecords(this ModelBuilder modelBuilder)
        {
            Expression<Func<BaseEntity, bool>> filterExpr = e => !e.IsDeleted;
            foreach (var mutableEntityType in modelBuilder.Model.GetEntityTypes()
                .Where(m => m.ClrType.IsAssignableTo(typeof(BaseEntity))))
            {
                // modify expression to handle correct child type
                var parameter = Expression.Parameter(mutableEntityType.ClrType);
                var body = ReplacingExpressionVisitor
                    .Replace(filterExpr.Parameters.First(), parameter, filterExpr.Body);
                var lambdaExpression = Expression.Lambda(body, parameter);

                // set filter
                mutableEntityType.SetQueryFilter(lambdaExpression);
            }
        }
    }
}
