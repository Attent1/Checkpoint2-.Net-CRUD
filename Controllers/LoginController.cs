using Checkpont2.Data;
using Checkpont2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Checkpont2.Controllers
{
    public class LoginController : Controller
    {
        private readonly DataContext _context;

        public LoginController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoginValid(User request)
        {
            var user = _context.TB_USERS.FirstOrDefault(x => x.UserEmail == request.UserEmail);
            if (user == null)
            {
                return BadRequest("Email de usuário inexistente");
            }

            if (user.UserPassword != request.UserPassword)
            {
                return BadRequest("Senha incorreta");
            }
            
            return View(user);
        }

    }
}
