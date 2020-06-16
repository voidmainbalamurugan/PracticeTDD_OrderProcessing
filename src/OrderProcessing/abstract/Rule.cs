using System;

namespace OrderProcessing
{
    public abstract class Rule<Titem> : IDisposable
     where Titem : OrderItem, new()
     {
        protected abstract bool PreValidation(Titem item);
        protected abstract void Apply(Titem item);

        public void Complete(Titem item)
        {
            // null-check
            if(item == default(Titem))
                throw new ArgumentNullException(nameof(Titem));

            if(this.PreValidation(item))
                Apply(item);
        }

        public virtual void Dispose()
        {
            
        }
    }
}
