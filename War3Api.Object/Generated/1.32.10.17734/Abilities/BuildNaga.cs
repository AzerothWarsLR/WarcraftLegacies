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
    public sealed class BuildNaga : Ability
    {
        public BuildNaga(): base(1969375041)
        {
        }

        public BuildNaga(int newId): base(1969375041, newId)
        {
        }

        public BuildNaga(string newRawcode): base(1969375041, newRawcode)
        {
        }

        public BuildNaga(ObjectDatabaseBase db): base(1969375041, db)
        {
        }

        public BuildNaga(int newId, ObjectDatabaseBase db): base(1969375041, newId, db)
        {
        }

        public BuildNaga(string newRawcode, ObjectDatabaseBase db): base(1969375041, newRawcode, db)
        {
        }
    }
}