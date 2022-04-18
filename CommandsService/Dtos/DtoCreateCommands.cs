using System.ComponentModel.DataAnnotations;

namespace CommandsService.Dtos
{
    public class DtoCreateCommands
    {
        [Required]
        public string WhoIs { get; set; }

        [Required]
        public string WhatName { get; set; }
    }
}