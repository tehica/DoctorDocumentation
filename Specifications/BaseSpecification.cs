using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DoctorDoc1.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        // use this ctor when you want to get list of all entities
        public BaseSpecification()
        {

        }

        // use this ctor what you want to get specific entity (based on id)
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } 
                = new List<Expression<Func<T, object>>>();

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
    }
}
