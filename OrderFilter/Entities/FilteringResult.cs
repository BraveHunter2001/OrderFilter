using SQLite;

namespace OrderFilter.Entities;

public class FilteringResult
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [Ignore]
    public List<Order> Orders { get; set; }
}

public class OrderResult
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public int OrderId { get; set; }
    public int FilteringResultId { get; set; }

    public OrderResult()
    {
    }

    public OrderResult(int orderId, int filteringResultId)
    {
        OrderId = orderId;
        FilteringResultId = filteringResultId;
    }
}