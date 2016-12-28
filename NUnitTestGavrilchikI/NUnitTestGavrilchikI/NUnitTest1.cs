using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using OpenQA.Selenium.Interactions;
//using NUnit.Framework;

namespace NUnitTestGavrilchikI
{
    [TestFixture]

    public class AnimeOnlineTests
    {
        private IWebDriver Browser;

        [OneTimeSetUp]
        public void Setup()
        {
            Browser = new ChromeDriver();
            Browser.Manage().Window.Maximize();
            Browser.Navigate().GoToUrl("http://AnimeOnline.su/");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Browser.Quit();
        }


        [Test]
        public void TestSearch()
        {
            IWebElement Search = Browser.FindElement(By.Id("fastSearch"));
            Search.SendKeys("Danmachi" + OpenQA.Selenium.Keys.Enter);
            string currentUrl = Browser.Url;
            IWebElement Element = Browser.FindElement(By.ClassName("label_rus"));
            Element.Click();
            Element = Browser.FindElement(By.ClassName("nameMain"));
            string elementText = Element.Text;
            Assert.IsTrue("Может, я встречу тебя в подземелье?".Equals(elementText));
        }
        [Test]
        public void LogInTest()
        {
            IWebElement LogIn = Browser.FindElement(By.Id("panelLoginButton"));
            LogIn.Click();
            LogIn = Browser.FindElement(By.Id("login"));
            LogIn.SendKeys("animesh322");
            LogIn = Browser.FindElement(By.Id("password"));
            LogIn.SendKeys("qwerty321" + OpenQA.Selenium.Keys.Enter);
            Thread.Sleep(1000);
            LogIn = Browser.FindElement(By.Id("panelLogin"));
            LogIn.Click();
            LogIn = Browser.FindElement(By.XPath("//*[@id='userinfo']/div[1]/div[1]"));
            string elementText = LogIn.Text;
            Assert.IsTrue("Пользователь:  Animesh322".Equals(elementText));
            LogIn = Browser.FindElement(By.Id("panelOut"));
            LogIn.Click();
        }
        [Test]
        public void RadioTest()
        {
            Browser.Navigate().GoToUrl("http://AnimeOnline.su/");
            IWebElement RadioPlay = Browser.FindElement(By.ClassName("play"));
            IWebElement RadioPause = Browser.FindElement(By.ClassName("pause"));
            RadioPlay.Click();
            string elementText = RadioPlay.GetAttribute("style");
            string elementText1 = RadioPause.GetAttribute("style");
            Assert.IsTrue("display: none;".Equals(elementText)&& "display: inline;".Equals(elementText1));
            RadioPause.Click();
            elementText = RadioPlay.GetAttribute("style");
            elementText1 = RadioPause.GetAttribute("style");
            Assert.IsTrue("display: none;".Equals(elementText1)&& "display: block;".Equals(elementText));
        }
        [Test]
        public void MenuTest()
            {

            IWebElement Genre = Browser.FindElement(By.XPath("//*[@id='panel']/ul[1]/li[1]/span[1]"));
            Actions builder = new Actions(Browser);
            Actions hoverClick = builder.MoveToElement(Genre).Click();
            hoverClick.Build().Perform();
            Thread.Sleep(2000);
            IWebElement GenreMenu = Browser.FindElement(By.XPath("//*[@id='panel']/ul[1]/li[1]/ul"));
            string elementText = GenreMenu.GetAttribute("style");
            Assert.IsTrue("width: 650px; display: block;".Equals(elementText));
        }
        [Test]
        public void AddToMyAnime()
        {
            IWebElement LogIn = Browser.FindElement(By.Id("panelLoginButton"));
            LogIn.Click();
            LogIn = Browser.FindElement(By.Id("login"));
            LogIn.SendKeys("animesh322");
            LogIn = Browser.FindElement(By.Id("password"));
            LogIn.SendKeys("qwerty321" + OpenQA.Selenium.Keys.Enter);
            Thread.Sleep(3000);
            IWebElement Anime = Browser.FindElement(By.XPath("//*[@id='main_block_anime']/div[2]/div[1]/div[1]"));
            Anime.Click();
            IWebElement AnimeName = Browser.FindElement(By.ClassName("nameMain"));
            string elementText = AnimeName.Text;
            Anime = Browser.FindElement(By.XPath("//*[@id='player_info']/div[2]/div[2]"));
            Anime.Click();
            Anime = Browser.FindElement(By.XPath("//*[@id='player_info']/div[2]/div[2]/ul/li[3]/a"));
            Anime.Click();
            Browser.Navigate().GoToUrl("http://animeonline.su/user/Animesh322/myanime/");
            Anime = Browser.FindElement(By.XPath("//*[@id='myanimeCtrl']/div/div[2]/div[2]/div[2]/div/a[2]/span/img"));
            Anime.Click();
            IWebElement AnimeNameMyAnime = Browser.FindElement(By.ClassName("nameMain"));
            string elementText1 = AnimeNameMyAnime.Text;
            Assert.IsTrue((elementText).Equals(elementText1));
            Anime = Browser.FindElement(By.XPath("//*[@id='player_info']/div[2]/div[2]"));
            Anime.Click();
            Anime = Browser.FindElement(By.XPath("//*[@id='player_info']/div[2]/div[2]/ul/li[1]/a"));
            Anime.Click();
            Anime = Browser.FindElement(By.Id("panelOut"));
            Anime.Click();
        }
    }
}