using System;
using TechTalk.SpecFlow;
using quotes_playwright_test.Pages;
using Microsoft.Playwright;

namespace quotes_playwright_test.StepDefinitions
{
    [Binding]
    public class QuotesStepDefinitions
    {
        private LoginPage loginPage;
        private InvoicesPage invoicesPage;
        private InvoiceDetailsPage invoiceDetailsPage;
        private NavigationHeader navigationHeader;
        private QuoteDetailsPage quoteDetailsPage;
        private QuotesPage quotesPage;


        public QuotesStepDefinitions(IPage page)
        {
            loginPage = new LoginPage(page);
            invoicesPage = new InvoicesPage(page);
            invoiceDetailsPage = new InvoiceDetailsPage(page);
            navigationHeader = new NavigationHeader(page);
            quoteDetailsPage = new QuoteDetailsPage(page);
            quotesPage = new QuotesPage(page);
        }

        [Given(@"a user is logged in")]
        public async Task GivenAUserIsLoggedIn()
        {
            await loginPage.LaunchApp();
            await loginPage.SetUsername();
            await loginPage.SetPassword();
            await loginPage.ClickLoginButton();
            await navigationHeader.ValidateSuccessfulLogin();
            await navigationHeader.ValidateSuccessfulLogin();
        }

        [Given(@"an accepted quote exists")]
        public async Task GivenAnAcceptedQuoteExists()
        {
            await quotesPage.NavigateToQuoteDetailsPage();
            await quoteDetailsPage.ValidateQuoteIsAccepted();
        }

        [When(@"user creates an invoice from an accepted quote")]
        public async Task WhenUserCreatesAnInvoiceFromAnAcceptedQuote()
        {
            await quoteDetailsPage.CreateInvoice();
            await invoiceDetailsPage.ValidateInvoice();
            await invoiceDetailsPage.SaveDraftInvoice();
        }

        [Then(@"draft invoice is created")]
        public async Task ThenDraftInvoiceIsCreated()
        {
            await invoicesPage.ValidateDraftInvoiceCreated();
        }
    }
}
