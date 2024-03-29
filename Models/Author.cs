﻿using System.ComponentModel.DataAnnotations;
using RESTful_Web_API.Models;

namespace RESTful_Web_API.Models
{
    public class Author
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTime? DateOfBirth { get; set; }

        // One-to-many relationship with books
        public List<Book>? Books { get; set; }
    }
}