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
                return BadRequest("User already registered");
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

            return RedirectToAction("SignUpSuccess", new { userId = newUser.Id } );

        }

        public IActionResult SignUpSuccess(int userId)
        {                                                    
            User userFound = _context.TB_USERS.FirstOrDefault(u => u.Id == userId);

            if (userFound == null)
            {
                return BadRequest("User doesn't exist");
            }            
            
            return View(userFound);
        }

        public IActionResult Update(int id)
        {
            var user = _context.TB_USERS.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return BadRequest("User doesn't exist");
            }

            return View(user);

        }

        public IActionResult UpdateUser(User request)
        {
            var user = request;

            user.Id = request.Id;
            user.UserEmail = request.UserEmail;
            user.UserName = request.UserName;
            user.UserPassword = request.UserPassword;
            user.UserOccupation = request.UserOccupation;            

            _context.Update(user);            
            _context.SaveChanges();

            return RedirectToAction("SignUpSuccess", new { userId = user.Id });

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
