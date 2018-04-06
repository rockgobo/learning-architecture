namespace lifbi.bookers.model
{
    public interface IBooksRepository : IUnitOfWorkRepository<Book>
    {
        Book GetMostExpensiveBook();
    }
}