﻿using ePizzaHub.Repositories.Models;
using ePizzaHub.Services.Interfaces;
using ePizzaHub.WebUI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ePizzaHub.WebUI.Areas.User.Controllers
{
    public class OrderController : BaseController
    {
        IOrderService _orderService;
        public OrderController(IOrderService orderService, IUserAccessor userAccessor) : base(userAccessor)
        {
            _orderService = orderService;
        }
        public IActionResult Index()
        {
            var orders = _orderService.GetUserOrders(CurrentUser.Id);
            return View(orders);
        }

        [Route("~/User/Order/Details/{OrderId}")]
        public IActionResult Details(string OrderId)
        {
            OrderModel Order = _orderService.GetOrderDetails(OrderId);
            return View(Order);
        }
    }
}
