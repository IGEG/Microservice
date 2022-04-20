using System.Collections.Generic;
using CommandsService.Models;

namespace CommandsService.Data
{
    public interface ICommandRepository
    {
      
        IEnumerable<Message> GetAllMessage();
        void EditMessage(Message message);
        bool MessageExits(int messageId);
        bool ExternalMessageExists(int externalMessageId);


        IEnumerable<Command> GetCommandsForMessage(int messageId);
        Command GetCommand(int messageId, int commandId);
        void EditCommand(int messageId, Command command);
    }
}