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
    public sealed class DeathPactItem : Ability
    {
        public DeathPactItem(): base(1885620545)
        {
        }

        public DeathPactItem(int newId): base(1885620545, newId)
        {
        }

        public DeathPactItem(string newRawcode): base(1885620545, newRawcode)
        {
        }

        public DeathPactItem(ObjectDatabaseBase db): base(1885620545, db)
        {
        }

        public DeathPactItem(int newId, ObjectDatabaseBase db): base(1885620545, newId, db)
        {
        }

        public DeathPactItem(string newRawcode, ObjectDatabaseBase db): base(1885620545, newRawcode, db)
        {
        }
    }
}