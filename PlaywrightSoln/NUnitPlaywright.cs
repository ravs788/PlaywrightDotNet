using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Allure.Core;
using PlaywrightSoln.Classes;
using PlaywrightSoln.Pages;
using PlaywrightSoln.Utilities;
using static System.Net.Mime.MediaTypeNames;

namespace PlaywrightSoln;

[AllureNUnit]
[Parallelizable(ParallelScope.Self)]
public class NUnitPlaywright : PageTest
{
    private IPage page;
    
    [SetUp]
    public async Task SetupAsync()
    {

        page = await Context.NewPageAsync();
        await page.GotoAsync(url: "https://www.saucedemo.com/", new PageGotoOptions
        {
            WaitUntil = WaitUntilState.DOMContentLoaded,

        });
    }

    [Test]
    public async Task SauceDemoLogin()
    {

        Page.SetDefaultTimeout(10000);
        LoginPage loginPage = new LoginPage(page);

        page.Request += (_, request) => Console.WriteLine(request.Method + "---- " + request.Url);
        page.Response += (_, response) => Console.WriteLine(response.Status + "---- " + response.Url);
        string testDataFileName = "SauceDemoLogin";
        IEnumerable<Credentials> credentials = CSVUtility.ReadCSV<Credentials>(testDataFileName);
        await loginPage.Login(credentials.First().UserName, credentials.First().Password);
        var isExist = await loginPage.IsAppLogoVisible();
        Assert.IsTrue(isExist);


    }
}