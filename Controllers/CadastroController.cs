using Checkpont2.Data;
using Checkpont2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Checkpont2.Controllers
{
    public class CadastroController : Controller
    {
        private readonly DataContext _context;

        public CadastroController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignUp(User request)
        {
            var user = _context.TB_USERS.FirstOrDefault(x => x.UserEmail == request.UserEmail);
            if (user != null)
            {
                return BadRequest("Usuário já cadastrado");
            }

            User newUser = new User
            {
                UserEmail = request.UserEmail,
                UserName = request.UserName,
                UserPassword = request.UserPassword,
                UserOccupation = request.UserOccupation
            };

            _context.Add(newUser);
            _context.SaveChanges();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
