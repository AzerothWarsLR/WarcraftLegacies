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
    public sealed class AcolyteHarvest : Ability
    {
        public AcolyteHarvest(): base(1634230593)
        {
        }

        public AcolyteHarvest(int newId): base(1634230593, newId)
        {
        }

        public AcolyteHarvest(string newRawcode): base(1634230593, newRawcode)
        {
        }

        public AcolyteHarvest(ObjectDatabaseBase db): base(1634230593, db)
        {
        }

        public AcolyteHarvest(int newId, ObjectDatabaseBase db): base(1634230593, newId, db)
        {
        }

        public AcolyteHarvest(string newRawcode, ObjectDatabaseBase db): base(1634230593, newRawcode, db)
        {
        }
    }
}