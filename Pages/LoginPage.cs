using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quotes_playwright_test.Pages
{
    public class LoginPage //: BasePage
    {
        private readonly IPage _page;
        private string _appUrl => "https://login.xero.com/identity/user/login";
        private ILocator _txtUserName => _page.Locator("[placeholder=\"Email address\"]");
        private ILocator _txtPassword => _page.Locator("[placeholder=\"Password\"]");
        private ILocator _btnLogin => _page.Locator("button:has-text(\"Log in\")");
        private string _userName => Environment.GetEnvironmentVariable("userName");
        private string _password => Environment.GetEnvironmentVariable("password");


        public LoginPage(IPage page)
        {
            _page = page;
        }

        public async Task LaunchApp()
        {
            await _page.GotoAsync(_appUrl);
        }
      
        public async Task SetUsername()
        {
            await _txtUserName.FillAsync(_userName);
        }

        public async Task SetPassword()
        {
            await _txtPassword.FillAsync(_password);
        }

        public async Task ClickLoginButton()
        {
            await _page.RunAndWaitForResponseAsync(async () =>
            {
                await _btnLogin.ClickAsync();

            }, response => response.Status == 200);            
        }
    }
}
