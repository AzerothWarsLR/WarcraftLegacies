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
    public sealed class BuildTinyBarracks : Ability
    {
        public BuildTinyBarracks(): base(1935821121)
        {
        }

        public BuildTinyBarracks(int newId): base(1935821121, newId)
        {
        }

        public BuildTinyBarracks(string newRawcode): base(1935821121, newRawcode)
        {
        }

        public BuildTinyBarracks(ObjectDatabaseBase db): base(1935821121, db)
        {
        }

        public BuildTinyBarracks(int newId, ObjectDatabaseBase db): base(1935821121, newId, db)
        {
        }

        public BuildTinyBarracks(string newRawcode, ObjectDatabaseBase db): base(1935821121, newRawcode, db)
        {
        }
    }
}