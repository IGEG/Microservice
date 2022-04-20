using System;
using System.Text.Json;
using AutoMapper;
using CommandsService.Data;
using CommandsService.Dtos;
using CommandsService.Models;
using Microsoft.Extensions.DependencyInjection;

namespace CommandsService.EventProcessing
{
    public class EventProcess : IEventProcess
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IMapper _mapper;

        public EventProcess(IServiceScopeFactory scopeFactory, AutoMapper.IMapper mapper)
        {
            _scopeFactory = scopeFactory;
            _mapper = mapper;
        }

        public void ProcessEvent(string message)
        {
            var eventType = DetermineEvent(message);

            switch (eventType)
            {
                case EventType.MessagePublished:
                    addPlatform(message);
                    break;
                default:
                    break;
            }
        }

        private EventType DetermineEvent(string notifcationMessage)
        {
            Console.WriteLine("--> Determining Event");

            var eventType = JsonSerializer.Deserialize<DtoGenericEvent>(notifcationMessage);

            switch(eventType.Event)
            {
                case "Platform_Published":
                    Console.WriteLine("--> Platform Published Event Detected");
                    return EventType.MessagePublished;
                default:
                    Console.WriteLine("--> Could not determine the event type");
                    return EventType.Undetermined;
            }
        }

        private void addMessage(string platformPublishedMessage)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<ICommandRepository>();
                
                var dtoPublishMessage = JsonSerializer.Deserialize<DtoPublishMessage>(platformPublishedMessage);

                try
                {
                    var message = _mapper.Map<Message>(dtoPublishMessage);
                    if(!repo.ExternalPlatformExists(plat.ExternalID))
                    {
                        repo.CreatePlatform(message);
                        repo.SaveChanges();
                        Console.WriteLine("--> Message added!");
                    }
                    else
                    {
                        Console.WriteLine("--> Message already exisits...");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"--> Could not add Messsage to DB {ex.Message}");
                }
            }
        }
    }

    enum EventType
    {
        MessagePublished,
        Undetermined
    }
}