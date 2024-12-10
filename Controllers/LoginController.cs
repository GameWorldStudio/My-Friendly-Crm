using Microsoft.AspNetCore.Mvc;
using My_Friendly_CRM.Interfaces;

namespace My_Friendly_CRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private IUsersServices _service { get; set; }

        public LoginController(IUsersServices service)
        {
            _service = service;
        }


    }
}
