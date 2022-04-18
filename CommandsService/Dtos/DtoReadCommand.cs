namespace CommandsService.Dtos
{
    public class DtoReadCommand
    {
        public int Id { get; set; }
        public string WhoIs { get; set; }
        public string WhatName { get; set; }
        public int PlatformId { get; set; }
    }
}