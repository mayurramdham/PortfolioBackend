using App.Core.Interface;

namespace Infrastructure.Service
{
    public class EmailTemplateService : IEmailTemplateService
    {
        public string GenerateTemplateEmail(string name, string email, string subject, string message, DateTime submittedAt)
        {
            return $@"<!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>New Contact Form Submission</title>
</head>
<body style='font-family: Arial, sans-serif; background-color: #f4f4f4; color: #333; margin: 0; padding: 20px;'>
    <div style='background-color: #ffffff; padding: 20px; border-radius: 5px; box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);'>
        <h1 style='color: #2c3e50; font-size: 24px; margin-bottom: 10px;'>New Contact Form Submission</h1>
        <p><strong>Hi,</strong></p>
        <p>You have received a new message from your portfolio contact form. Below are the details:</p>

        <div style='margin-top: 20px; padding: 10px; background-color: #f8f8f8; border-radius: 5px; border: 1px solid #e0e0e0;'>
            <p style='margin: 5px 0;'><strong>Name:</strong> {name}</p>
            <p style='margin: 5px 0;'><strong>Email:</strong> {email}</p>
            <p style='margin: 5px 0;'><strong>Subject:</strong> {subject}</p>
            <p style='margin: 5px 0;'><strong>Message:</strong></p>
            <p style='margin: 5px 0;'>{message}</p>
            <p style='margin: 5px 0;'><strong>Contact On:</strong> {submittedAt}</p>
        </div>

        <div style='margin-top: 30px; text-align: center; font-size: 14px; color: #777;'>
            <p>Thank you for using our contact form!</p>
            <p>Portfolio - Powered by Mayur Ramdham</p>
        </div>
    </div>
</body>
</html>";
        }

    }
}
