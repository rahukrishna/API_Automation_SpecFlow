using API_Automation_SpecFlow.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace API_Automation_SpecFlow.StepDefinitions
{
    [Binding]
    public class UpdateUsersAPiValidationsStepDefinitions
    {
        private RestClient restclient;
        private RestRequest request;
        private RestResponse response;
        [Given(@"Want to update the user details")]
        public void GivenWantToUpdateTheUserDetails()
        {
            request = new RestRequest(Helpers.Helpers.updateUserReq(), Method.Put);
            restclient = new RestClient(Helpers.Helpers.getBaseURL());
        }

        [When(@"Passing the name (.+) and new Job (.+)")]
        public void WhenPassingTheNameRahulKAndNewJobArchitect(string name, string newJob)
        {
            string bodyData = Helpers.BodyData.updateRequestData(name, newJob);
            request.AddBody(bodyData);
            request.RequestFormat = DataFormat.Json;            
        }

        [When(@"retrying the update data")]
        public void WhenRetryingTheUpdateData()
        {
            response = restclient.Execute(request);
        }

        [Then(@"I should get the response of updated response with name (.+) and new job (.+)")]
        public void ThenIShouldGetTheResponseOfUpdatedResponseWithNameRahulKAndNewJobArchitect(string name, string newJob)
        {
            Assert.AreEqual(response.StatusCode.ToString(), "OK");
            var updatedUserResponse = JsonConvert.DeserializeObject<UpdatedUserResponse>(response.Content.ToString());
            Assert.IsNotNull(updatedUserResponse);
            Assert.IsNotNull(updatedUserResponse.updatedAt);
            Assert.AreEqual(updatedUserResponse.name, name);
            Assert.AreEqual(updatedUserResponse.job, newJob);
            
        }
    }
}
