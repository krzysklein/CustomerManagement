using CustomerManagement.Common.SharedKernel.Interfaces;

namespace CustomerManagement.Domain.Identity.Events
{
    public class UserChangedContactDetails : IEvent
    {
        public User User { get; }

        public UserChangedContactDetails(User user)
        {
            User = user;
        }
    }
}
