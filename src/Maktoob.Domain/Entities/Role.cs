using System;
using Microsoft.AspNetCore.Identity;

namespace Maktoob.Domain.Entities
{
    public class Role : Role<string>
    {
        
    }
    public class Role<TKey> : IdentityRole<TKey> where TKey : IEquatable<TKey>
    {

    }
}