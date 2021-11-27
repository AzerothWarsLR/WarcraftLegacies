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
    public sealed class BuildOrc : Ability
    {
        public BuildOrc(): base(1969377089)
        {
        }

        public BuildOrc(int newId): base(1969377089, newId)
        {
        }

        public BuildOrc(string newRawcode): base(1969377089, newRawcode)
        {
        }

        public BuildOrc(ObjectDatabaseBase db): base(1969377089, db)
        {
        }

        public BuildOrc(int newId, ObjectDatabaseBase db): base(1969377089, newId, db)
        {
        }

        public BuildOrc(string newRawcode, ObjectDatabaseBase db): base(1969377089, newRawcode, db)
        {
        }
    }
}