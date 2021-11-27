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
    public sealed class FeralSpiritAkama : Ability
    {
        public FeralSpiritAkama(): base(930300737)
        {
        }

        public FeralSpiritAkama(int newId): base(930300737, newId)
        {
        }

        public FeralSpiritAkama(string newRawcode): base(930300737, newRawcode)
        {
        }

        public FeralSpiritAkama(ObjectDatabaseBase db): base(930300737, db)
        {
        }

        public FeralSpiritAkama(int newId, ObjectDatabaseBase db): base(930300737, newId, db)
        {
        }

        public FeralSpiritAkama(string newRawcode, ObjectDatabaseBase db): base(930300737, newRawcode, db)
        {
        }
    }
}