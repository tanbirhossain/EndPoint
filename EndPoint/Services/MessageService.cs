using EndPoint.Resources;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Services
{
    public interface IMessageService
    {
        string Get(string key);
    }
    public class MessageService : IMessageService
    {
        private readonly IStringLocalizer<Resource> _localizer;

        public MessageService(IStringLocalizer<Resource> localizer)
        {
            _localizer = localizer;
        }

        public string Get(string key)
        {
            return _localizer[key].Value;

        }
    }
}
