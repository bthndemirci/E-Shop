using System;
using EShop.Core.Signatures;

namespace EShop.DataAccess.Entities
{
    public class UserGroup : BaseEntity
    {
        public string Description { get; set; }
        public bool IsBlocked { get; set; }
        
    }
}