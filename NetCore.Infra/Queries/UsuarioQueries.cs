using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Infra.Repositories
{
    public partial class UsuarioRepository
    {
        #region SELECT
        private const string LISTAR_USUARIOS =
                            @"SELECT *
                                FROM [dbo].[ApplicationUser]";

        private const string BUSCAR_USUARIO =
                            @"SELECT *
                              FROM [dbo].[ApplicationUser]
                              WHERE Email = @Email";

        private const string BUSCAR_USUARIO_ID =
                            @"SELECT *
                                FROM [dbo].[ApplicationUser]
                                WHERE [Id] = @Id";
        #endregion

        #region DELETE
        private const string DELETAR_USUARIO =
            @"DELETE FROM [dbo].[ApplicationUser]
                                WHERE Id = @Id ";
        #endregion

        #region UPDATE
        private const string ATUALIZAR_USUARIO =
                            @"UPDATE [dbo].[ApplicationUser]
                                       SET [UserName] = @UserName
                                          ,[PasswordHash] = @PasswordHash
                                          ,[PasswordSalt] = @PasswordSalt
                                WHERE Id = @Id ";
        #endregion

        #region INSERT
        private const string SALVAR_USUARIO =
                           @"INSERT INTO [dbo].[ApplicationUser]
                                               ([Id]
                                               ,[UserName]
                                               ,[PasswordHash]
                                               ,[PasswordSalt]
                                               ,[Email]
                                               ,[EmailConfirmed]
                                               ,[IsEnabled])
                                         VALUES
                                               (@Id
                                               ,@UserName
                                               ,@PasswordHash
                                               ,@PasswordSalt
                                               ,@Email
                                               ,@EmailConfirmed
                                               ,@IsEnabled)";
        #endregion
    }
}
