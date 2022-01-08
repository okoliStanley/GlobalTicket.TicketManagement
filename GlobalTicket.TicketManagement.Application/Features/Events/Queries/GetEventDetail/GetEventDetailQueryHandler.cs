using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using GlobalTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GlobalTicket.TicketManagement.Application.Features.Events
{
    public class GetEventDetailQueryHandler : IRequestHandler<GetEventDetailQuery, EventDetailVm>
    {
        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public GetEventDetailQueryHandler(IAsyncRepository<Event> eventRepository, IMapper mapper, IAsyncRepository<Category> category)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
            _categoryRepository = category;
        }

        public async Task<EventDetailVm> Handle(GetEventDetailQuery request, CancellationToken cancellationToken)
        {
            var eventDetails = await _eventRepository.GetByIdAsync(request.Id);
            var eventDetailVm = _mapper.Map<EventDetailVm>(eventDetails);

            var category = await _categoryRepository.GetByIdAsync(eventDetails.CategoryId);

            eventDetailVm.Category = _mapper.Map<CategoryDto>(category);

            return eventDetailVm;
        }
    }
}
