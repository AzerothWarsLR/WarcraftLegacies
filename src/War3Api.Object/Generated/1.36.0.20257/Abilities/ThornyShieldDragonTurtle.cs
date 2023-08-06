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
    public sealed class ThornyShieldDragonTurtle : Ability
    {
        public ThornyShieldDragonTurtle(): base(846483009)
        {
        }

        public ThornyShieldDragonTurtle(int newId): base(846483009, newId)
        {
        }

        public ThornyShieldDragonTurtle(string newRawcode): base(846483009, newRawcode)
        {
        }

        public ThornyShieldDragonTurtle(ObjectDatabaseBase db): base(846483009, db)
        {
        }

        public ThornyShieldDragonTurtle(int newId, ObjectDatabaseBase db): base(846483009, newId, db)
        {
        }

        public ThornyShieldDragonTurtle(string newRawcode, ObjectDatabaseBase db): base(846483009, newRawcode, db)
        {
        }
    }
}