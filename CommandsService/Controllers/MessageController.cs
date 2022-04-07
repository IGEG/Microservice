using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class MessageController:ControllerBase
    {
      public MessageController()
      {
          
      }

      [HttpPost]
      public ActionResult TestConnection()
      {
          Console.WriteLine("the test from MessageController");
          return Ok("test MessageController");
      }

    }
}