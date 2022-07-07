using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quotes_playwright_test.Pages
{
    public class NavigationHeader
    {
        private readonly IPage _page;
        private string _validateNav => "Business";
        private ILocator _navBtnBusiness => _page.Locator("button:has-text(\"Business\")");


        public NavigationHeader(IPage page)
        {
            _page = page;
        }

        public async Task ValidateSuccessfulLogin()
        {
            var result = await _navBtnBusiness.TextContentAsync( new() { Timeout = 30000 });
            result.Should().Be(_validateNav);
        }
    }
}
