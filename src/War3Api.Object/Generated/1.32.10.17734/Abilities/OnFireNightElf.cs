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
    public sealed class OnFireNightElf : Ability
    {
        public OnFireNightElf(): base(1852401217)
        {
        }

        public OnFireNightElf(int newId): base(1852401217, newId)
        {
        }

        public OnFireNightElf(string newRawcode): base(1852401217, newRawcode)
        {
        }

        public OnFireNightElf(ObjectDatabaseBase db): base(1852401217, db)
        {
        }

        public OnFireNightElf(int newId, ObjectDatabaseBase db): base(1852401217, newId, db)
        {
        }

        public OnFireNightElf(string newRawcode, ObjectDatabaseBase db): base(1852401217, newRawcode, db)
        {
        }
    }
}