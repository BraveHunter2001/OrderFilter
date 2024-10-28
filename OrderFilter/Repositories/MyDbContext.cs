using OrderFilter.Entities;
using SQLite;

namespace OrderFilter.Repositories;

public static class MyDbContext
{
    public static void InstanseDataBase(string connectionString)
    {
        var _db = new SQLiteConnection(connectionString);

        _db.CreateTable<FilteringResult>();
        _db.CreateTable<OrderResult>();

        var createResult = _db.CreateTable<Order>();
        if (createResult == CreateTableResult.Created)
        {
            List<Order> _orders =
            [
                new Order(50, "region_1", new DateTime(2024, 10, 26, 10, 1, 00)),
                new Order(50, "region_1", new DateTime(2024, 10, 26, 10, 7, 00)),
                new Order(50, "region_1", new DateTime(2024, 10, 26, 10, 15, 10)),
                new Order(50, "region_1", new DateTime(2024, 10, 27, 11, 30, 00)),
                new Order(50, "region_1", new DateTime(2024, 10, 27, 11, 31, 00)),

                new Order(50, "region_2", new DateTime(2024, 10, 26, 10, 2, 00)),
                new Order(50, "region_2", new DateTime(2024, 10, 27, 10, 10, 00)),
                new Order(50, "region_2", new DateTime(2024, 10, 27, 10, 35, 00)),
                new Order(50, "region_2", new DateTime(2024, 10, 28, 10, 36, 00)),

                new Order(50, "region_3", new DateTime(2024, 10, 26, 10, 00, 00)),
            ];
            _db.InsertAll(_orders);
        }
    }
}