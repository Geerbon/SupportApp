using SupportApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace SupportApplication.Repositories
{
    public class MessagesRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext context;

        //Прокидываем ApplicationDbContext, чтобы достать все сообщения из базы данных
        public MessagesRepository(IConfiguration configuration, ApplicationDbContext context)
        {
            _configuration = configuration;
            this.context = context; 
        }

        // Достаем сообщения из БД
        public List<Messages> GetAllMessages()
        {
            var messages = context.Messages.ToList();
            return messages;
        }

        public void Add(Messages messages)
        {
            context.Messages.Add(messages);
            context.SaveChanges();
        }
    }
}
