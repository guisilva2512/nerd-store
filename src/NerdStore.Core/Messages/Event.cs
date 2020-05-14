using MediatR;
using System;

namespace NerdStore.Core.Messages
{
    // utilizaremos Meditr
    // Instalar no Catalogo.Domain e no Core o pacote: Install-Package MediatR
    public abstract class Event : Message, INotification
    {
        protected Event()
        {
            Timestamp = DateTime.Now;
        }

        public DateTime Timestamp { get; private set; }
    }
}
