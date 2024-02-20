using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace PlaywrightSoln.Pages
{
    public class LoginPage
    {
        private IPage _page;

        public LoginPage(IPage page) => _page = page;
        //private ILocator username => _page.Locator(selector: "[data-test=\"username\"]");
        private ILocator username => _page.GetByPlaceholder("Username");
        //private ILocator password => _page.Locator(selector: "[data-test=\"password\"]");
        private ILocator password => _page.GetByPlaceholder("Password");

        private ILocator loginButton => _page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { Name = "Login"});
        //private ILocator loginButton => _page.Locator(selector: "input")
                //.Filter(new() { HasText = "Login" });
        //private ILocator appLogo => _page.Locator(selector: "text='Swag Labs'");
        private ILocator appLogo => _page.GetByText("Swag Labs");

        public async Task Login(string username, string password)
        {
            await this.username.ClickAsync();
            await this.username.FillAsync(username);
            await this.password.ClickAsync();
            await this.password.FillAsync(password);
            var waitResponse = this._page.RunAndWaitForResponseAsync(async() =>
            {
                await this.loginButton.ClickAsync();
            }, x => x.Url.Contains("inventory.html") && x.Status == 200);
            
        }

        public async Task<bool> IsAppLogoVisible() => await appLogo.IsVisibleAsync(new LocatorIsVisibleOptions
        {
            Timeout = 5000
        });
    }
}