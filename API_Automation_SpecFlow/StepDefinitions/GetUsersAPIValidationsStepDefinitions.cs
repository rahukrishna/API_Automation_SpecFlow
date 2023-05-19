using RestSharp;
using NUnit.Framework;
using API_Automation_SpecFlow.Models;
using Newtonsoft.Json;


namespace API_Automation_SpecFlow.StepDefinitions
{
    [Binding]
    public class GetUsersAPIValidationsStepDefinitions
    {

        private RestClient restclient;
        private RestRequest request;
        private RestResponse response;


        [Given(@"Want to know the users list")]
        public void GivenWantToKnowTheUsersList()
        {
           
            request = new RestRequest(Helpers.Helpers.getListUserUrl(), Method.Get);
            restclient = new RestClient(Helpers.Helpers.getBaseURL());
        }

        [When(@"I retrive the data of users list")]
        public void WhenIRetriveTheDataOfUsersList()
        {

            response = restclient.Execute(request);
        }

        [Then(@"Users list should contain some value")]
        public void ThenUsersListShouldContainSomeValue()
        {
            //LocationResponse locationResponse = new JsonDeserializer().Deserialize<LocationResponse>(restResponse);
            var listResponse =  JsonConvert.DeserializeObject<ListUserResponse>(response.Content.ToString());
            Assert.AreEqual(response.StatusCode.ToString(), "OK");
            Assert.IsNotNull(listResponse);
            Assert.IsNotNull(listResponse.per_page);
            Assert.IsNotNull(listResponse.page);
            Assert.IsNotNull(listResponse.data);
            
        }
        [Given(@"Iwant to get single user details")]
        public void GivenIwantToGetSingleUserDetails()
        {
            request = new RestRequest(Helpers.Helpers.getSingleUserUrl(), Method.Get);
            restclient = new RestClient(Helpers.Helpers.getBaseURL());
        }

        [When(@"I retrivee data for a single user")]
        public void WhenIRetriveeDataForASingleUser()
        {
            response = restclient.Execute(request);
        }

        [Then(@"I should get the details of singke user")]
        public void ThenIShouldGetTheDetailsOfSingkeUser()
        {
            Assert.AreEqual(response.StatusCode.ToString(), "OK");
            var singleUserResponse = JsonConvert.DeserializeObject<SingleUserResponse>(response.Content.ToString());
            Assert.IsNotNull(singleUserResponse);
            Assert.IsNotNull(singleUserResponse.data);
            Assert.IsNotNull(singleUserResponse.support);
            



        }


    }
}
