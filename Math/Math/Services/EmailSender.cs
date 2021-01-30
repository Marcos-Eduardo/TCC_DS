﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Math.Services
{
    public class EmailSender
    {
        public async Task<bool> Mail(string Para, string De, string Assunto, string Mensagem)
        {
            var m = new MailMessage()
            {
                Subject = Assunto,
                Body = Mensagem,
                IsBodyHtml = true
            };
            MailAddress para = new MailAddress(Para);
            m.To.Add(para);
            m.From = new MailAddress(De);
            m.Sender = para;
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                Credentials = new NetworkCredential("math4few@gmail.com", ""),
                EnableSsl = true
            };
            try
            {
                await smtp.SendMailAsync(m);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
