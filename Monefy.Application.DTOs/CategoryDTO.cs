﻿

namespace Monefy.Application.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string?  Name { get; set; }
        public string? Description { get; set; }
        public string? UrlWeb { get; set; }

        public string Type { get; set; } = "expenses";
    }
}
