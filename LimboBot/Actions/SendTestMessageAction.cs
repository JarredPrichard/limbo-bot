using System;
using System.Collections.Generic;
using System.Text;
using LimboBot.Model.DTO;
using System.Threading.Tasks;

namespace LimboBot.Actions
{
    class SendTestMessageAction : LimboAction
    {
        public SendTestMessageAction(IServiceProvider services, LimboSettings settings) : base(services, settings)
        {
        }

        public override Task Run()
        {
            this.Slack.SendMessage("pullrequests", "Hello from DI!").Wait();
            return null;
        }
    }
}
