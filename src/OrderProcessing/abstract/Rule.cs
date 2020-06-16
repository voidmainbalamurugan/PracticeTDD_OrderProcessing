namespace OrderProcessing
{
    public abstract class Rule<Titem>
     where Titem : OrderItem, new()
     {
        protected abstract bool PreValidation(Titem item);
        protected abstract void Apply(Titem item);

        public void Complete(Titem item)
        {
            // null-check

            if(this.PreValidation(item))
                Apply(item);
        }
     }
}
