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
    public sealed class CairneEnduranceAura : Ability
    {
        public CairneEnduranceAura(): base(846352193)
        {
        }

        public CairneEnduranceAura(int newId): base(846352193, newId)
        {
        }

        public CairneEnduranceAura(string newRawcode): base(846352193, newRawcode)
        {
        }

        public CairneEnduranceAura(ObjectDatabaseBase db): base(846352193, db)
        {
        }

        public CairneEnduranceAura(int newId, ObjectDatabaseBase db): base(846352193, newId, db)
        {
        }

        public CairneEnduranceAura(string newRawcode, ObjectDatabaseBase db): base(846352193, newRawcode, db)
        {
        }
    }
}