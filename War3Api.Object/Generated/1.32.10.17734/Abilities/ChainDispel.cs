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
    public sealed class ChainDispel : Ability
    {
        public ChainDispel(): base(1701339969)
        {
        }

        public ChainDispel(int newId): base(1701339969, newId)
        {
        }

        public ChainDispel(string newRawcode): base(1701339969, newRawcode)
        {
        }

        public ChainDispel(ObjectDatabaseBase db): base(1701339969, db)
        {
        }

        public ChainDispel(int newId, ObjectDatabaseBase db): base(1701339969, newId, db)
        {
        }

        public ChainDispel(string newRawcode, ObjectDatabaseBase db): base(1701339969, newRawcode, db)
        {
        }
    }
}