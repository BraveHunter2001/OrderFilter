using OrderFilter.Entities;
using SQLite;

namespace OrderFilter.Repositories;

public interface IOrderRepository
{
    List<Order> GetOrders(string regionName, DateTime startDateTime, DateTime endDateTime);
}

public class OrderRepository : IOrderRepository
{
    private readonly SQLiteConnection _db;

    public OrderRepository(IConfiguration configuration)
    {
        string connect = configuration.GetValue<string>("ConnectionString");
        _db = new SQLiteConnection(connect);
    }

    public List<Order> GetOrders(string regionName, DateTime startDateTime, DateTime endDateTime)
    {
        return _db.Table<Order>().Where(o => o.Region == regionName
                                             && o.DeliveryDateTime >= startDateTime
                                             && o.DeliveryDateTime <= endDateTime
        ).ToList();
    }
}