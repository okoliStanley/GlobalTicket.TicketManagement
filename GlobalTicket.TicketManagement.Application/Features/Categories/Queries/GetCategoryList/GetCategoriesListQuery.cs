using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace GlobalTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoryList
{
    public class GetCategoriesListQuery : IRequest<List<CategoryListVm>>
    {
    }
}
