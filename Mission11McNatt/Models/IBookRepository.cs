namespace Mission11McNatt.Models
{
  public interface IBookRepository
  {
    public IQueryable<Book> Books { get; }
  }
}