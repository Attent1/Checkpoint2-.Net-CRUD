using Checkpont2.Data;
using Microsoft.AspNetCore.Mvc;

namespace Checkpont2.Controllers
{
    public class UsersController:Controller
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var users = _context.TB_USERS.ToList();
            return View(users);
        }
    }
}
