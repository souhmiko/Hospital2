using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hospital2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Encodings.Web;
using System.Text;

namespace Hospital2.Pages.Employee
{
    public class CreateModel : PageModel
    {
        private readonly Hospital2.Models.Hospital2Context _context;
        private readonly UserManager<IdentityUser> userManager;

        public CreateModel(Hospital2.Models.Hospital2Context context,UserManager<IdentityUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        public IActionResult OnGet()
        {
        ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "DepartmentName");
        ViewData["WorkTitleId"] = new SelectList(_context.WorkTitles, "Id", "WorkTitleName");
            return Page();
        }

        [BindProperty]
        public UserDetails UserDetails { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.UserDetails == null || UserDetails == null)
            {
                return Page();
            }
            IdentityUser newAspNetUser = new IdentityUser();
            //newAspNetUser.Email = "test@test.co";
            //newAspNetUser.PhoneNumber = "1212";
            newAspNetUser.UserName = "asd";
            var result = await userManager.CreateAsync(newAspNetUser, "1231231");
            if (result.Succeeded)
            {
                //newAspNetUser.Id
                var userId = await userManager.GetUserIdAsync(newAspNetUser);
                var code = await userManager.GenerateEmailConfirmationTokenAsync(newAspNetUser);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Page(
                    "/Account/ConfirmEmail",
                    pageHandler: null,
                    values: new { area = "Identity", userId = userId, code = code },
                    protocol: Request.Scheme);

                //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                //if (_userManager.Options.SignIn.RequireConfirmedAccount)
                //{
                //    return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                //}
                //else
                //{
                //    await _signInManager.SignInAsync(user, isPersistent: false);
                //    return LocalRedirect(returnUrl);
                //}
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            UserDetails.AspNetUserId = "";

            _context.UserDetails.Add(UserDetails);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
