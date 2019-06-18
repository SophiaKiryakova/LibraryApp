using System;

namespace Library.Data.Contracts
{
    public interface IAuditable
    {
        DateTime? CreatedOn { get; set; }

        DateTime? ModifiedOn { get; set; }
    }
}
