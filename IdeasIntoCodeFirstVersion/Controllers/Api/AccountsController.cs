using IdeasIntoCodeFirstVersion.Models;
using IdeasIntoCodeFirstVersion.Persistence;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Web.Http.Cors;
using System.Web;


namespace IdeasIntoCodeFirstVersion.Controllers.Api
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AccountsController : ApiController
    {
        private ApplicationDbContext context;
        private readonly UnitOfWork unitOfWork;

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;


        public AccountsController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.GetOwinContext()
                    .Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext()
                    .GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        public async Task<IHttpActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, Name = model.Name, LastName = model.LastName };

                var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    //var dev = context.Developers.Where(d => d.User==user).SingleOrDefault();
                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href="" + callbackUrl + "">here</a>");
                    //UserManager.AddToRole(user.Id, "User");
                    context.Developers.Add(new Developer { UserID = user.Id, DateCreated = DateTime.Now, BirthDate = DateTime.Now });
                    context.SaveChanges();

                   
                }
            }

            // If we got this far, something failed, redisplay form
            return Ok(model);
            
        }
        public AccountsController()
        {
            context = new ApplicationDbContext();
            unitOfWork = new UnitOfWork(context);
        }

        //[HttpPost]
        ////[AllowAnonymous]
        ////[ValidateAntiForgeryToken]

        //public async Task<IHttpActionResult> Login(LoginViewModel model)
        //{
           
        //    var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
        //    var user = context.Users.SingleOrDefault(u => u.Email == model.Email);
        //    var userId = user.Id;
        //    var developer = context.Developers.SingleOrDefault(d => d.UserID == userId);

        //    return Ok(developer);
        //}

        [HttpPost]
        [AllowAnonymous]
        
        public async Task<IHttpActionResult> Login(LoginViewModel model)
        {
          

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            var developer = context.Developers.SingleOrDefault(d => d.ID == 1);

            //switch (result)
            //{
            //    case SignInStatus.Success:
            //        var user = context.Users.SingleOrDefault(u => u.Email == model.Email);
            //        var userId = user.Id;
                    

            //        return Ok(developer);
            //}
            return Ok(developer);
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }


    }
}