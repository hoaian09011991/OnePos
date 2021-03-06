﻿using System;
using MVCForum.Utilities;

namespace MVCForum.Domain.DomainModel
{
    public partial class CategoryPermissionForRole : Entity
    {
        public CategoryPermissionForRole()
        {
            Id = GuidComb.GenerateComb();
        }
        public Guid Id { get; set; }
        public virtual Permission Permission { get; set; }
        public virtual MembershipRole MembershipRole { get; set; }
        public virtual Category Category { get; set; }
        public bool IsTicked { get; set; }
    }
}
