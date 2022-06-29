using apiplate.DataBase;
using apiplate.Models;
using apiplate.Interfaces;
using apiplate.Resources;
using apiplate.Resources.Requests;
using apiplate.Utils.URI;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace apiplate.Services
{
    public class MessageService : BaseService<Message, MessageResource,MessageRequestResource>, IMessagesService
    {
        public MessageService(IMapper mapper, ApiplateDbContext context, IUriService uriSerivce) : base(mapper, context, uriSerivce)
        {
        }
        protected override string GetSearchPropValue(Message obj)
        {
             var type = typeof(Message);
            var usernameProp = type.GetProperties().SingleOrDefault(c => c.Name.ToLower() == "fullname");
            var usernameValue = usernameProp?.GetValue(obj).ToString();
            return usernameValue;
        }
    }
}