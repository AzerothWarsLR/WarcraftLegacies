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
    public sealed class DivineShieldItem : Ability
    {
        public DivineShieldItem(): base(1986283841)
        {
        }

        public DivineShieldItem(int newId): base(1986283841, newId)
        {
        }

        public DivineShieldItem(string newRawcode): base(1986283841, newRawcode)
        {
        }

        public DivineShieldItem(ObjectDatabaseBase db): base(1986283841, db)
        {
        }

        public DivineShieldItem(int newId, ObjectDatabaseBase db): base(1986283841, newId, db)
        {
        }

        public DivineShieldItem(string newRawcode, ObjectDatabaseBase db): base(1986283841, newRawcode, db)
        {
        }
    }
}