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
    public sealed class CairneWarStomp : Ability
    {
        public CairneWarStomp(): base(846679873)
        {
        }

        public CairneWarStomp(int newId): base(846679873, newId)
        {
        }

        public CairneWarStomp(string newRawcode): base(846679873, newRawcode)
        {
        }

        public CairneWarStomp(ObjectDatabaseBase db): base(846679873, db)
        {
        }

        public CairneWarStomp(int newId, ObjectDatabaseBase db): base(846679873, newId, db)
        {
        }

        public CairneWarStomp(string newRawcode, ObjectDatabaseBase db): base(846679873, newRawcode, db)
        {
        }
    }
}