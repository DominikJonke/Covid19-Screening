using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace CoronaTest.PoC
{
    class Program
    {
        static void Main(string[] args)
        {
            // Find your Account Sid and Token at twilio.com/console
            // and set the environment variables. See http://twil.io/secure
            string accountSid = "ACc429331dd873ac94209edd73fcba35f0";
            string authToken = "7f3727666525169ace3a8c9013dd202d";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "Hello World from Twilio SMS service!",
                from: new Twilio.Types.PhoneNumber("+14088374921"),
                to: new Twilio.Types.PhoneNumber("+4367761274365")
            );

            Console.WriteLine(message.Sid);
        }
    }
}
