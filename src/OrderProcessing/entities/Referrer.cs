namespace OrderProcessing
{
    public class Referrer : User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public float CommissionEarned {get; set;}

        public void AddComission(float amount)
        {
            // add comission
        }
    }
}
