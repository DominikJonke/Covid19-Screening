using CoronaTest.Core.Contracts;
using System;
using System.Diagnostics;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace CoronaTest.Core.Services
{
    public class TwilioSmsService : ISmsService
    {
        private readonly string _accountSid;
        private readonly string _authToken;

        public TwilioSmsService(string accountSid, string authToken)
        {
            _accountSid = accountSid;
            _authToken = authToken;
        }
        public bool SendSms(string to, string message)
        {
            try
            {
                TwilioClient.Init(_accountSid, _authToken);

                var sms = MessageResource.Create(
                    body: message,
                    from: new Twilio.Types.PhoneNumber("+14088374921"),
                    to: new Twilio.Types.PhoneNumber(to)
                );
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                
                return false;
            }

            return true;
        }
    }
}
