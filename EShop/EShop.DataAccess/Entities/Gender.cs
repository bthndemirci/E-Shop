using System;
using EShop.Core.Signatures;

namespace EShop.DataAccess.Entities
{
    public class Gender : BaseEntity
    {
        public string Description { get; set; }
        public bool IsBlocked { get; set; }
        
        
    }
}