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
    public sealed class FlagUndead : Ability
    {
        public FlagUndead(): base(1701202241)
        {
        }

        public FlagUndead(int newId): base(1701202241, newId)
        {
        }

        public FlagUndead(string newRawcode): base(1701202241, newRawcode)
        {
        }

        public FlagUndead(ObjectDatabaseBase db): base(1701202241, db)
        {
        }

        public FlagUndead(int newId, ObjectDatabaseBase db): base(1701202241, newId, db)
        {
        }

        public FlagUndead(string newRawcode, ObjectDatabaseBase db): base(1701202241, newRawcode, db)
        {
        }
    }
}