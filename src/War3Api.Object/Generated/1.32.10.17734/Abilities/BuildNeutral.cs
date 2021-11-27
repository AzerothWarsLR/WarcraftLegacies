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
    public sealed class BuildNeutral : Ability
    {
        public BuildNeutral(): base(1969376833)
        {
        }

        public BuildNeutral(int newId): base(1969376833, newId)
        {
        }

        public BuildNeutral(string newRawcode): base(1969376833, newRawcode)
        {
        }

        public BuildNeutral(ObjectDatabaseBase db): base(1969376833, db)
        {
        }

        public BuildNeutral(int newId, ObjectDatabaseBase db): base(1969376833, newId, db)
        {
        }

        public BuildNeutral(string newRawcode, ObjectDatabaseBase db): base(1969376833, newRawcode, db)
        {
        }
    }
}