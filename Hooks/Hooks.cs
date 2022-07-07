using TechTalk.SpecFlow;
using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using BoDi;

namespace quotes_playwright_test.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private IPage _page;
        private readonly IObjectContainer _objectContainer;


        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario("@invoice")]
        public async Task InitializeBrowser()
        {
             var _playwright = await Playwright.CreateAsync();
             var _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true,
                //SlowMo = 1000
            });
            
             _page = await _browser.NewPageAsync();
            
            _objectContainer.RegisterInstanceAs(_playwright);
            _objectContainer.RegisterInstanceAs(_browser);
            _objectContainer.RegisterInstanceAs(_page);
        }

        [AfterScenario]
        public async Task AfterScenario(IObjectContainer objectContainer)
        {
            var _browser = objectContainer.Resolve<IBrowser>();
            await _browser.CloseAsync();
            var _playwright = objectContainer.Resolve<IPlaywright>();
            _playwright.Dispose();
        }
    }
}