using System;
using Auxo.Data;
using Echoes.Core;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Echoes.Data
{
    public class CityMap : Map<City>
    {
        public CityMap(EntityTypeBuilder<City> map) : base(map)
        {
            map.HasIndex(p => new { p.StateId, p.Name }).IsUnique();
            map.Property(p => p.Name).IsRequired().HasMaxLength(30);
        }
    }
}