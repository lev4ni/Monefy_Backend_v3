﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Application.DTOs
{
    public class WalletIncomeDTO
    {
        public int Id { get; set; }
        public CategoryDTO? Category { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public int WalletId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}