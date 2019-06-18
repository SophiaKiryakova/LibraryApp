﻿using System;

namespace Library.Data.Contracts
{
    public abstract class BaseEntity: IAuditable, IDeletable
    {
        public int Id { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
