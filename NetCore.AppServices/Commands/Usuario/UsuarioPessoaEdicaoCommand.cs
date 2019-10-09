using System;

namespace NetCore.AppServices.Commands.Usuario
{
    public class UsuarioPessoaEdicaoCommand
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ConfirmacaoSenha { get; set; }
    }
}