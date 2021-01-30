using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Math.Models;
using Math.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace Math.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class AccountController : Controller
    {
        private readonly UserManager<Usuario> userManager;
        private readonly SignInManager<Usuario> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<Usuario> user, SignInManager<Usuario> sign, RoleManager<IdentityRole> role)
        {
            userManager = user;
            signInManager = sign;
            roleManager = role;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string filtro, string pesquisa, int? pagina)
        {
            if (pesquisa != null)
            {
                pagina = 1;
            }
            else
            {
                pesquisa = filtro;
            }

            ViewData["Filtro"] = pesquisa;

            var users = await userManager.Users.ToListAsync();
            foreach (var user in users)
            {
                //Cria uma lista dos Perfis(Roles) de cada usuário(User)
                var perfis = await userManager.GetRolesAsync(user);
                //Join, para unir todos os items da lista em um único string
                user.Roles = string.Join(", ", perfis);
            }

            if (!String.IsNullOrEmpty(pesquisa))
            {
                users = users.Where(c => c.Email.Contains(pesquisa)).ToList();
            }

            int itensPorPagina = 12;

            return View(await users.ToPagedListAsync(pagina ?? 1, itensPorPagina));
            //return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = userManager.Users.Where(u => u.Id == id).SingleOrDefault();

            if (user == null)
            {
                return NotFound();
            }

            // Pesquisar o perfil do usuário
            var perfil = await userManager.GetRolesAsync(user);

            // Cria uma lista de perfis
            ViewData["Perfis"] = new SelectList(roleManager.Roles, "NormalizedName", "Name");

            // Criamos um objeto UsuarioViewModel
            UsuarioViewModel model = new UsuarioViewModel()
            {
                Id = user.Id,
                Nome = user.Nome,
                Apelido = user.Apelido,
                DataNascimento = user.DataNascimento,
                Email = user.Email,
                Perfil = perfil[0]
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, UsuarioViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var user = userManager.Users.Where(u => u.Id == id).SingleOrDefault();
                    user.Nome = model.Nome;
                    user.Apelido = model.Apelido ?? model.Nome.Split(' ', StringSplitOptions.None)[0];
                    user.DataNascimento = model.DataNascimento;
                    await userManager.UpdateAsync(user); // Salva os dados do usuário

                    var perfil = await userManager.GetRolesAsync(user);
                    if (perfil[0] != model.Perfil)
                    {
                        await userManager.RemoveFromRoleAsync(user, perfil[0]);
                        await userManager.AddToRoleAsync(user, model.Perfil);
                    }
                }
                catch
                {
                    throw;
                }
                return RedirectToAction("Index");
            }
            // Cria uma lista de perfis
            ViewData["Perfis"] = new SelectList(roleManager.Roles, "NormalizedName", "Name");
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            // Cria uma lista de perfis
            ViewData["Perfis"] = new SelectList(roleManager.Roles, "NormalizedName", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUsuarioViewModel account)
        {
            if (!ModelState.IsValid)
            {
                return View(account);
            }

            var user = new Usuario()
            {
                UserName = account.Email,
                Nome = account.Nome,
                Apelido = account.Apelido ?? account.Nome.Split(' ', StringSplitOptions.None)[0],
                DataNascimento = account.DataNascimento,
                Email = account.Email,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(user, account.Senha);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    // Lista de erros do UserManager
                    // https://stackoverflow.com/questions/40583707/list-of-error-cases-in-use-usermanager-createasyncuser-password

                    if (error.Code == "DuplicateEmail")
                    {
                        ModelState.AddModelError("", "O E-mail informado já encontra-se cadastrado em nosso sistema!");
                    }
                }
                return View(account);
            }
            await userManager.AddToRoleAsync(user, account.Perfil);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = userManager.Users.Where(u => u.Id == id).SingleOrDefault();

            if (user == null)
            {
                return NotFound();
            }

            // Pesquisar o perfil do usuário
            var perfil = await userManager.GetRolesAsync(user);

            // Criamos um objeto UsuarioViewModel
            UsuarioViewModel model = new UsuarioViewModel()
            {
                Id = user.Id,
                Nome = user.Nome,
                Apelido = user.Apelido,
                DataNascimento = user.DataNascimento,
                Email = user.Email,
                Perfil = perfil[0]
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = userManager.Users.Where(u => u.Id == id).SingleOrDefault();

            if (user == null)
            {
                return NotFound();
            }

            // Pesquisar o perfil do usuário
            var perfil = await userManager.GetRolesAsync(user);

            // Criamos um objeto UsuarioViewModel
            UsuarioViewModel model = new UsuarioViewModel()
            {
                Id = user.Id,
                Nome = user.Nome,
                Apelido = user.Apelido,
                DataNascimento = user.DataNascimento,
                Email = user.Email,
                Perfil = perfil[0]
            };

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = userManager.Users.Where(u => u.Id == id).SingleOrDefault();
            try
            {
                await userManager.DeleteAsync(user);
            }
            catch
            {

                throw;
            }
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult LoginRegister()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Login(AccountLogin account)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false });
            }

            var user = await userManager.FindByEmailAsync(account.EmailLogin);

            if (!user.EmailConfirmed)
            {
                return Json(data: "0");
            }

            var result = await signInManager.PasswordSignInAsync(account.EmailLogin, account.SenhaLogin, account.ManterConectado, lockoutOnFailure: true);
            if (result.Succeeded)
            {
                var roles = await userManager.GetRolesAsync(user);

                if (roles.Contains("Administrador"))
                {
                    return Json(data: "1");
                }
                return Json(new { data = "2", usuario = user.Apelido });
            }
            
            if (result.IsLockedOut)
            {
                return Json(data: "3");
            }
            else
            {
                return Json(data: "4");
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Register(AccountRegister account)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false });
            }

            var user = new Usuario()
            {
                UserName = account.EmailRegister,
                Nome = account.Nome,
                Apelido = account.Apelido ?? account.Nome.Split(' ', StringSplitOptions.None)[0],
                DataNascimento = account.DataNascimento,
                Email = account.EmailRegister,
                EmailConfirmed = false
            };

            var result = await userManager.CreateAsync(user, account.SenhaRegister);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    // Lista de erros do UserManager
                    // https://stackoverflow.com/questions/40583707/list-of-error-cases-in-use-usermanager-createasyncuser-password

                    if (error.Code == "DuplicateEmail")
                    {
                        return Json(data: "5");
                    }
                }
                return Json(data: "6");
            }

            await userManager.AddToRoleAsync(user, "Visitante");

            //await signInManager.PasswordSignInAsync(account.EmailRegister, account.SenhaRegister, false, lockoutOnFailure: true);

            var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
            var link = Url.Action("ConfirmEmail", "Account", new { token, email = user.Email }, Request.Scheme);
            string logo = "https://i.postimg.cc/4dgFYMZL/logo.png";
            string img = "https://i.postimg.cc/x8kjcc93/Confirm.png";
            var mensagem = string.Format("<body class='clean-body' style='margin: 0; padding: 0; -webkit-text-size-adjust: 100%; background-color: #f8f8f9;'><table bgcolor='#f8f8f9' cellpadding='0' cellspacing='0' class='nl-container' role='presentation' style='table-layout: fixed; vertical-align: top; min-width: 320px; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #f8f8f9; width: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td style='word-break: break-word; vertical-align: top;' valign='top'><div style='background-color:#f39f0b;'><div class='block-grid' style='min-width: 320px; max-width: 640px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; Margin: 0 auto; background-color: #f39f0b;'><div style='border-collapse: collapse;display: table;width: 100%;background-color:#f39f0b;'><div class='col num12' style='min-width: 320px; max-width: 640px; display: table-cell; vertical-align: top; width: 640px;'><div class='col_cont' style='width:100% !important;'><div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:0px; padding-bottom:0px; padding-right: 0px; padding-left: 0px;'><table border='0' cellpadding='0' cellspacing='0' class='divider' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td class='divider_inner' style='word-break: break-word; vertical-align: top; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px;' valign='top'><table align='center' border='0' cellpadding='0' cellspacing='0' class='divider_content' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-top: 4px solid #F39F0B; width: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td style='word-break: break-word; vertical-align: top; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top'><span></span></td></tr></tbody></table></td></tr></tbody></table></div></div></div></div></div></div><div style='background-color:#fff;'><div class='block-grid' style='min-width: 320px; max-width: 640px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; Margin: 0 auto; background-color: #fff;'><div style='border-collapse: collapse;display: table;width: 100%;background-color:#fff;'><div class='col num12' style='min-width: 320px; max-width: 640px; display: table-cell; vertical-align: top; width: 640px;'><div class='col_cont' style='width:100% !important;'><div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:0px; padding-bottom:0px; padding-right: 0px; padding-left: 0px;'><div align='center' class='img-container center autowidth' style='padding-right: 0px;padding-left: 0px;'><div style='font-size:1px;line-height:22px'> </div><img align='center' alt='I'm an image' border='0' class='center autowidth' src='{0}' style='text-decoration: none; -ms-interpolation-mode: bicubic; height: auto; border: 0; width: 100%; max-width: 149px; display: block;' title='I'm an image' width='149'/><div style='font-size:1px;line-height:25px'> </div></div></div></div></div></div></div></div><div style='background-color:transparent;'><div class='block-grid' style='min-width: 320px; max-width: 640px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; Margin: 0 auto; background-color: #f8f8f9;'><div style='border-collapse: collapse;display: table;width: 100%;background-color:#f8f8f9;'><div class='col num12' style='min-width: 320px; max-width: 640px; display: table-cell; vertical-align: top; width: 640px;'><div class='col_cont' style='width:100% !important;'><div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:5px; padding-bottom:5px; padding-right: 0px; padding-left: 0px;'><table border='0' cellpadding='0' cellspacing='0' class='divider' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td class='divider_inner' style='word-break: break-word; vertical-align: top; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; padding-top: 20px; padding-right: 20px; padding-bottom: 20px; padding-left: 20px;' valign='top'><table align='center' border='0' cellpadding='0' cellspacing='0' class='divider_content' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-top: 0px solid #BBBBBB; width: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td style='word-break: break-word; vertical-align: top; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top'><span></span></td></tr></tbody></table></td></tr></tbody></table></div></div></div></div></div></div><div style='background-color:transparent;'><div class='block-grid' style='min-width: 320px; max-width: 640px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; Margin: 0 auto; background-color: #fff;'><div style='border-collapse: collapse;display: table;width: 100%;background-color:#fff;'><div class='col num12' style='min-width: 320px; max-width: 640px; display: table-cell; vertical-align: top; width: 640px;'><div class='col_cont' style='width:100% !important;'><div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:0px; padding-bottom:0px; padding-right: 0px; padding-left: 0px;'><table border='0' cellpadding='0' cellspacing='0' class='divider' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td class='divider_inner' style='word-break: break-word; vertical-align: top; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; padding-top: 60px; padding-right: 0px; padding-bottom: 12px; padding-left: 0px;' valign='top'><table align='center' border='0' cellpadding='0' cellspacing='0' class='divider_content' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-top: 0px solid #BBBBBB; width: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td style='word-break: break-word; vertical-align: top; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top'><span></span></td></tr></tbody></table></td></tr></tbody></table><div align='center' class='img-container center fixedwidth' style='padding-right: 40px;padding-left: 40px;'><img align='center' alt='I'm an image' border='0' class='center fixedwidth' src='{1}' style='text-decoration: none; -ms-interpolation-mode: bicubic; height: auto; border: 0; width: 100%; max-width: 352px; display: block;' title='I'm an image' width='352'/></div><table border='0' cellpadding='0' cellspacing='0' class='divider' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td class='divider_inner' style='word-break: break-word; vertical-align: top; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; padding-top: 50px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px;' valign='top'><table align='center' border='0' cellpadding='0' cellspacing='0' class='divider_content' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-top: 0px solid #BBBBBB; width: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td style='word-break: break-word; vertical-align: top; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top'><span></span></td></tr></tbody></table></td></tr></tbody></table><div style='color:#555555;font-family:Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif;line-height:1.2;padding-top:10px;padding-right:40px;padding-bottom:10px;padding-left:40px;'><div style='line-height: 1.2; font-size: 12px; color: #555555; font-family: Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif; mso-line-height-alt: 14px;'><p style='font-size: 30px; line-height: 1.2; text-align: center; word-break: break-word; mso-line-height-alt: 36px; margin: 0;'><span style='font-size: 30px; color: #2b303a;'><strong>Confirmação de E-mail</strong></span></p></div></div><div style='color:#555555;font-family:Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif;line-height:1.5;padding-top:10px;padding-right:40px;padding-bottom:10px;padding-left:40px;'><div style='line-height: 1.5; font-size: 12px; font-family: Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif; color: #555555; mso-line-height-alt: 18px;'><p style='font-size: 15px; line-height: 1.5; text-align: center; word-break: break-word; font-family: Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif; mso-line-height-alt: 23px; margin: 0;'><span style='color: #808389; font-size: 15px;'>Muito obrigado {2} por se inscrever em nosso website. Antes que você possa continuar é preciso confirmar seu E-mail!</span></p></div></div><div align='center' class='button-container' style='padding-top:15px;padding-right:10px;padding-bottom:0px;padding-left:10px;'><a href='{3}' style='text-decoration:none;display:inline-block;color:#ffffff;background-color:#f4b13c;border-radius:60px;-webkit-border-radius:60px;-moz-border-radius:60px;width:auto; width:auto;;border-top:1px solid #f4b13c;border-right:1px solid #f4b13c;border-bottom:1px solid #f4b13c;border-left:1px solid #f4b13c;padding-top:15px;padding-bottom:15px;font-family:Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif;text-align:center;mso-border-alt:none;word-break:keep-all;'><span style='padding-left:30px;padding-right:30px;font-size:16px;display:inline-block;'><span style='font-size: 16px; margin: 0; line-height: 2; word-break: break-word; mso-line-height-alt: 32px;'><strong>Confirmar meu E-mail</strong></span></span></a></div><table border='0' cellpadding='0' cellspacing='0' class='divider' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td class='divider_inner' style='word-break: break-word; vertical-align: top; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; padding-top: 60px; padding-right: 0px; padding-bottom: 12px; padding-left: 0px;' valign='top'><table align='center' border='0' cellpadding='0' cellspacing='0' class='divider_content' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-top: 0px solid #BBBBBB; width: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td style='word-break: break-word; vertical-align: top; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top'><span></span></td></tr></tbody></table></td></tr></tbody></table></div></div></div></div></div></div><div style='background-color:transparent;'><div class='block-grid' style='min-width: 320px; max-width: 640px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; Margin: 0 auto; background-color: #f8f8f9;'><div style='border-collapse: collapse;display: table;width: 100%;background-color:#f8f8f9;'><div class='col num12' style='min-width: 320px; max-width: 640px; display: table-cell; vertical-align: top; width: 640px;'><div class='col_cont' style='width:100% !important;'><div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:5px; padding-bottom:5px; padding-right: 0px; padding-left: 0px;'><table border='0' cellpadding='0' cellspacing='0' class='divider' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td class='divider_inner' style='word-break: break-word; vertical-align: top; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; padding-top: 20px; padding-right: 20px; padding-bottom: 20px; padding-left: 20px;' valign='top'><table align='center' border='0' cellpadding='0' cellspacing='0' class='divider_content' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-top: 0px solid #BBBBBB; width: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td style='word-break: break-word; vertical-align: top; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top'><span></span></td></tr></tbody></table></td></tr></tbody></table></div></div></div></div></div></div></td></tr></tbody></table></body>", logo, img, user.Apelido, link);
            var email = new EmailSender();
            await email.Mail(account.EmailRegister, "math4few@gmail.com", "Confirmação de E-mail", mensagem);

            return Json(new { data = "7", usuario = user.Apelido });
        }

        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            //Pesquisa o usuário por email
            var user = await userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return View("Error");
            }

            var result = await userManager.ConfirmEmailAsync(user, token);

            return View(result.Succeeded ? nameof(ConfirmEmail) : "Error");
        }

        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<JsonResult> ForgotPassword(ForgotPasswordModel forgotPassword)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false });
            }

            var user = await userManager.FindByEmailAsync(forgotPassword.Email);

            if (user == null)
            {
                return Json(data: "1");
            }

            var token = await userManager.GeneratePasswordResetTokenAsync(user);
            var callback = Url.Action("ResetPassword", "Account", new { token, email = user.Email }, Request.Scheme);
            var email = new EmailSender();
            string logo = "https://i.postimg.cc/4dgFYMZL/logo.png";
            string img = "https://i.postimg.cc/4y4L59Yp/Forgot.png";
            string mensagem = string.Format("<body class='clean-body' style='margin: 0; padding: 0; -webkit-text-size-adjust: 100%; background-color: #f8f8f9;'><table bgcolor='#f8f8f9' cellpadding='0' cellspacing='0' class='nl-container' role='presentation' style='table-layout: fixed; vertical-align: top; min-width: 320px; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #f8f8f9; width: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td style='word-break: break-word; vertical-align: top;' valign='top'><div style='background-color:#f39f0b;'><div class='block-grid' style='min-width: 320px; max-width: 640px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; Margin: 0 auto; background-color: #f39f0b;'><div style='border-collapse: collapse;display: table;width: 100%;background-color:#f39f0b;'><div class='col num12' style='min-width: 320px; max-width: 640px; display: table-cell; vertical-align: top; width: 640px;'><div class='col_cont' style='width:100% !important;'><div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:0px; padding-bottom:0px; padding-right: 0px; padding-left: 0px;'><table border='0' cellpadding='0' cellspacing='0' class='divider' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td class='divider_inner' style='word-break: break-word; vertical-align: top; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px;' valign='top'><table align='center' border='0' cellpadding='0' cellspacing='0' class='divider_content' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-top: 4px solid #F39F0B; width: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td style='word-break: break-word; vertical-align: top; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top'><span></span></td></tr></tbody></table></td></tr></tbody></table></div></div></div></div></div></div><div style='background-color:#fff;'><div class='block-grid' style='min-width: 320px; max-width: 640px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; Margin: 0 auto; background-color: #fff;'><div style='border-collapse: collapse;display: table;width: 100%;background-color:#fff;'><div class='col num12' style='min-width: 320px; max-width: 640px; display: table-cell; vertical-align: top; width: 640px;'><div class='col_cont' style='width:100% !important;'><div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:0px; padding-bottom:0px; padding-right: 0px; padding-left: 0px;'><div align='center' class='img-container center autowidth' style='padding-right: 0px;padding-left: 0px;'><div style='font-size:1px;line-height:22px'> </div><img align='center' alt='I'm an image' border='0' class='center autowidth' src='{0}' style='text-decoration: none; -ms-interpolation-mode: bicubic; height: auto; border: 0; width: 100%; max-width: 149px; display: block;' title='I'm an image' width='149'/><div style='font-size:1px;line-height:25px'> </div></div></div></div></div></div></div></div><div style='background-color:transparent;'><div class='block-grid' style='min-width: 320px; max-width: 640px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; Margin: 0 auto; background-color: #f8f8f9;'><div style='border-collapse: collapse;display: table;width: 100%;background-color:#f8f8f9;'><div class='col num12' style='min-width: 320px; max-width: 640px; display: table-cell; vertical-align: top; width: 640px;'><div class='col_cont' style='width:100% !important;'><div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:5px; padding-bottom:5px; padding-right: 0px; padding-left: 0px;'><table border='0' cellpadding='0' cellspacing='0' class='divider' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td class='divider_inner' style='word-break: break-word; vertical-align: top; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; padding-top: 20px; padding-right: 20px; padding-bottom: 20px; padding-left: 20px;' valign='top'><table align='center' border='0' cellpadding='0' cellspacing='0' class='divider_content' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-top: 0px solid #BBBBBB; width: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td style='word-break: break-word; vertical-align: top; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top'><span></span></td></tr></tbody></table></td></tr></tbody></table></div></div></div></div></div></div><div style='background-color:transparent;'><div class='block-grid' style='min-width: 320px; max-width: 640px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; Margin: 0 auto; background-color: #fff;'><div style='border-collapse: collapse;display: table;width: 100%;background-color:#fff;'><div class='col num12' style='min-width: 320px; max-width: 640px; display: table-cell; vertical-align: top; width: 640px;'><div class='col_cont' style='width:100% !important;'><div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:0px; padding-bottom:0px; padding-right: 0px; padding-left: 0px;'><table border='0' cellpadding='0' cellspacing='0' class='divider' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td class='divider_inner' style='word-break: break-word; vertical-align: top; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; padding-top: 60px; padding-right: 0px; padding-bottom: 12px; padding-left: 0px;' valign='top'><table align='center' border='0' cellpadding='0' cellspacing='0' class='divider_content' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-top: 0px solid #BBBBBB; width: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td style='word-break: break-word; vertical-align: top; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top'><span></span></td></tr></tbody></table></td></tr></tbody></table><div align='center' class='img-container center fixedwidth' style='padding-right: 40px;padding-left: 40px;'><img align='center' alt='I'm an image' border='0' class='center fixedwidth' src='{1}' style='text-decoration: none; -ms-interpolation-mode: bicubic; height: auto; border: 0; width: 100%; max-width: 352px; display: block;' title='I'm an image' width='352'/></div><table border='0' cellpadding='0' cellspacing='0' class='divider' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td class='divider_inner' style='word-break: break-word; vertical-align: top; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; padding-top: 50px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px;' valign='top'><table align='center' border='0' cellpadding='0' cellspacing='0' class='divider_content' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-top: 0px solid #BBBBBB; width: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td style='word-break: break-word; vertical-align: top; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top'><span></span></td></tr></tbody></table></td></tr></tbody></table><div style='color:#555555;font-family:Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif;line-height:1.2;padding-top:10px;padding-right:40px;padding-bottom:10px;padding-left:40px;'><div style='line-height: 1.2; font-size: 12px; color: #555555; font-family: Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif; mso-line-height-alt: 14px;'><p style='font-size: 30px; line-height: 1.2; text-align: center; word-break: break-word; mso-line-height-alt: 36px; margin: 0;'><span style='font-size: 30px; color: #2b303a;'><strong>Recupeção de Senha</strong></span></p></div></div><div style='color:#555555;font-family:Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif;line-height:1.5;padding-top:10px;padding-right:40px;padding-bottom:10px;padding-left:40px;'><div style='line-height: 1.5; font-size: 12px; font-family: Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif; color: #555555; mso-line-height-alt: 18px;'><p style='font-size: 15px; line-height: 1.5; text-align: center; word-break: break-word; font-family: Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif; mso-line-height-alt: 23px; margin: 0;'><span style='color: #808389; font-size: 15px;'>Você solicitou a recuperação de sua conta de acesso ao Matemática é para poucos, clique em 'Redefinir Senha' para mudar de senha e recuperar seu acesso.</span></p></div></div><div align='center' class='button-container' style='padding-top:15px;padding-right:10px;padding-bottom:0px;padding-left:10px;'><a href='{2}' style='text-decoration:none;display:inline-block;color:#ffffff;background-color:#f39f0b;border-radius:60px;-webkit-border-radius:60px;-moz-border-radius:60px;width:auto; width:auto;;border-top:1px solid #f39f0b;border-right:1px solid #f39f0b;border-bottom:1px solid #f39f0b;border-left:1px solid #f39f0b;padding-top:15px;padding-bottom:15px;font-family:Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif;text-align:center;mso-border-alt:none;word-break:keep-all;'><span style='padding-left:30px;padding-right:30px;font-size:16px;display:inline-block;'><span style='font-size: 16px; margin: 0; line-height: 2; word-break: break-word; mso-line-height-alt: 32px;'><strong>Redefinir Senha</strong></span></span></a></div><table border='0' cellpadding='0' cellspacing='0' class='divider' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td class='divider_inner' style='word-break: break-word; vertical-align: top; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; padding-top: 60px; padding-right: 0px; padding-bottom: 12px; padding-left: 0px;' valign='top'><table align='center' border='0' cellpadding='0' cellspacing='0' class='divider_content' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-top: 0px solid #BBBBBB; width: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td style='word-break: break-word; vertical-align: top; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top'><span></span></td></tr></tbody></table></td></tr></tbody></table></div></div></div></div></div></div><div style='background-color:transparent;'><div class='block-grid' style='min-width: 320px; max-width: 640px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; Margin: 0 auto; background-color: #f8f8f9;'><div style='border-collapse: collapse;display: table;width: 100%;background-color:#f8f8f9;'><div class='col num12' style='min-width: 320px; max-width: 640px; display: table-cell; vertical-align: top; width: 640px;'><div class='col_cont' style='width:100% !important;'><div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:5px; padding-bottom:5px; padding-right: 0px; padding-left: 0px;'><table border='0' cellpadding='0' cellspacing='0' class='divider' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td class='divider_inner' style='word-break: break-word; vertical-align: top; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; padding-top: 20px; padding-right: 20px; padding-bottom: 20px; padding-left: 20px;' valign='top'><table align='center' border='0' cellpadding='0' cellspacing='0' class='divider_content' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-top: 0px solid #BBBBBB; width: 100%;' valign='top' width='100%'><tbody><tr style='vertical-align: top;' valign='top'><td style='word-break: break-word; vertical-align: top; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top'><span></span></td></tr></tbody></table></td></tr></tbody></table></div></div></div></div></div></div></td></tr></tbody></table></body>", logo, img, callback);
            await email.Mail(user.Email, "math4few@gmail.com", "Recuperação de Senha", mensagem);

            return Json(data: "2");
        }

        [AllowAnonymous]
        public IActionResult ResetPassword(string token, string email)
        {
            var model = new ResetPasswordModel { Token = token, Email = email };

            return View(model);
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<JsonResult> ResetPassword(ResetPasswordModel resetPassword)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false });
            }

            var user = await userManager.FindByNameAsync(resetPassword.Email);

            if (user == null)
            {
                return Json(data: "1");
            }

            var reset = await userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.Senha);

            if (!reset.Succeeded)
            {
                foreach (var error in reset.Errors)
                {
                    return Json(new { data = "2", erro = error.Description });
                }
            }

            return Json(data: "3");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Perfil(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = userManager.Users.Where(u => u.Id == id).SingleOrDefault();

            if (user == null)
            {
                return NotFound();
            }

            // Criamos um objeto UsuarioViewModel
            PerfilViewModel model = new PerfilViewModel()
            {
                Id = user.Id,
                Nome = user.Nome,
                Apelido = user.Apelido,
                DataNascimento = user.DataNascimento,
                Email = user.Email
            };

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Perfil(string id, PerfilViewModel model)
        {
            if (id != model.Id)
            {
                return Json(new { success = false });
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var user = userManager.Users.Where(u => u.Id == id).SingleOrDefault();
                    user.Nome = model.Nome;
                    user.Apelido = model.Apelido ?? model.Nome.Split(' ', StringSplitOptions.None)[0];
                    user.DataNascimento = model.DataNascimento;
                    await userManager.UpdateAsync(user); // Salva os dados do usuário
                }
                catch
                {
                    throw;
                }
                return Json(data: "1");
                //return RedirectToAction("Index");
            }
            return Json(new { success = false });
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
