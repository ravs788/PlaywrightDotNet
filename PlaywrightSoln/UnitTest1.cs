// using Microsoft.Playwright;

// namespace PlaywrightSoln;

// public class Tests
// {
//     [SetUp]
//     public void Setup()
//     {
//     }

//     [Test]
//     public async Task Test1()
//     {
//         using var playwright = await Playwright.CreateAsync();

//         await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
//         {
//             Headless = false
//         });

//         var page = await browser.NewPageAsync();

//         await page.GotoAsync(url: "https://www.saucedemo.com/");
//         await page.ClickAsync(selector: "[data-test=\"username\"]");
//         await page.FillAsync(selector: "[data-test=\"username\"]", value: "standard_user");
//         await page.ClickAsync(selector: "[data-test=\"password\"]");
//         await page.FillAsync(selector: "[data-test=\"password\"]", value: "secret_sauce");
//         await page.ClickAsync(selector: "[data-test=\"login-button\"]");
//         var isExist = await page.Locator(selector: "[class=\"app_logo\"]").IsVisibleAsync();

//         Assert.IsTrue(isExist);
//         await page.ScreenshotAsync(new PageScreenshotOptions
//         {
//             Path = "screenshot.jpg"
//         });

//     }
// }