using OrderFilter.Entities;
using SQLite;

namespace OrderFilter.Repositories;

public interface IResultRepository
{
    void InsertResult(FilteringResult result);
}

public class ResultRepository : IResultRepository
{
    private readonly SQLiteConnection _db;

    public ResultRepository(IConfiguration configuration)
    {
        string connect = configuration.GetValue<string>("ConnectionString");
        _db = new SQLiteConnection(connect);
    }

    public void InsertResult(FilteringResult result)
    {
        _db.Insert(result);
        var orderResults = result.Orders.Select(o => new OrderResult(o.Id, result.Id));
        _db.InsertAll(orderResults);
    }
}