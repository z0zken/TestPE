﻿using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
