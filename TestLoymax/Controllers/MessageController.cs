using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

using Telegram.Bot.Types;

using TestLoymax.Models;

namespace TestLoymax.Controllers
{

    public class MessageController : ApiController
    {
        [Route(@"update")]
        public async Task<OkResult> Update([FromBody]Update update)
        {
            if (update == null)
                return Ok();

            var commands = Bot.Commands;
            var message = update.Message;
            var client = await Bot.GetBotClientAsync();

            foreach (var command in commands)
            {
                if (command.Contains(message.Text.Split().First()))
                {
                    command.Execute(message, client);
                    break;
                }
            }

            return Ok();
        }      
    }
}
