namespace OrderProcessing
{
    public interface INotification<Titem>
        where Titem : OrderItem, new()
    {
        void SendNotification(Titem item);
    }
}
