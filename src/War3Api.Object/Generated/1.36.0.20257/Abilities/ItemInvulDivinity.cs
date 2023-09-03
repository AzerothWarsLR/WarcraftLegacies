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
    public sealed class ItemInvulDivinity : Ability
    {
        public ItemInvulDivinity(): base(1735805249)
        {
        }

        public ItemInvulDivinity(int newId): base(1735805249, newId)
        {
        }

        public ItemInvulDivinity(string newRawcode): base(1735805249, newRawcode)
        {
        }

        public ItemInvulDivinity(ObjectDatabaseBase db): base(1735805249, db)
        {
        }

        public ItemInvulDivinity(int newId, ObjectDatabaseBase db): base(1735805249, newId, db)
        {
        }

        public ItemInvulDivinity(string newRawcode, ObjectDatabaseBase db): base(1735805249, newRawcode, db)
        {
        }
    }
}