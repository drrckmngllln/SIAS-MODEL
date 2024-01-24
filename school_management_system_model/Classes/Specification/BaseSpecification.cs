using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Classes.Specification
{
    internal class BaseSpecification<T> : ISpecification<T>
    {
        public int Take { get; private set; }

        public int Skip { get; private set; }
        public bool isPagingEnabled { get; private set; }

        protected void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            isPagingEnabled = true;
        }
    }
}
