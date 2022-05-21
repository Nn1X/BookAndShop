using BookAndShop.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;


namespace BookAndShop.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public LoginModel(SignInManager<User> signInManager,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }
        
        public string? ReturnUrl { get; set; } = "~/";

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Введите логин")]
            [EmailAddress]
            public string Email { get; set; }

            [Required(ErrorMessage = "Введите пароль")]
            //[DataType(DataType.Password)]
            public string Password { get; set; }
        }

        public async Task OnGetAsync(string? returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }
            var created = await CreateRolesIfNotExist();
            if (!created)
            {
                ModelState.AddModelError(string.Empty, "Роли не были созданы, дальнейшая работа может быть невозможна");
            }


            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            returnUrl ??= Url.Content("~/");

            //ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");


            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return LocalRedirect(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Неверный логин или пароль!");
                    return Page();
                }
            }

            return Page();
        }


        async private Task<bool> CreateRolesIfNotExist()
        {
            List<string> roles = new List<string> { "Admin", "User" };

            foreach (var item in roles)
            {
                var roleExists = await _roleManager.RoleExistsAsync(item);
                if (!roleExists)
                {
                    var result = await _roleManager.CreateAsync(new IdentityRole(item));
                    if (!result.Succeeded)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
