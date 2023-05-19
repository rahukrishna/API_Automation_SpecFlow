using API_Automation_SpecFlow.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace API_Automation_SpecFlow.StepDefinitions
{
    [Binding]
    public class CreateUserRequestAPIValidationsStepDefinitions
    {

        private RestClient restclient;
        private RestRequest request;
        private RestResponse response;
        [Given(@"Want to create the user request")]
        public void GivenWantToCreateTheUserRequest()
        {
            request = new RestRequest(Helpers.Helpers.createUserReq(), Method.Post);
            restclient = new RestClient(Helpers.Helpers.getBaseURL());
        }

        [When(@"passing (.+) and (.+) in the body")]
        public void WhenPassingNameAndJobInTheBody(string name, string job)
        {
            string bodyData = Helpers.BodyData.createRequestData(name, job);
            request.AddBody(bodyData);
            request.RequestFormat = DataFormat.Json;
            restclient = new RestClient(Helpers.Helpers.getBaseURL());
           
        }

        [When(@"retrying the data")]
        public void WhenRetryingTheData()
        {
            response = restclient.Execute(request);
        }

        [Then(@"I should get the response of created request with name (.+) and job (.+)")]
        public void ThenIShouldGetTheResponseOfCreatedRequestWithNameRahulKAndJobEngineer(string name, string job)
        {
            Assert.AreEqual(response.StatusCode.ToString(), "Created");
            var createdUserResponse = JsonConvert.DeserializeObject<CreatedUserResponse>(response.Content.ToString());
            Assert.IsNotNull(createdUserResponse);
            Assert.AreEqual(createdUserResponse.name, name);
            Assert.AreEqual(createdUserResponse.job, job);
            Assert.IsNotNull(createdUserResponse.id);
            Assert.IsNotNull(createdUserResponse.createdAt);
        }

    }
}
