namespace lifbi.bookers.model
{
    public class Stock : Entity
    {
        public Book Book { get; set; }
        public int Amount { get; set; }
    }
}