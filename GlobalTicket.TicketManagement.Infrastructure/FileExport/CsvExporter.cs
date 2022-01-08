using GlobalTicket.TicketManagement.Application.Contracts.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CsvHelper;
using System.Globalization;
using GlobalTicket.TicketManagement.Application.Features.Events.Queries.GetEventExport;

namespace GlobalTicket.TicketManagement.Infrastructure.FileExport
{
    public class CsvExporter : ICsvExporter
    {
        public byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos)
        {
            using var memoryStream = new MemoryStream();
            using(var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
                csvWriter.WriteRecords(eventExportDtos);
            }

            return memoryStream.ToArray();
        }
    }
}
