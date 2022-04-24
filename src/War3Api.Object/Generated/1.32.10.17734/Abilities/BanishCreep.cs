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
    public sealed class BanishCreep : Ability
    {
        public BanishCreep(): base(1851933505)
        {
        }

        public BanishCreep(int newId): base(1851933505, newId)
        {
        }

        public BanishCreep(string newRawcode): base(1851933505, newRawcode)
        {
        }

        public BanishCreep(ObjectDatabaseBase db): base(1851933505, db)
        {
        }

        public BanishCreep(int newId, ObjectDatabaseBase db): base(1851933505, newId, db)
        {
        }

        public BanishCreep(string newRawcode, ObjectDatabaseBase db): base(1851933505, newRawcode, db)
        {
        }
    }
}