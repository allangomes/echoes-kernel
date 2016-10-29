using Auxo.Data;
using Echoes.Core;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Echoes.Data
{
    public class StateMap : Map<State>
    {
        public StateMap(EntityTypeBuilder<State> map) : base(map)
        {
            map.HasIndex(p => new { p.Code }).IsUnique();
            map.HasIndex(p => new { p.Name }).IsUnique();
            map.Property(p => p.Code).IsRequired().HasMaxLength(2);
            map.Property(p => p.Name).IsRequired().HasMaxLength(30);
        }
    }
}