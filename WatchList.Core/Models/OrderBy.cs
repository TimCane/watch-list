using System.Linq.Expressions;
using WatchList.Core.Interfaces;

namespace WatchList.Core.Models
{
    public class OrderBy<TModel, TType> : IOrderBy
    {
        private readonly Expression<Func<TModel, TType>> expression;

        public OrderBy(Expression<Func<TModel, TType>> expression)
        {
            this.expression = expression;
        }

        public dynamic Expression => this.expression;
    }
}
