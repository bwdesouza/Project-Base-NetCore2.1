using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.AppServices.Commands.Usuario
{
    public class CredencialCommandContract : Notifiable
    {
        private const string REQUIRED_FIELD_MESSAGE = @"O campo {0} é obrigatório.";

        #region Construtor
        public CredencialCommandContract(CredencialCommand command)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(command.Email, nameof(command.Email), string.Format(REQUIRED_FIELD_MESSAGE, nameof(command.Email)))
                .IsNotNullOrEmpty(command.Senha, nameof(command.Senha), string.Format(REQUIRED_FIELD_MESSAGE, nameof(command.Senha))));
        }
        #endregion
    }
}
