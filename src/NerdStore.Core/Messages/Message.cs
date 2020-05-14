using System;

namespace NerdStore.Core.Messages
{
    public abstract class Message
    {
        protected Message()
        {
            // retornando o nome da classe que esta implementando a classe message
            MessageType = GetType().Name;
        }

        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }
    }
}
