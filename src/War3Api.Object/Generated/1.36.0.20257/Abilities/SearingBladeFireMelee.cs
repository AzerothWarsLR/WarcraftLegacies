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
    public sealed class SearingBladeFireMelee : Ability
    {
        public SearingBladeFireMelee(): base(2003192129)
        {
        }

        public SearingBladeFireMelee(int newId): base(2003192129, newId)
        {
        }

        public SearingBladeFireMelee(string newRawcode): base(2003192129, newRawcode)
        {
        }

        public SearingBladeFireMelee(ObjectDatabaseBase db): base(2003192129, db)
        {
        }

        public SearingBladeFireMelee(int newId, ObjectDatabaseBase db): base(2003192129, newId, db)
        {
        }

        public SearingBladeFireMelee(string newRawcode, ObjectDatabaseBase db): base(2003192129, newRawcode, db)
        {
        }
    }
}