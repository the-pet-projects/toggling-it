namespace IntegrationTests.Values
{
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using IntegrationTests.Configuration;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;

    [TestClass]
    public class ValuesTest
    {
        [TestMethod]
        public async Task GetValues_ValidCall_ReturnsTwoValues()
        {
            // Arrange
            var httpclient = new HttpClient();

            // Act
			try {
            var act = await httpclient.GetAsync(AppSettings.Current.ApiEndpoint + "api/values").ConfigureAwait(false);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, act.StatusCode);
            var values = JsonConvert.DeserializeObject<string[]>(await act.Content.ReadAsStringAsync().ConfigureAwait(false));
            Assert.AreEqual(2, values.Length);
            Assert.IsTrue(values.Contains("value1"));
            Assert.IsTrue(values.Contains("value2"));
			} catch (Exception ex) {
				Assert.Fail("APIENDPOINT=" + AppSettings.Current.ApiEndpoint + "api/values" + "\n" + ex.ToString());
			}
        }
    }
}