namespace MediatrAndCqrs.Domain.Model.Order
{
    public class OrderItem
    {
        public OrderItem(int id, int count, string description)
        {
            this.Id = id;
            this.Count = count;
            this.Description = description;
        }

        public int Id { get; }
        public int Count { get; }
        public string Description { get; }
    }
}
