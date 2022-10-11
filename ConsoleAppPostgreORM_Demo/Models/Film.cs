using System;
using System.Collections.Generic;
using NpgsqlTypes;

namespace ConsoleAppPostgreORM_Demo.Models
{
    public partial class Film
    {
        public int FilmId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public int? ReleaseYear { get; set; }
        public short LanguageId { get; set; }
        public short RentalDuration { get; set; }
        public decimal RentalRate { get; set; }
        public short? Length { get; set; }
        public decimal ReplacementCost { get; set; }
        public DateTime LastUpdate { get; set; }
        public string[]? SpecialFeatures { get; set; }
        public NpgsqlTsVector Fulltext { get; set; } = null!;
    }
}
