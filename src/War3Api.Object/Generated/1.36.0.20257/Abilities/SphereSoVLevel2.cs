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
    public sealed class SphereSoVLevel2 : Ability
    {
        public SphereSoVLevel2(): base(846230337)
        {
        }

        public SphereSoVLevel2(int newId): base(846230337, newId)
        {
        }

        public SphereSoVLevel2(string newRawcode): base(846230337, newRawcode)
        {
        }

        public SphereSoVLevel2(ObjectDatabaseBase db): base(846230337, db)
        {
        }

        public SphereSoVLevel2(int newId, ObjectDatabaseBase db): base(846230337, newId, db)
        {
        }

        public SphereSoVLevel2(string newRawcode, ObjectDatabaseBase db): base(846230337, newRawcode, db)
        {
        }
    }
}