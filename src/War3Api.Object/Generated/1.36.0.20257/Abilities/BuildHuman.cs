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
    public sealed class BuildHuman : Ability
    {
        public BuildHuman(): base(1969375297)
        {
        }

        public BuildHuman(int newId): base(1969375297, newId)
        {
        }

        public BuildHuman(string newRawcode): base(1969375297, newRawcode)
        {
        }

        public BuildHuman(ObjectDatabaseBase db): base(1969375297, db)
        {
        }

        public BuildHuman(int newId, ObjectDatabaseBase db): base(1969375297, newId, db)
        {
        }

        public BuildHuman(string newRawcode, ObjectDatabaseBase db): base(1969375297, newRawcode, db)
        {
        }
    }
}