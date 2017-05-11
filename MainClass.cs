using System;
using IEAutomation;

namespace IEDriver {
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class MainClass {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args) {
            //IEDriverTest ieDriverTest = new IEDriverTest();
            //ieDriverTest.TestGoogle();
		    UseIEDriver();

		}

	    private static string url = "http://spock.sonichealth.com.au/spockprd/spock/asp/Login.asp";
        private static void UseIEDriver()
	    {
	        IEAutomation.IEDriver driver = new IEAutomation.IEDriver();
	        driver.Navigate(url);
	        driver.SetInputStringValueByName("UserId", "sitsgd");
	        driver.SetInputStringValueByName("Password", "Asdf@1212");
	        driver.ClickButton("Submit");
	    }
    }
}