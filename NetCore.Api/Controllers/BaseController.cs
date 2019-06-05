using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Api.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// Response
        /// </summary>
        /// <param name="result">Objeto resultado</param>
        /// <param name="notifications">Coleção de Notificações</param>
        /// <returns>Ok ou BadRequest</returns>
        public async Task<IActionResult> Response(object result, IReadOnlyCollection<Notification> notifications)
        {
            if (notifications == null || !notifications.Any())
            {
                try
                {
                    return Ok(new
                    {
                        success = true,
                        data = result
                    });
                }
                catch
                {
                    return BadRequest(new
                    {
                        success = false,
                        errors = new[] { "Ocorreu uma falha interna no servidor." }
                    });
                }
            }
            else
            {
                return BadRequest(new
                {
                    success = false,
                    errors = notifications
                });
            }
        }

    }
}
