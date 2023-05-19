using System;
using RestSharp;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace API_Automation_SpecFlow.StepDefinitions
{
    [Binding]
    public class ReqresAPIValidationsStepDefinitions
    {

        private RestClient restclient;
        private RestRequest request;
        private RestResponse response;
        string url = "https://reqres.in/";


        [Given(@"Want to know the users list")]
        public void GivenWantToKnowTheUsersList()
        {
            request = new RestRequest("api/users?page=2", Method.Get);
            restclient = new RestClient(url);
        }

        [When(@"I retrive the data of users list")]
        public void WhenIRetriveTheDataOfUsersList()
        {

            response = restclient.Execute(request);
        }

        [Then(@"Users list should contain some value")]
        public void ThenUsersListShouldContainSomeValue()
        {
            Assert.AreEqual(response.StatusCode.ToString(), "OK");
        }
    }
}
