namespace MediatrAndCqrs.Domain.Model.Order
{
    public class OrderItem
    {
        public OrderItem(int count, string description)
        {
            this.Count = count;
            this.Description = description;
        }

        public int Count { get; }
        public string Description { get; }
    }
}
