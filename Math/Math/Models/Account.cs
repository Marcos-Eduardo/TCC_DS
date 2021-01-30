using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Math.Models
{
    public class Account
    {
        public AccountLogin Login { get; set; }
        public AccountRegister Register { get; set; }
    }

    public class AccountLogin
    {
        [Display(Name = "E-mail de Acesso", Prompt = "E-mail")]
        [Required(ErrorMessage = "Por favor, informe seu E-mail de Acesso")]
        [EmailAddress(ErrorMessage = "Por favor, informe um E-mail válido")]
        [StringLength(100, ErrorMessage = "Seu E-mail de acesso não pode possuir mais de 100 caracteres")]
        public string EmailLogin { get; set; }

        [Display(Name = "Senha", Prompt = "Senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Por favor, informe sua Senha")]
        [StringLength(20, ErrorMessage = "Sua Senha deve possuir de 5 a 20 caracteres", MinimumLength = 5)]
        public string SenhaLogin { get; set; }

        [Display(Name = "Manter-me conectado", Prompt = "Manter-me conectado")]
        public bool ManterConectado { get; set; }
    }

    public class AccountRegister
    {
        [Display(Name = "Nome Completo", Prompt = "Nome Completo")]
        [Required(ErrorMessage = "Por favor, informe o Nome.")]
        [StringLength(50, ErrorMessage = "O nome não deve possuir mais de 50 caracteres.")]
        public string Nome { get; set; }

        [Display(Name = "Apelido", Prompt = "Apelido")]
        [StringLength(15, ErrorMessage = "O apelido não deve possuir mais de 15 caracteres.")]
        public string Apelido { get; set; }

        [Required(ErrorMessage = "Por favor, informe a Data de Nascimento.")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "E-mail de Acesso", Prompt = "E-mail")]
        [Required(ErrorMessage = "Por favor, informe seu E-mail de Acesso")]
        [EmailAddress(ErrorMessage = "Por favor, informe um E-mail válido")]
        [StringLength(100, ErrorMessage = "Seu E-mail de acesso não pode possuir mais de 100 caracteres")]
        public string EmailRegister { get; set; }

        [Display(Name = "Senha", Prompt = "Senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Por favor, informe sua Senha")]
        [StringLength(20, ErrorMessage = "Sua Senha deve possuir de 5 a 20 caracteres", MinimumLength = 5)]
        public string SenhaRegister { get; set; }
    }

    public class ForgotPasswordModel
    {
        [Display(Name = "E-mail de Acesso", Prompt = "E-mail")]
        [Required(ErrorMessage = "Por favor, informe seu E-mail de Acesso")]
        [EmailAddress(ErrorMessage = "Por favor, informe um E-mail válido")]
        [StringLength(100, ErrorMessage = "Seu E-mail de acesso não pode possuir mais de 100 caracteres")]
        public string Email { get; set; }
    }

    public class ResetPasswordModel
    {
        [Display(Name = "Nova Senha", Prompt = "Nova Senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Por favor, informe sua Nova Senha")]
        [StringLength(20, ErrorMessage = "Sua Nova Senha deve possuir de 5 a 20 caracteres", MinimumLength = 5)]
        public string Senha { get; set; }

        [Display(Name = "Confirmação de Senha", Prompt = "Confirmação de Senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Por favor, informe a Confirmação de Senha")]
        [StringLength(20, ErrorMessage = "A Confirmação de Senha deve possuir de 5 a 20 caracteres", MinimumLength = 5)]
        [Compare("Senha", ErrorMessage = "A Nova Senha e a Confirmação de Senha não conferem")]
        public string ConfirmacaoSenha { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }
    }

    public class UsuarioViewModel
    {
        [HiddenInput]
        public string Id { get; set; }

        [Display(Name = "E-mail de Acesso", Prompt = "E-mail de Acesso")]
        [Required(ErrorMessage = "Por favor, Informe o E-mail de Acesso")]
        [EmailAddress(ErrorMessage = "Por favor, Informe o E-mail Válido")]
        public string Email { get; set; }

        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "Por favor, informe o Nome do Usuário")]
        [StringLength(50, ErrorMessage = "O Nome do Usuário deve possuir no máximo 50 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Apelido")]
        [StringLength(15, ErrorMessage = "O Apelido deve possuir no máximo 15 caracteres")]
        public string Apelido { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Perfil de Acesso")]
        [Required(ErrorMessage = "Por favor, informe o Perfil de Acesso do Usuário")]
        public string Perfil { get; set; }
    }

    public class CreateUsuarioViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "Por favor, informe o Nome do Usuário")]
        [StringLength(50, ErrorMessage = "O Nome do Usuário deve possuir no máximo 50 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Apelido")]
        [StringLength(15, ErrorMessage = "O Apelido deve possuir no máximo 15 caracteres")]
        public string Apelido { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "E-mail de Acesso")]
        [Required(ErrorMessage = "Por favor, informe seu E-mail de Acesso")]
        [EmailAddress(ErrorMessage = "Por favor, informe um E-mail válido")]
        [StringLength(100, ErrorMessage = "Seu E-mail de acesso não pode possuir mais de 100 caracteres")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Por favor, informe sua Senha")]
        [StringLength(20, ErrorMessage = "Sua Senha deve possuir de 5 a 20 caracteres", MinimumLength = 5)]
        public string Senha { get; set; }

        [Display(Name = "Confirmação de Senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Por favor, informe a Confirmação de Senha")]
        [StringLength(20, ErrorMessage = "A Confirmação de Senha deve possuir de 5 a 20 caracteres", MinimumLength = 5)]
        [Compare("Senha", ErrorMessage = "A Senha e a Confirmação de Senha não conferem")]
        public string ConfirmacaoSenha { get; set; }

        [Display(Name = "Perfil de Acesso")]
        [Required(ErrorMessage = "Por favor, informe o Perfil de Acesso do Usuário")]
        public string Perfil { get; set; }
    }

    public class PerfilViewModel
    {
        [HiddenInput]
        public string Id { get; set; }

        [Display(Name = "E-mail de Acesso", Prompt = "E-mail de Acesso")]
        [Required(ErrorMessage = "Por favor, Informe o E-mail de Acesso")]
        [EmailAddress(ErrorMessage = "Por favor, Informe o E-mail Válido")]
        public string Email { get; set; }

        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "Por favor, informe o Nome do Usuário")]
        [StringLength(50, ErrorMessage = "O Nome do Usuário deve possuir no máximo 50 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Apelido")]
        [StringLength(15, ErrorMessage = "O Apelido deve possuir no máximo 15 caracteres")]
        public string Apelido { get; set; }

        [Required(ErrorMessage = "Por favor, informe a Data de Nascimento.")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
    }
}
