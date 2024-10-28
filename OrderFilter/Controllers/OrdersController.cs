using Microsoft.AspNetCore.Mvc;
using OrderFilter.Entities;
using OrderFilter.Model;
using OrderFilter.Repositories;

namespace OrderFilter.Controllers;

[Route("api/[controller]")]
[ApiController]

public class OrdersController(IOrderRepository orderRepository, IResultRepository resultRepository) : ControllerBase
{
    [HttpGet]
    public IActionResult GetOrders([FromQuery] OrderFilterModel orderFilterModel)
    {
        if (string.IsNullOrWhiteSpace(orderFilterModel.Region))
            return BadRequest("Неправильно заданн регион");

        if (orderFilterModel.StartDate == DateTime.MinValue)
            return BadRequest("Неправильно заданна дата");

        DateTime finishDateTime = orderFilterModel.StartDate.AddMinutes(30);
        var filteredOrders = orderRepository.GetOrders(orderFilterModel.Region, orderFilterModel.StartDate, finishDateTime);
        var result = new FilteringResult() { Orders = filteredOrders };
        resultRepository.InsertResult(result);

        return filteredOrders.Count != 0 ? Ok(result) : NotFound("Заказы не найдены");
    }
}