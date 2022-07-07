using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quotes_playwright_test.Pages
{
    public class QuoteDetailsPage
    {
        private readonly IPage _page;
        private string _validateAccepted => "Accepted";
        private ILocator _txtAccepted => _page.Locator("text=Accepted");
        private ILocator _btnCreateInvoice => _page.Locator("text=Create invoice");
        private ILocator _btnCreate => _page.Locator("[aria-label=\"Create\"]");


        public QuoteDetailsPage(IPage page)
        {
            _page = page;
        }

        public async Task ValidateQuoteIsAccepted()
        {
            var result = await _txtAccepted.TextContentAsync();
            result.Should().Contain(_validateAccepted);
        }
             
        public async Task CreateInvoice()
        {
            await _btnCreateInvoice.ClickAsync();
            await _btnCreate.ClickAsync();
        }
    }
}
