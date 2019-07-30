using System;

namespace CustomerManagement.Common.SharedKernel
{
    public abstract class Entity
    {
        public Guid Id { get; private set; }

        protected Entity(bool newId = false)
        {
            if (newId)
            {
                Id = Guid.NewGuid();
            }
        }

        protected Entity(Guid id)
        {
            Id = id;
        }
    }
}
