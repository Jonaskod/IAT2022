﻿using SendGrid;
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
                var from = new EmailAddress("keeew1992@gmail.com");
                var subject = selctedSubject;
                var to = new EmailAddress(email);
                var plainTextContent = token;
                
                var htmlContent = $"<strong>{token}</strong>";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);
            }
        }
    
}
