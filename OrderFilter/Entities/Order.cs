using SQLite;

namespace OrderFilter.Entities;

public class Order
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    /// <summary>
    /// Вес в килограммах
    /// </summary>
    public double Weight { get; set; }

    public string Region { get; set; }

    public DateTime DeliveryDateTime { get; set; }

    public Order()
    {
    }

    public Order(double weight, string region, DateTime deliveryDateTime)
    {
        Weight = weight;
        Region = region;
        DeliveryDateTime = deliveryDateTime;
    }
}