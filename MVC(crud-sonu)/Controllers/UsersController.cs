using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_crud_sonu_.Context;
using MVC_crud_sonu_.DAL;
using MVC_crud_sonu_.Models;

namespace MVC_crud_sonu_.Controllers
{
    public class UsersController : Controller
    {

        private readonly IJWTManagerRepository _jWTManager;

        private readonly AnimaMvcContext _context;
        public UsersController(IJWTManagerRepository jWTManager, AnimaMvcContext context)
        {
            this._jWTManager = jWTManager;
                 _context = context;
        }

        public IActionResult LoginForm()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate(Users users)
        {
            var token =  _jWTManager.Authenticate(users);

            if (token.Result == null)
            {
                return Unauthorized();
            }
            return RedirectToAction(actionName: "AnimalTable", controllerName: "Animal");
        }
    }
}
