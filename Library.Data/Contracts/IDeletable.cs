using System;

namespace Library.Data.Contracts
{
    public interface IDeletable
    {
        DateTime? DeletedOn { get; set; }

        bool IsDeleted { get; set; }
    }
}
