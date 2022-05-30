using SendGrid;
using SendGrid.Helpers.Mail;

namespace IAT2022.Email
{
    
        internal class EmailSender
        {
        private string email;
        private string token;
        private readonly string selctedSubject;
        private readonly IConfiguration _configuration;

        public EmailSender(string email, string token, string selctedSubject, IConfiguration configuration)
        {
            this.email = email;
            this.token = token;
            this.selctedSubject = selctedSubject;
            _configuration = configuration;
            Main(email, token, selctedSubject);

            
        }

        public void Main(string email, string token, string selctedSubject)
            {
                Execute(email, token, selctedSubject).Wait();
            }

           public async Task Execute(string email, string token, string selctedSubject)
            {
                var apiKey = _configuration["MailApiKey"];
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("innovationatool@gmail.com");
                var subject = selctedSubject;
                var to = new EmailAddress(email);
                var plainTextContent = token;
                
                var htmlContent = $"<strong>{token} <br /> Svara inte på detta mail. Ingen övervakar detta konto och alla svar raderas för att inte spara personlig information (GDPR)</strong>";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);
            }
        }
    
}
