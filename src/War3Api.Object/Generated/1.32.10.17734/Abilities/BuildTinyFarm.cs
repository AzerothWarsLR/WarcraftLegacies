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
    public sealed class BuildTinyFarm : Ability
    {
        public BuildTinyFarm(): base(1717717313)
        {
        }

        public BuildTinyFarm(int newId): base(1717717313, newId)
        {
        }

        public BuildTinyFarm(string newRawcode): base(1717717313, newRawcode)
        {
        }

        public BuildTinyFarm(ObjectDatabaseBase db): base(1717717313, db)
        {
        }

        public BuildTinyFarm(int newId, ObjectDatabaseBase db): base(1717717313, newId, db)
        {
        }

        public BuildTinyFarm(string newRawcode, ObjectDatabaseBase db): base(1717717313, newRawcode, db)
        {
        }
    }
}