﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using PageObject.Pages;

namespace PageObject
{
    [TestFixture]
    public class FirefoxRequests
    {
        public IWebDriver driver;

        [SetUp]
        public void OpenBrouser()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.momondo.by";
        }

        [Test]
        public void RequestValidation()
        {
            FlightsPage flights = new FlightsPage(driver);

            string text_Input = "Стамбул";

            flights.InputFromValue(text_Input);
            flights.InputToValue(text_Input);
            flights.PressSearch();

            Assert.AreEqual(flights.get_messageError, "Пожалуйста, задайте конкретные аэропорты отправления (Откуда) и прибытия (Куда).");
        }

        [Test]
        public void HotelRecommendation()
        {
            HotelPage hotel = new HotelPage(driver);
            hotel.OpenHotelPage();
            hotel.IncreaseNumberRooms();

            Assert.AreEqual(hotel.get_messageHotelAdvice, "Поиск 8 и более номеров на HotelPlanner.com");
        }

        [TearDown]
        public void CloseBrouser()
        {
            driver.Close();
        }
    }
}