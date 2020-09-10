namespace DraftkingsSampleProject
{
    using System;
    using System.Collections.Generic;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Android;
    using NUnit.Framework;

    /// <summary>
    /// Sauce tests
    /// </summary>
    public class SomeTests
    {
        /// <summary>
        /// Executing this test will create a session on an Emulator.
        /// Although it says that there is no concurrency available, the session is created.
        /// </summary>
        [Test]
        public void WorkingVirtualCloudEmulator()
        {
            AppiumOptions driverOptions = new AppiumOptions(){PlatformName = "Android"};

            Dictionary<string, object> opts = new Dictionary<string, object>();

            opts.Add("username", "lyubomir.st");
            opts.Add("accessKey", "af900287-982e-4c86-9036-80fedc507478");

            driverOptions.AddAdditionalOption("sauce:options", opts);
            driverOptions.AddAdditionalAppiumOption("deviceName", "Android GoogleAPI Emulator");
            driverOptions.AddAdditionalAppiumOption("app", "https://github.com/saucelabs/sample-app-mobile/releases/download/2.3.0/Android.SauceLabs.Mobile.Sample.app.2.3.0.apk");
            driverOptions.AddAdditionalAppiumOption("platformVersion", "10");
  
            var driver = new AndroidDriver<IWebElement>(new Uri("https://lyubomir.st:af900287-982e-4c86-9036-80fedc507478@ondemand.eu-central-1.saucelabs.com:443/wd/hub"), driverOptions, TimeSpan.FromMinutes(15));
        }

        /// <summary>
        /// Executing this test will try to create a session in the new Sauce platform (not RDC) and run on a real device. Does not work.
        /// There is no thrown exception during runtime, but we get the an error message in driver.Capabilities
        /// Also I did not find in the documentation how to distinguish between Emulator and Real devices. I guess you are doing this on your side by looking at the deviceName cap.
        /// </summary>
        [Test]
        public void NotWorkingVirtualCloudRealDevice()
        {
            AppiumOptions driverOptions = new AppiumOptions() { PlatformName = "Android" };

            Dictionary<string, object> opts = new Dictionary<string, object>();

            opts.Add("username", "lyubomir.st");
            opts.Add("accessKey", "af900287-982e-4c86-9036-80fedc507478");

            driverOptions.AddAdditionalOption("sauce:options", opts);
            driverOptions.AddAdditionalAppiumOption("deviceName", "Samsung*");
            driverOptions.AddAdditionalAppiumOption("app", "https://github.com/saucelabs/sample-app-mobile/releases/download/2.3.0/Android.SauceLabs.Mobile.Sample.app.2.3.0.apk");
            driverOptions.AddAdditionalAppiumOption("platformVersion", "10");
   
            var driver = new AndroidDriver<IWebElement>(new Uri("https://lyubomir.st:af900287-982e-4c86-9036-80fedc507478@ondemand.eu-central-1.saucelabs.com:443/wd/hub"), driverOptions, TimeSpan.FromMinutes(15));

            Assert.Fail(driver.Capabilities.ToString());
        }

        /// <summary>
        /// Executing this test will try to create a session in RDC while passing w3c credentials.
        /// A Null Reference exception is thrown without any meaningful text.
        /// If you attach Appium and Selenium repos to the solution and you are able to step into the different methods there you will see that the REST call for creating session returns "Forbidden".
        /// </summary>
        [Test]
        public void NotWorkingRDCWithW3CCredentials()
        {
            AppiumOptions driverOptions = new AppiumOptions() { PlatformName = "Android" };

            Dictionary<string, object> opts = new Dictionary<string, object>();

            opts.Add("username", "lyubomir.st");
            opts.Add("accessKey", "af900287-982e-4c86-9036-80fedc507478");

            driverOptions.AddAdditionalOption("sauce:options", opts);
            driverOptions.AddAdditionalAppiumOption("platformVersion", "10");
            driverOptions.AddAdditionalAppiumOption("testobject_api_key", "20C1752A9FCC4FF590C2D30A2AACE54A");

            var driver = new AndroidDriver<IWebElement>(new Uri("https://eu1.appium.testobject.com/wd/hub"), driverOptions, TimeSpan.FromMinutes(15));

            Assert.Fail(driver.Capabilities.ToString());
        }

        /// <summary>
        /// Executing this test will try to create a session in RDC without passing w3c credentials.
        /// A Null Reference exception is thrown without any meaningful text.
        /// If you attach Appium and Selenium repos to the solution and you are able to step into the different methods there you will see that the REST call for creating session returns "Forbidden".
        /// </summary>
        [Test]
        public void NotWorkingRDCWithoutW3CCredentials()
        {
            AppiumOptions driverOptions = new AppiumOptions() { PlatformName = "Android" };

            driverOptions.AddAdditionalAppiumOption("platformVersion", "10");
            driverOptions.AddAdditionalAppiumOption("testobject_api_key", "20C1752A9FCC4FF590C2D30A2AACE54A");

            var driver = new AndroidDriver<IWebElement>(new Uri("https://eu1.appium.testobject.com/wd/hub"), driverOptions, TimeSpan.FromMinutes(15));

            Assert.Fail(driver.Capabilities.ToString());
        }
    }
}
