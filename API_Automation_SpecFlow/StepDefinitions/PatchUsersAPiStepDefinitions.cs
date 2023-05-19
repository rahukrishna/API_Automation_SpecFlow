using API_Automation_SpecFlow.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;


namespace API_Automation_SpecFlow.StepDefinitions
{
    [Binding]
    public class PatchUsersAPiStepDefinitions
    {
        private RestClient restclient;
        private RestRequest request;
        private RestResponse response;
        [Given(@"Want to patch user details")]
        public void GivenWantToPatchUserDetails()
        {
            request = new RestRequest(Helpers.Helpers.updateUserReq(), Method.Patch);
            restclient = new RestClient(Helpers.Helpers.getBaseURL());
        }

        [When(@"the name (.+) and (.+) is provided")]
        public void WhenTheNameRahulKAndNewJobIsProvided(string name, string newJob)
        {
            string bodyData = Helpers.BodyData.updateRequestData(name, newJob);
            request.AddBody(bodyData);
            request.RequestFormat = DataFormat.Json;
        }

        [When(@"trying to get the data")]
        public void WhenTryingToGetTheData()
        {
            response = restclient.Execute(request);
        }

        [Then(@"the patched response should contain the name (.+) and new job (.+)")]
        public void ThenThePatchedResponseShouldContainTheNameRahulKAndNewJobNewJob(string name, string newJob)
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
