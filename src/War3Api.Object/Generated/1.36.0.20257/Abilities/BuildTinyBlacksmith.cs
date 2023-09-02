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
    public sealed class BuildTinyBlacksmith : Ability
    {
        public BuildTinyBlacksmith(): base(1650608449)
        {
        }

        public BuildTinyBlacksmith(int newId): base(1650608449, newId)
        {
        }

        public BuildTinyBlacksmith(string newRawcode): base(1650608449, newRawcode)
        {
        }

        public BuildTinyBlacksmith(ObjectDatabaseBase db): base(1650608449, db)
        {
        }

        public BuildTinyBlacksmith(int newId, ObjectDatabaseBase db): base(1650608449, newId, db)
        {
        }

        public BuildTinyBlacksmith(string newRawcode, ObjectDatabaseBase db): base(1650608449, newRawcode, db)
        {
        }
    }
}