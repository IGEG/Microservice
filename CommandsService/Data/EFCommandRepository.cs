using System;
using System.Collections.Generic;
using System.Linq;
using CommandsService.Models;

namespace CommandsService.Data
{
    public class EFCommandRepository : ICommandRepository
    {
        private readonly AppDbContext context;

        public EFCommandRepository(AppDbContext _context)
        {
            context = _context;
        }

        public void EditCommand(int messageId, Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            command.MessageId = messageId;
            context.Commands.Add(command);
            context.SaveChanges();
        }

        public void EditMessage(Message message)
        {
            if(message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }
            context.Messages.Add(message);
            context.SaveChanges();
        }

        public bool ExternalMessageExists(int externalMessageId)
        {
            return context.Messages.Any(m => m.ExternalID == externalMesssageId);
        }

        public IEnumerable<Message> GetAllMessages()
        {
            return context.Messages.ToList();
        }

        public Command GetCommand(int messageId, int commandId)
        {
            return context.Commands
                .Where(c => c.MessageId == messageId && c.Id == commandId).FirstOrDefault();
        }

        public IEnumerable<Command> GetCommandsForMessage(int messageId)
        {
            return context.Commands
                .Where(c => c.MessageId == messageId)
                .OrderBy(c => c.Message.Name);
        }

        public bool MessageExits(int messageId)
        {
            return context.Messages.Any(m => m.Id == messageId);
        }

    }
}