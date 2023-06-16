namespace Library.Controllers
{
    using System.Security.Claims;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class BaseController : Controller
    {
        protected string GetUserId()
        {
            //string userId = string.Empty;
            //if (User != null)
            //{
            //    userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //}
            //return userId;
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

    }


}
