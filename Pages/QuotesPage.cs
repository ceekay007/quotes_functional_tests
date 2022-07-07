using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quotes_playwright_test.Pages
{
    public class QuotesPage
    {
        private readonly IPage _page;
        private string _urlAcceptedQuoteDetails => "https://go.xero.com/app/!-1ZqQ/quotes/view/38fccbe4-3f92-4de1-bb7f-8d13e5bfc468";
        private ILocator _quoteNumber => _page.Locator("text=TestQuote-...");


        public QuotesPage(IPage page)
        {
            _page = page;
        }

        public async Task NavigateToQuoteDetailsPage()
        {
            await _page.GotoAsync(_urlAcceptedQuoteDetails);
        }
    }
}
