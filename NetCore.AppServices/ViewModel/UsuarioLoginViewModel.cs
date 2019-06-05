using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.AppServices.ViewModel
{
    public class UsuarioLoginViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Senha { get; set; }
        public string ConfirmacaoSenha { get; set; }
        public bool Status { get; set; }

        public string Token { get; set; }
    }
}
