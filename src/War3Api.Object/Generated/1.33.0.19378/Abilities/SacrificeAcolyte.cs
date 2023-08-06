using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class SacrificeAcolyte : Ability
    {
        public SacrificeAcolyte(): base(1835101249)
        {
        }

        public SacrificeAcolyte(int newId): base(1835101249, newId)
        {
        }

        public SacrificeAcolyte(string newRawcode): base(1835101249, newRawcode)
        {
        }

        public SacrificeAcolyte(ObjectDatabaseBase db): base(1835101249, db)
        {
        }

        public SacrificeAcolyte(int newId, ObjectDatabaseBase db): base(1835101249, newId, db)
        {
        }

        public SacrificeAcolyte(string newRawcode, ObjectDatabaseBase db): base(1835101249, newRawcode, db)
        {
        }
    }
}