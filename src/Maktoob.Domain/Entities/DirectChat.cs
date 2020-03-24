using System;

namespace maktoob.Domain.Entities
{
    public class DirectChat : DirectChat<Guid>
    {
        public DirectChat(Guid peerId1, Guid peerId2) : base(peerId1, peerId2)
        {
        }
    }
    public class DirectChat<TKey> : Chat where TKey : IEquatable<TKey>
    {
        public DirectChat(TKey peerId1, TKey peerId2)
        {
            PeerId1 = peerId1;
            PeerId2 = peerId2;
        }

        public TKey PeerId1 { get; private set; }
        public TKey PeerId2 { get; private set; }
    }
}