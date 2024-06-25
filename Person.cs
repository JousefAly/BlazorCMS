namespace AuctionTypesCMS
{
    public record Person(int Id, string Name)
    {
        public Person() : this(default, default)
        {
            
        }
    }
}
