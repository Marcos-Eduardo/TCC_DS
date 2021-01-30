using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Math.Models;
using Math.Data;
using Math.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Math.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MathContext _context;

        public HomeController(ILogger<HomeController> logger, MathContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var c = new ConteudoViewModel();
            c.Dicas = _context.Dicas.Take(6);
            return View(c);
        }

        public IActionResult Contato()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Contato(Contato contato)
        {
            if (ModelState.IsValid)
            {
                var email = new EmailSender();
                string logo = "https://i.postimg.cc/4dgFYMZL/logo.png";
                string img = "https://i.postimg.cc/HnTKhNhc/Contact.png";
                string mensagem = string.Format("<body class='clean-body' style='margin: 0; padding: 0; -webkit-text-size-adjust: 100%; background-color: #f8f8f9;'><table bgcolor='#f8f8f9' cellpadding='0' cellspacing='0' class='nl-container' role='presentation' style='table-layout: fixed; vertical-align: top; min-width: 320px; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #f8f8f9; width: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td style='word-break: break-word; vertical-align: top;' valign='top'><div style='background-color:#f39f0b;'><div class='block-grid' style='min-width: 320px; max-width: 640px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; Margin: 0 auto; background-color: #f39f0b;'><div style='border-collapse: collapse;display: table;width: 100%;background-color:#f39f0b;'><div class='col num12' style='min-width: 320px; max-width: 640px; display: table-cell; vertical-align: top; width: 640px;'><div class='col_cont' style='width:100% !important;'><div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:0px; padding-bottom:0px; padding-right: 0px; padding-left: 0px;'><table border='0' cellpadding='0' cellspacing='0' class='divider' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td class='divider_inner' style='word-break: break-word; vertical-align: top; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px;' valign='top'><table align='center' border='0' cellpadding='0' cellspacing='0' class='divider_content' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-top: 4px solid #F39F0B; width: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td style='word-break: break-word; vertical-align: top; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top'><span></span></td></tr></tbody></table></td></tr></tbody></table></div></div></div></div></div></div><div style='background-color:#fff;'><div class='block-grid' style='min-width: 320px; max-width: 640px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; Margin: 0 auto; background-color: #fff;'><div style='border-collapse: collapse;display: table;width: 100%;background-color:#fff;'><div class='col num12' style='min-width: 320px; max-width: 640px; display: table-cell; vertical-align: top; width: 640px;'><div class='col_cont' style='width:100% !important;'><div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:0px; padding-bottom:0px; padding-right: 0px; padding-left: 0px;'><div align='center' class='img-container center autowidth' style='padding-right: 0px;padding-left: 0px;'><div style='font-size:1px;line-height:22px'> </div><img align='center' alt='I'm an image' border='0' class='center autowidth' src='{4}' style='text-decoration: none; -ms-interpolation-mode: bicubic; height: auto; border: 0; width: 100%; max-width: 149px; display: block;' title='I'm an image' width='149'/><div style='font-size:1px;line-height:25px'> </div></div></div></div></div></div></div></div><div style='background-color:transparent;'><div class='block-grid' style='min-width: 320px; max-width: 640px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; Margin: 0 auto; background-color: #f8f8f9;'><div style='border-collapse: collapse;display: table;width: 100%;background-color:#f8f8f9;'><div class='col num12' style='min-width: 320px; max-width: 640px; display: table-cell; vertical-align: top; width: 640px;'><div class='col_cont' style='width:100% !important;'><div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:5px; padding-bottom:5px; padding-right: 0px; padding-left: 0px;'><table border='0' cellpadding='0' cellspacing='0' class='divider' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td class='divider_inner' style='word-break: break-word; vertical-align: top; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; padding-top: 20px; padding-right: 20px; padding-bottom: 20px; padding-left: 20px;' valign='top'><table align='center' border='0' cellpadding='0' cellspacing='0' class='divider_content' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-top: 0px solid #BBBBBB; width: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td style='word-break: break-word; vertical-align: top; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top'><span></span></td></tr></tbody></table></td></tr></tbody></table></div></div></div></div></div></div><div style='background-color:transparent;'><div class='block-grid' style='min-width: 320px; max-width: 640px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; Margin: 0 auto; background-color: #fff;'><div style='border-collapse: collapse;display: table;width: 100%;background-color:#fff;'><div class='col num12' style='min-width: 320px; max-width: 640px; display: table-cell; vertical-align: top; width: 640px;'><div class='col_cont' style='width:100% !important;'><div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:0px; padding-bottom:0px; padding-right: 0px; padding-left: 0px;'><table border='0' cellpadding='0' cellspacing='0' class='divider' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td class='divider_inner' style='word-break: break-word; vertical-align: top; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; padding-top: 60px; padding-right: 0px; padding-bottom: 12px; padding-left: 0px;' valign='top'><table align='center' border='0' cellpadding='0' cellspacing='0' class='divider_content' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-top: 0px solid #BBBBBB; width: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td style='word-break: break-word; vertical-align: top; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top'><span></span></td></tr></tbody></table></td></tr></tbody></table><div align='center' class='img-container center fixedwidth' style='padding-right: 40px;padding-left: 40px;'><img align='center' alt='I'm an image' border='0' class='center fixedwidth' src='{5}' style='text-decoration: none; -ms-interpolation-mode: bicubic; height: auto; border: 0; width: 100%; max-width: 352px; display: block;' title='I'm an image' width='352'/></div><table border='0' cellpadding='0' cellspacing='0' class='divider' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td class='divider_inner' style='word-break: break-word; vertical-align: top; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; padding-top: 50px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px;' valign='top'><table align='center' border='0' cellpadding='0' cellspacing='0' class='divider_content' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-top: 0px solid #BBBBBB; width: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td style='word-break: break-word; vertical-align: top; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top'><span></span></td></tr></tbody></table></td></tr></tbody></table><div style='color:#555555;font-family:Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif;line-height:1.2;padding-top:10px;padding-right:40px;padding-bottom:10px;padding-left:40px;'><div style='line-height: 1.2; font-size: 12px; color: #555555; font-family: Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif; mso-line-height-alt: 14px;'><p style='font-size: 30px; line-height: 1.2; text-align: center; word-break: break-word; mso-line-height-alt: 36px; margin: 0;'><span style='font-size: 30px; color: #2b303a;'><strong>Novo contato feito no website</strong></span></p></div></div><table border='0' cellpadding='0' cellspacing='0' class='divider' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td class='divider_inner' style='word-break: break-word; vertical-align: top; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; padding-top: 60px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px;' valign='top'><table align='center' border='0' cellpadding='0' cellspacing='0' class='divider_content' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-top: 0px solid #BBBBBB; width: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td style='word-break: break-word; vertical-align: top; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top'><span></span></td></tr></tbody></table></td></tr></tbody></table></div></div></div></div></div></div><div style='background-color:transparent;'><div class='block-grid' style='min-width: 320px; max-width: 640px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; Margin: 0 auto; background-color: #fefdf0;'><div style='border-collapse: collapse;display: table;width: 100%;background-color:#fefdf0;'><div class='col num12' style='min-width: 320px; max-width: 640px; display: table-cell; vertical-align: top; width: 580px;'><div class='col_cont' style='width:100% !important;'><div style='border-top:0px solid transparent; border-left:30px solid #FFFFFF; border-bottom:0px solid transparent; border-right:30px solid #FFFFFF; padding-top:0px; padding-bottom:0px; padding-right: 0px; padding-left: 0px;'><table border='0' cellpadding='0' cellspacing='0' class='divider' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td class='divider_inner' style='word-break: break-word; vertical-align: top; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px;' valign='top'><table align='center' border='0' cellpadding='0' cellspacing='0' class='divider_content' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-top: 4px solid #F39F0B; width: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td style='word-break: break-word; vertical-align: top; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top'><span></span></td></tr></tbody></table></td></tr></tbody></table><table border='0' cellpadding='0' cellspacing='0' class='divider' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td class='divider_inner' style='word-break: break-word; vertical-align: top; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; padding-top: 35px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px;' valign='top'><table align='center' border='0' cellpadding='0' cellspacing='0' class='divider_content' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-top: 0px solid #BBBBBB; width: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td style='word-break: break-word; vertical-align: top; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top'><span></span></td></tr></tbody></table></td></tr></tbody></table><div style='color:#555555;font-family:Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif;line-height:1.2;padding-top:15px;padding-right:10px;padding-bottom:10px;padding-left:10px;'><div style='line-height: 1.2; font-size: 12px; color: #555555; font-family: Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif; mso-line-height-alt: 14px;'><p style='font-size: 18px; line-height: 1.2; text-align: center; word-break: break-word; mso-line-height-alt: 22px; margin: 0;'><span style='color: #2b303a; font-size: 18px;'><strong>{0}</strong></span></p></div></div><div style='color:#555555;font-family:Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif;line-height:1.5;padding-top:20px;padding-right:30px;padding-bottom:40px;padding-left:30px;'><div style='line-height: 1.5; font-size: 12px; font-family: Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif; color: #555555; mso-line-height-alt: 18px;'><p style='font-size: 14px; line-height: 1.5; word-break: break-word; text-align: left; font-family: Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif; mso-line-height-alt: 21px; margin: 0;'>{1}</p><p style='font-size: 14px; line-height: 1.5; word-break: break-word; text-align: left; font-family: Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif; mso-line-height-alt: 21px; margin: 0;'> </p><p style='font-size: 15px; line-height: 1.5; word-break: break-word; text-align: left; font-family: Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif; mso-line-height-alt: 23px; margin: 0;'><span style='color: #2b303a; font-size: 15px;'>E-mail: {2}</span></p><p style='font-size: 15px; line-height: 1.5; word-break: break-word; text-align: left; font-family: Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif; mso-line-height-alt: 23px; margin: 0;'><span style='color: #2b303a; font-size: 15px;'>Telefone: {3}</span></p></div></div></div></div></div></div></div></div><div style='background-color:transparent;'><div class='block-grid' style='min-width: 320px; max-width: 640px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; Margin: 0 auto; background-color: #fff;'><div style='border-collapse: collapse;display: table;width: 100%;background-color:#fff;'><div class='col num12' style='min-width: 320px; max-width: 640px; display: table-cell; vertical-align: top; width: 640px;'><div class='col_cont' style='width:100% !important;'><div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:0px; padding-bottom:0px; padding-right: 0px; padding-left: 0px;'><table border='0' cellpadding='0' cellspacing='0' class='divider' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td class='divider_inner' style='word-break: break-word; vertical-align: top; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; padding-top: 60px; padding-right: 0px; padding-bottom: 12px; padding-left: 0px;' valign='top'><table align='center' border='0' cellpadding='0' cellspacing='0' class='divider_content' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-top: 0px solid #BBBBBB; width: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td style='word-break: break-word; vertical-align: top; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top'><span></span></td></tr></tbody></table></td></tr></tbody></table></div></div></div></div></div></div><div style='background-color:transparent;'><div class='block-grid' style='min-width: 320px; max-width: 640px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; Margin: 0 auto; background-color: #f8f8f9;'><div style='border-collapse: collapse;display: table;width: 100%;background-color:#f8f8f9;'><div class='col num12' style='min-width: 320px; max-width: 640px; display: table-cell; vertical-align: top; width: 640px;'><div class='col_cont' style='width:100% !important;'><div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:5px; padding-bottom:5px; padding-right: 0px; padding-left: 0px;'><table border='0' cellpadding='0' cellspacing='0' class='divider' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td class='divider_inner' style='word-break: break-word; vertical-align: top; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; padding-top: 20px; padding-right: 20px; padding-bottom: 20px; padding-left: 20px;' valign='top'><table align='center' border='0' cellpadding='0' cellspacing='0' class='divider_content' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-top: 0px solid #BBBBBB; width: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td style='word-break: break-word; vertical-align: top; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top'><span></span></td></tr></tbody></table></td></tr></tbody></table></div></div></div></div></div></div></td></tr></tbody></table></body>", contato.Nome, contato.Mensagem, contato.Email, contato.Telefone, logo, img);
                await email.Mail("math4few@gmail.com", contato.Email, "Contato Feito no Matemática é para poucos", mensagem);
                return Json(new { success = true, message = "Enviado" });
            }
            return Json(new { success = false, message = "Dados Incompletos" });
        }

        public IActionResult Conteudos(int? id)
        {
            var n = new NivelViewModel();
            n.Nivel = _context.Niveis.Find(id);
            n.Conteudos = _context.Conteudos.Where(c => c.NivelId == id).ToList();
            for (int i = 0; i < n.Conteudos.Count(); i++)
            {
                n.Conteudos.ToArray()[i].NumeroOrdem = i + 1;
            }
            return View(n);
        }

        public IActionResult Dicas(int? id)
        {
            var c = new ConteudoViewModel();
            c.Conteudo = _context.Conteudos.Find(id);
            c.Dicas = _context.Dicas.Where(c => c.ConteudoId == id).ToList();
            return View(c);
        }

        public IActionResult Dica(int? id)
        {
            var d = new DicaViewModel();
            d.Dica = _context.Dicas.Find(id);
            return View(d);
        }

        public IActionResult Pratique(int? id)
        {
            var n = new NivelViewModel();
            n.Nivel = _context.Niveis.Find(id);
            n.Conteudos = _context.Conteudos.Where(c => c.NivelId == id).ToList();
            for (int i = 0; i < n.Conteudos.Count(); i++)
            {
                n.Conteudos.ToArray()[i].NumeroOrdem = i + 1;
            }
            return View(n);
        }

        [Authorize]
        public IActionResult Exercicios(int? id)
        {
            //var q = new Quiz();
            //q.Conteudo = _context.Conteudos.Find(id);
            //q.Questoes = _context.Questoes.Where(q => q.QuizId == id).ToList();
            var q = _context.Quizes.Include(c => c.Conteudo).Where(c => c.ConteudoId == id).ToList();
            ViewBag.Conteudo = _context.Conteudos.Find(id);
            return View(q);
        }

        [Authorize]
        public IActionResult Exercicio(int? id)
        {
            var questoes = _context.Questoes.Where(x => x.QuizId == id).ToList();
            List<QuestaoViewModel> listaQuestoes = new List<QuestaoViewModel>();
            var i = 1;
            foreach (var item in questoes)
            {
                QuestaoViewModel qvm = new QuestaoViewModel()
                {
                    numb = i,
                    question = item.Titulo,
                    answer = item.Resposta,
                    options = { item.Alternativa1, item.Alternativa2, item.Alternativa3, item.Alternativa4 }
                };
                i += 1;
                listaQuestoes.Add(qvm);
            }
            ViewData["QuizNome"] = _context.Quizes.Where(q => q.Id == id).Select(t => t.Titulo).SingleOrDefault();
            return View(listaQuestoes);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
