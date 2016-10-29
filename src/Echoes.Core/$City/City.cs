using System;
using Auxo.Core;

namespace Echoes.Core
{
    public class City : Entity
    {
        public string Name { get; set; }
        public Guid StateId { get; set; }
        public virtual State State { get; }
    }
}