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
    public sealed class SoulTrap : Ability
    {
        public SoulTrap(): base(1869826369)
        {
        }

        public SoulTrap(int newId): base(1869826369, newId)
        {
        }

        public SoulTrap(string newRawcode): base(1869826369, newRawcode)
        {
        }

        public SoulTrap(ObjectDatabaseBase db): base(1869826369, db)
        {
        }

        public SoulTrap(int newId, ObjectDatabaseBase db): base(1869826369, newId, db)
        {
        }

        public SoulTrap(string newRawcode, ObjectDatabaseBase db): base(1869826369, newRawcode, db)
        {
        }
    }
}