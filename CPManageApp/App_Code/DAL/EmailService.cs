using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;

namespace CPManageApp.App_Code.DAL
{
    public class EmailService
    {
        private string orgName = "Carpark Management Service Provider";
        private string from = "shapy.cpm@gmail.com";
        private string pw = "shapy2006";
        private int SMTP_PORT = 587;
        private string SMTP_HOST = "smtp.googlemail.com";
        private string DIV_STYLE_OPEN = "<div style='font-family:Arial'>";
        private string DIV_STYLE_CLOSE = "</div>";
        private string GEN_MAIL = "This is a system generated email. Please do not reply to this email.";

        public void sendActivationAccEmail(string username, string email, string activationCode)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(email);
                mail.From = new MailAddress(from, orgName);
                mail.Subject = "Activate your Account - Carpark Management System";
                string msg = DIV_STYLE_OPEN;
                msg += "Dear " + username + ",<br/><br/>";
                msg += "Your Activation Code is: " + activationCode;
                msg += "<br/>Kindly enter the activation code to activate your account. <br/><br/>";
                msg += "<br/><br/>Thank you.<br/><br/>";
                msg += GEN_MAIL;
                msg += DIV_STYLE_CLOSE;
                mail.Body = msg;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = SMTP_HOST;
                smtp.Port = SMTP_PORT;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                //Or Your SMTP Server Address
                smtp.Credentials = new System.Net.NetworkCredential(from, pw);
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            catch (Exception ex)
            {

            }
        }
        public void sendResetPasswordEmail(string username, string resetPassword, string email)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(email);
                mail.From = new MailAddress(from, orgName);
                mail.Subject = "Reset Password - Carpark Management System";
                string msg = DIV_STYLE_OPEN;
                msg += "Dear " + username + ",<br/><br/>";
                msg += "As requested, your password has been reset. <br/>";
                msg += "Kindly use the following password to login. <br/>";
                msg += "<br/>";
                msg += "<b>" + resetPassword + "</b><br/>";
                msg += "<br/>";
                msg += "Do remember to change your password after you have login. <br/>";
                msg += "<br/><br/>Thank you.<br/><br/>";
                msg += GEN_MAIL;
                msg += DIV_STYLE_CLOSE;
                mail.Body = msg;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = SMTP_HOST;
                smtp.Port = SMTP_PORT;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                //Or Your SMTP Server Address
                smtp.Credentials = new System.Net.NetworkCredential(from, pw);
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            catch (Exception ex)
            {

            }
        }
        public void sendReactivationAccEmail(string username, string email, string activationCode)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(email);
                mail.From = new MailAddress(from, orgName);
                mail.Subject = "New Activation Code - Carpark Management System";
                string msg = DIV_STYLE_OPEN;
                msg += "Dear " + username + ",<br/><br/>";
                msg += "As requested, your new Activation Code is: " + activationCode + "<br/>";
                msg += "<br/>Kindly enter the activation code to activate your account. <br/><br/>";
                msg += "<br/><br/>Thank you.<br/><br/>";
                msg += GEN_MAIL;
                msg += DIV_STYLE_CLOSE;
                mail.Body = msg;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = SMTP_HOST;
                smtp.Port = SMTP_PORT;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                //Or Your SMTP Server Address
                smtp.Credentials = new System.Net.NetworkCredential(from, pw);
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            catch (Exception ex)
            {

            }
        }
        public void sendParkingRecord(string username, string email, string month, string attachment)
        {
            try
            {
                // to change accordingly to match the pdf output
                string path = "C:\\Users\\CPManageApp\\Documents\\"; 
                MailMessage mail = new MailMessage();
                mail.To.Add(email);
                mail.From = new MailAddress(from, orgName);
                mail.Subject = "Parking Record for "+ month;
                string msg = DIV_STYLE_OPEN;
                msg += "Dear " + username + ",<br/><br/>";
                msg += "Enclosed is your parking record for the month. <br/>";
                msg += "<br/><br/>Thank you.<br/><br/>";
                msg += GEN_MAIL;
                msg += DIV_STYLE_CLOSE;
                mail.Body = msg;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = SMTP_HOST;
                smtp.Port = SMTP_PORT;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                //Or Your SMTP Server Address
                smtp.Credentials = new System.Net.NetworkCredential(from, pw);
                smtp.EnableSsl = true;

                // add attachment
                Attachment attachFile = new Attachment(path + attachment, MediaTypeNames.Application.Pdf);
                attachFile.ContentDisposition.FileName = attachment;
                mail.Attachments.Add(attachFile);
                smtp.Send(mail);
            }
            catch (Exception ex)
            {

            }
        }
    }
}