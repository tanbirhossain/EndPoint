using EndPoint.Model;
using EndPoint.Resources;
using EndPoint.Result.AspNetCore;
using EndPoint.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;

namespace EndPoint.Controllers
{
    [ApiController]
    [Route("{culture:culture}/api/[controller]")]

    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMessageService _messageService;

        public CustomerController(ICustomerService customerService, IMessageService messageService)
        {
            _customerService = customerService;
            _messageService = messageService;
        }

        [TranslateResultToActionResult]
        [HttpPost]
        public IActionResult Add(Customer customer)
        {
            var result = _customerService.Add(customer);
           
            var okResult = result.GetValue();

            return Ok(okResult);

            //return Ok(result);
        }

        [HttpGet]
        [TranslateResultToActionResult]
        public IActionResult Get()
        {

            var list = new List<object>
            {
                new { Name = "kashem", Age = 1},
                new { Name = "kashem1", Age = 11},
                new { Name = "kashem2", Age = 111},
                new { Name = "kashem2", Age = 111, Address = "Bangladesh"}
            };



            var msg = string.Format(_messageService.Get(MessageKey.AddCustomerSuccess), "Kashem");
            return Ok(list);
        }
    }
}
