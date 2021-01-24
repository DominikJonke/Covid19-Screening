using CoronaTest.Core.Contracts;
using CoronaTest.Core.Services;
using Microsoft.Extensions.Configuration;
using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace CoronaTest.PoC
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<TwilioSmsService>()
                .AddEnvironmentVariables()
                .Build();

            ISmsService smsService = new TwilioSmsService(
                configuration["Twilio:AccountSid"], configuration["Twilio:AuthToken"]);

            string to = "+4367761274365";
            string message = "Hello World from Twilio SMS service.";

            smsService.SendSms(to, message);
        }
    }
}
