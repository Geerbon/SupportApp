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

        //Fix
        public void Add(Messages messages)
        {
            context.Messages.Add(messages);
            context.SaveChanges();
        }

        public void Update(Messages messages)
        {
            context.Messages.Update(messages);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var message = context.Messages.FirstOrDefault(x => x.Id == id);
            context.Messages.Remove(message);
            context.SaveChanges();
        }

        public Messages Get(int id)
        {
            return (context.Messages.FirstOrDefault(x => x.Id == id));
        }


    }
}
