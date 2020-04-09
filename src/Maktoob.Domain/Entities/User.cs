using System;
using Microsoft.AspNetCore.Identity;

namespace Maktoob.Domain.Entities
{
    public class User : User<string>
    {
        
    }
    public class User<TKey> : IdentityUser<TKey> where TKey : IEquatable<TKey>
    {
        public DateTime LastActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}