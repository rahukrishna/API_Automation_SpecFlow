using RestSharp;
using NUnit.Framework;
namespace API_Automation_SpecFlow.StepDefinitions
{
    [Binding, Scope(Feature = "ReqRes")]
    public sealed class ReqResStepDefinitions
    {
        private RestClient restclient;
        private RestRequest request;
        private RestResponse response;
        string url = "https://reqres.in/";

        [Given(@"Need to know the info")]
        public void GivenNeedToKnowTheInfo()
        {
            request = new RestRequest("api/users?page=2", Method.Get);
            restclient = new RestClient(url);
           
            //throw new PendingStepException();
        }
        [When(@"I retrieve the data of list of users")]
        public void WhenIRetrieveTheDataOfListOfUsers()
        {
            response = restclient.Execute(request);
        }


        [Then(@"list should have some values")]
        public void ThenListShouldHaveSomeValues()
        {
            Assert.AreEqual(response.StatusCode.ToString(), "OK");
        }


    }
}