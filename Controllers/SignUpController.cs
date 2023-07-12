using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using Hotel.Repositories.User_Repository;
using Hotel.Models;

namespace Hotel.Controllers
{
    public class SignUpController : Controller
    {


        private readonly IUserRepository _userRepository;

        public SignUpController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public IActionResult Signing_up()
        {
            return View();
        }




        [HttpPost]
        public IActionResult Signing_up(SignUpModel user)
        {

            if (ModelState.IsValid)
            {
                // Access the form data from the signUpModel object
                int id = user.Id;
                string? fullname = user.Fullname;
                string? email = user.Email;
                string? password = user.Password;
                string? hashedPassword = _userRepository.HashPassword(password);
                DateTime? dateCreated = user.RegDate;


                SignUpModel? UserExist = _userRepository.GetUserByEmail(email);

                if (UserExist is null)
                {
                    _userRepository.AddUser(user);
                    // Redirect to Login page
                    TempData["Message"] = "Registration was successful. Login here.";
                    return RedirectToAction("LoginPage", "Login");

                }
                else
                {
                    TempData["ErrorMessage"] = "User Already Exist.";
                    return View(user);
                }



            }
            else
            {
                // If the model state is not valid, return the view with validation errors
                TempData["ErrorMessage"] = "A problem occurred. Please check your input.";
                return View(user);
            }

        }

    }
}





