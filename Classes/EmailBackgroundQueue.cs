using palmHillsapp.DTOs;
using System.Collections.Concurrent;

   
namespace palmHillsapp.Classes

{
    public class EmailBackgroundQueue
    {
 
        private readonly ConcurrentQueue<EmailSender> _queue = new();
        public void Enqueue(EmailSender item) => _queue.Enqueue(item);
        public bool TryDequeue(out EmailSender? item) => _queue.TryDequeue(out item);

        internal void Enqueue(EmailSenderDTOs entity)
        {
            throw new NotImplementedException();
        }
    }

}

