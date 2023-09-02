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
    public sealed class AuraRegenerationItem : Ability
    {
        public AuraRegenerationItem(): base(2020034881)
        {
        }

        public AuraRegenerationItem(int newId): base(2020034881, newId)
        {
        }

        public AuraRegenerationItem(string newRawcode): base(2020034881, newRawcode)
        {
        }

        public AuraRegenerationItem(ObjectDatabaseBase db): base(2020034881, db)
        {
        }

        public AuraRegenerationItem(int newId, ObjectDatabaseBase db): base(2020034881, newId, db)
        {
        }

        public AuraRegenerationItem(string newRawcode, ObjectDatabaseBase db): base(2020034881, newRawcode, db)
        {
        }
    }
}