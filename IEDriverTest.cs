namespace IEAutomation {
	/// <summary>
	/// Summary description for IEDriverTest.
	/// </summary>
	public class IEDriverTest {
		public IEDriverTest() {
		}

		public void TestGoogle() {
			IEDriver driver = new IEDriver();
			driver.Navigate("http://www.google.com");

			driver.SetInputStringValue("q", "Internet Explorer Automation");
			driver.ClickButton("btnG");
		}
	}
}