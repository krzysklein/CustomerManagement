using CustomerManagement.Common.SharedKernel.Interfaces;

namespace CustomerManagement.Domain.Identity.Events
{
    public class UserChangedPasswordEvent : IEvent
    {
        public User User { get; }

        public UserChangedPasswordEvent(User user)
        {
            User = user;
        }
    }
}
