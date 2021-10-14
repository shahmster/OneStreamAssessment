using Leads.Api.Dtos;
using Leads.Api.Dtos.Validators;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Api.Test
{
    public class LeadValidationTests
    {
        [Theory]
        [MemberData(nameof(ValidationTestData))]
        public async Task Test_DialDetailsValidators(DialDetails dto,
            int expectedErrorCount,
            string[] expectedMessage,
            bool expectedIsValid)
        {
            var validator = new DialDetailsValidators();

            var actualValidationResult = await validator.ValidateAsync(dto);


            var actualErrorCount = actualValidationResult.Errors.Count;

            var actualMessage = actualValidationResult.Errors
             ?.Select(val => val.ErrorMessage)
             ?.OrderBy(msg => msg)
             ?.ToArray();



            Assert.Equal(expectedIsValid, actualValidationResult.IsValid);
            Assert.Equal(expectedErrorCount, actualValidationResult.Errors.Count);
            Assert.Equal(expectedMessage, actualMessage);




        }

        #region Validation Test Setup
        public static IEnumerable<object[]> ValidationTestData =>
           new List<object[]>
           {

                //invalid input 
                new object[] {
                    new DialDetails
                    {
                        AgentSessionId = 0,
                        PhoneNumber = ""
                    },
                    4,
                    new string[]
                    {
                        "Please provide a session id",
                        "Invalid AgentSessionId",
                        "Please provide a phonenumber",
                        "Incorrect Length"
                    }.OrderBy(msg=>msg),
                    false
                },
                new object[] {
                    new DialDetails
                    {
                        AgentSessionId = -1,
                        PhoneNumber = "073256"
                    },
                    2,
                    new string[]
                    {
                       
                        "Invalid AgentSessionId",
                        "Incorrect Length"

                    }.OrderBy(msg=>msg)
                    ,false
                },
                
                //valid input
                new object[] {new DialDetails
                    {
                       AgentSessionId = 1,
                       PhoneNumber = "0732567360"
                    },0, new string[] { },true},

           };
        #endregion

    }
}

