using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
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
