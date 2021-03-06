using System;
using System.Configuration;
using System.Windows.Forms;
using System.Xml;
using IEAutomation;
using Microsoft.Win32;

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
            try
            {
                string user, pwd;
                GetFromSettings(out user, out pwd);
                LaunchBrowser(user, pwd);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey(true);
            }
		}

	    static void GetFromSettings(out string user, out string pwd)
	    {
	        user = Properties.Settings.Default.user;
	        pwd = Properties.Settings.Default.pwd;
	        if (Control.ModifierKeys == Keys.Shift || string.IsNullOrEmpty(pwd))
	        {
	            Properties.Settings.Default.user = user;
	            Properties.Settings.Default.pwd = pwd;
	            Properties.Settings.Default.Save();

	            Form1 f = new Form1() { User = user, Password = pwd };
	            var result = f.ShowDialog();
	            if (result != DialogResult.Cancel)
	            {
	                user = f.User;
	                pwd = f.Password;
	                SaveToSetting(user, pwd);
	            }
	        }
        }

        /// <summary>
        /// Creates encrypted user.config file in the following locations if IEDriver.exe is run :
        /// 1. As an exe file - C:\Users\sitsgd\AppData\Local\IEDriver\IEDriver.exe_Url_azq2wh4am4qk1f1ald3xasocro1ifyi5
        /// 2. From Visual Studio - C:\Users\sitsgd\AppData\Local\IEDriver\IEDriver.vshost.exe_Url_azq2wh4am4qk1f1ald3xasocro1ifyi5
        /// 
        /// Creates encrypted user.config file in the following locations if Kirk.exe is run :
        /// C:\Users\sitsgd\AppData\Local\IEDriver\KIRK.exe_Url_2jhgzmuk32ci5k0clocgkrniv2elkcae
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pwd"></param>
        private static void SaveToSetting(string user, string pwd)
	    {
	        var config = ConfigurationManager.OpenExeConfiguration(
	            ConfigurationUserLevel.PerUserRoamingAndLocal);

	        var section = config.GetSection($"userSettings/IEDriver.Properties.Settings") as ClientSettingsSection;

	        section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
	        AddValueToSetting("user", user, section);
	        AddValueToSetting("pwd", pwd, section);
	        config.Save();
	    }

	    private static void AddValueToSetting(string name, string value, ClientSettingsSection section)
	    {
	        var doc = new XmlDocument();
	        doc.LoadXml($"<value>{value}</value>");
	        section.Settings.Get(name).Value = new SettingValueElement()
	        {
	            ValueXml = doc.DocumentElement
	        };
	    }

        private static void LaunchBrowser(string user, string pwd)
	    {
	        string url = "http://spock.sonichealth.com.au/spockprd/spock/asp/Login.asp";
            IEAutomation.IEDriver driver = new IEAutomation.IEDriver();
	        driver.Navigate(url);
	        driver.SetInputStringValueByName("UserId", user);
	        driver.SetInputStringValueByName("Password", pwd);
	        driver.ClickButton("Submit");
	    }
    }
}