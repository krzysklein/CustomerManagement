using CustomerManagement.Common.SharedKernel.Interfaces;

namespace CustomerManagement.Domain.Identity.Events
{
    public class UserCreatedEvent : IEvent
    {
        public User User { get; }

        public UserCreatedEvent(User user)
        {
            User = user;
        }
    }
}
