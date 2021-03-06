using System.ComponentModel.DataAnnotations;

namespace CommandsService.Models
{
    public class Command
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string WhoIs { get; set; }

        [Required]
        public string WhatName { get; set; }

        [Required]
        public int MessageId { get; set; }

        public Message Message {get; set;}


    }
}