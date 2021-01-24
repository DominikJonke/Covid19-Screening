namespace CoronaTest.Core.Contracts
{
    public interface ISmsService
    {
        /// <summary>
        /// Sendet eine Sms.
        /// </summary>
        /// <param name="to">Handynummer des Empfängers.</param>
        /// <param name="message">Inhalt der Nachricht.</param>
        /// <returns>Ob erfolgreich versendet wurde.</returns>
        bool SendSms(string to, string message);
    }
}
