using System;
using System.Collections.Generic;
using System.Text;
using Taskera.Domain.Common;
using Taskera.Domain.Identity;

namespace Taskera.Domain.Boards.Events
{
    public sealed record CommentAddedEvent(CardId CardId, UserId Author, string Content) : IDomainEvent
    {
        public DateTime OccurredOn {  get; init; } = DateTime.UtcNow;
    }
}
