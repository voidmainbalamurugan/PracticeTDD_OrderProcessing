namespace OrderProcessing
{
    public interface IRulesManager
    {
        IRulesRepo RulesRepo {get;}
        void Process(Product product);
        void Process(NewMembership membership);
        void Process(ActiveMembership membership);
        void Process(Book book);
        void Process(VideoContent video);

        void Process(FreeVideoContent video);
    }
}
