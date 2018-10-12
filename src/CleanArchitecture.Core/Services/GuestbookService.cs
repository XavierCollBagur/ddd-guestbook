using System.Collections.Generic;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;

namespace CleanArchitecture.Core.Services
{
    public class GuestbookService : IGuestbookService
    {
        private readonly IRepository _repository;
        private readonly IMessageSender _messageSender;

        public GuestbookService(IRepository repository, IMessageSender messageSender)
        {
            _repository = repository;
            _messageSender = messageSender;
        }

        public void RecordEntry(Guestbook guestbook, GuestbookEntry newEntry)
        {
            List<GuestbookEntry> guestbookEntries = _repository.List<GuestbookEntry>();

            foreach (var entry in guestbookEntries)
            {
                _messageSender.SendGuestbookNotificationEmail(entry.EmailAddress, "New guestbook entry added");
            }

            guestbook.Entries.Clear();
            guestbook.Entries.AddRange(guestbookEntries); // maintain existing Guestbook Entries
            guestbook.Entries.Add(newEntry);
            _repository.Update(guestbook);
        }
    }
}