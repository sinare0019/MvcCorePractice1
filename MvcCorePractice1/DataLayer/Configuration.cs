using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace MvcCorePractice1.DataLayer
{
    public static class Configuration
    {
        public static async void CreateData(WebApplication app)
        {
            using var scop = app.Services.CreateScope();
            //هر بار یوزر مدیر در دیتابیس نبود انگاه یک یوزر بسازد
            UserManager<IdentityUser> _identityService = scop.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var userExist = _identityService.FindByNameAsync("Admin");
            if (userExist == null)
            {
                var user = new IdentityUser("Admin");
                await _identityService.CreateAsync(user,"123456");
                await _identityService.AddToRoleAsync(user,"Admin");
            }
        }
    }
}
