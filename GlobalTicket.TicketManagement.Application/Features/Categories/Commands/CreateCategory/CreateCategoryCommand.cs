﻿using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace GlobalTicket.TicketManagement.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<CreateCategoryCommandResponse>
    {
        public string Name { get; set; }
    }
}
