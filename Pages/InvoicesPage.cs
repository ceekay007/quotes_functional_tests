using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quotes_playwright_test.Pages
{
    public class InvoicesPage
    {
        private readonly IPage _page;
        private string _validateInvoiceCreated => "Draft Invoice Saved";
        private ILocator _messageBox => _page.Locator("id=notify01");


        public InvoicesPage(IPage page)
        {
            _page = page;
        }

        public async Task ValidateDraftInvoiceCreated()
        {
            var result = await _messageBox.TextContentAsync();
            result.Should().Contain(_validateInvoiceCreated);
        }
    }
}
