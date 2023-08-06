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
    public sealed class FingerOfDeath_Afod : Ability
    {
        public FingerOfDeath_Afod(): base(1685022273)
        {
        }

        public FingerOfDeath_Afod(int newId): base(1685022273, newId)
        {
        }

        public FingerOfDeath_Afod(string newRawcode): base(1685022273, newRawcode)
        {
        }

        public FingerOfDeath_Afod(ObjectDatabaseBase db): base(1685022273, db)
        {
        }

        public FingerOfDeath_Afod(int newId, ObjectDatabaseBase db): base(1685022273, newId, db)
        {
        }

        public FingerOfDeath_Afod(string newRawcode, ObjectDatabaseBase db): base(1685022273, newRawcode, db)
        {
        }
    }
}