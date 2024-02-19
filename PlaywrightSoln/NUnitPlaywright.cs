using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace PlaywrightSoln;

public class NUnitPlaywright : PageTest
{
    [SetUp]
    public async Task SetupAsync()
    {
        await Page.GotoAsync(url: "https://www.saucedemo.com/");
    }

    [Test]
    public async Task Test1()
    {
        await Page.ClickAsync(selector: "[data-test=\"username\"]");
        await Page.FillAsync(selector: "[data-test=\"username\"]", value: "standard_user");
        await Page.ClickAsync(selector: "[data-test=\"password\"]");
        await Page.FillAsync(selector: "[data-test=\"password\"]", value: "secret_sauce");
        await Page.ClickAsync(selector: "[data-test=\"login-button\"]");

        await Expect(Page.Locator(selector: "[class=\"app_logo\"]")).ToBeVisibleAsync();

        await Page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "screenshot.jpg"
        });

    }
}