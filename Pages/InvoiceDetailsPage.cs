using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quotes_playwright_test.Pages
{
    public class InvoiceDetailsPage
    {
        private readonly IPage _page;
        private string _validateInvoiceEditPage => "Save & close";
        private ILocator _btnSaveAndClose => _page.Locator("text=Save & close");


        public InvoiceDetailsPage(IPage page)
        {
            _page = page;
        }

        public async Task ValidateInvoice()
        {
            var result = await _btnSaveAndClose.TextContentAsync();
            result.Should().Be(_validateInvoiceEditPage);
        }

        public async Task SaveDraftInvoice()
        {
            await _btnSaveAndClose.ClickAsync();
        }
    }
}
