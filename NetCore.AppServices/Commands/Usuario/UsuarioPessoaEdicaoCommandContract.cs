using Flunt.Notifications;
using Flunt.Validations;

namespace NetCore.AppServices.Commands.Usuario
{
    public class UsuarioPessoaEdicaoCommandContract : Notifiable
    {
        private const string REQUIRED_FIELD_MESSAGE = @"O campo {0} é obrigatório.";
        private const string PASSWORD_FIELD_MESSAGE = @"O campo Senha não confere com a Confirmação da Senha!";
        private const string REQUIRED_FIELD_MESSAGE_VALID = @"O campo {0} não é um {0} válido.";

        #region Construtor
        public UsuarioPessoaEdicaoCommandContract(UsuarioPessoaEdicaoCommand command)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(command.Id, nameof(command.Nome), string.Format(REQUIRED_FIELD_MESSAGE, nameof(command.Nome)))
                .IsNotNullOrEmpty(command.Nome, nameof(command.Nome), string.Format(REQUIRED_FIELD_MESSAGE, nameof(command.Nome)))
                .AreEquals(command.Senha, command.ConfirmacaoSenha, nameof(command.Senha), string.Format(PASSWORD_FIELD_MESSAGE))
                .IsEmailOrEmpty(command.Email, nameof(command.Email), string.Format(REQUIRED_FIELD_MESSAGE_VALID, nameof(command.Email)))
                .IsNotNullOrEmpty(command.Email, nameof(command.Email), string.Format(REQUIRED_FIELD_MESSAGE, nameof(command.Email))));
        }
        #endregion
    }
}