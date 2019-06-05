﻿using NetCore.AppServices.Commands.Usuario;
using NetCore.AppServices.Interfaces;
using NetCore.CrossCutting.Util;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flunt.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace NetCore.Api.Controllers
{
    /// <summary>
    /// Controller do Usuário.
    /// </summary>
    /// 
    //[Authorize]
    [EnableCors("Cors")]
    public class UsuarioController : BaseController
    {
        private const string USUARIO_OU_SENHA_ERRADO = "Usuário ou senha está incorreto!";
        private const string MESSAGE_ERRO_REGISTRAR_USUARIO = "Falha ao registrar o novo usuário. Por favor, tente novamente ou contate a equipe técnica!";
        private const string MESSAGE_ERRO_LOGAR_USUARIO = "Falha ao realizar o login. Por favor, tente novamente ou contate a equipe técnica!";
        private const string MESSAGE_ERRO_LISTAR_USUARIO = "Falha ao fazer a pesquisa dos usuários. Por favor, tente novamente ou contate a equipe técnica!";

        #region PROPERTIES
        private IUsuarioAppService _usuarioService { get; set; }
        #endregion

        #region Construtor

        public UsuarioController(IUsuarioAppService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        #endregion

        #region PUBLIC METHODS

        /// <summary>
        /// Registrar um Usuário
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("v1/usuario/registrarUsuario")]
        [AllowAnonymous]
        public async Task<IActionResult> RegistrarUsuario([FromBody] UsuarioPessoaCommand command)
        {
            try
            {
                
                var resultRequired = new UsuarioPessoaCommandContract(command);
                if (resultRequired.Invalid)
                {
                    return await Response(null, resultRequired.Notifications);
                }
                else
                {
                    return await Response(await _usuarioService.RegisterUser(command), null);
                }
            }
            catch (Exception ex)
            {
                return await Response(null, new List<Notification>() { new Notification(MESSAGE_ERRO_REGISTRAR_USUARIO, ex.Message) });
            }
        }

        /// <summary>
        /// Listar todos os Usuários
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/usuario/listarUsuarios")]
        public async Task<IActionResult> GetListarUsuarios()
        {
            try
            {
                return await Response(await _usuarioService.ListarUsuarios(), null);
            }
            catch (Exception ex)
            {
                return await Response(null, new List<Notification>() { new Notification(MESSAGE_ERRO_LISTAR_USUARIO, ex.Message) });
            }
        }

        /// <summary>
        /// Realizar Login na aplicação
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("v1/usuario/login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] CredencialCommand command)
        {
            try
            {
                var resultRequired = new CredencialCommandContract(command);
                if (resultRequired.Invalid)
                {
                    return await Response(null, resultRequired.Notifications);
                }
                else
                {
                    return await Response(await _usuarioService.LoginUsuario(command.Email, command.Senha), null);
                }
            }
            catch (Exception ex)
            {
                return await Response(null, new List<Notification>() { new Notification(MESSAGE_ERRO_LOGAR_USUARIO, ex.Message) });
            }
        }
        #endregion
    }
}