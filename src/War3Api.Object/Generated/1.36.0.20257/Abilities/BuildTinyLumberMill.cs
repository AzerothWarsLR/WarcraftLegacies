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
    public sealed class BuildTinyLumberMill : Ability
    {
        public BuildTinyLumberMill(): base(1919043905)
        {
        }

        public BuildTinyLumberMill(int newId): base(1919043905, newId)
        {
        }

        public BuildTinyLumberMill(string newRawcode): base(1919043905, newRawcode)
        {
        }

        public BuildTinyLumberMill(ObjectDatabaseBase db): base(1919043905, db)
        {
        }

        public BuildTinyLumberMill(int newId, ObjectDatabaseBase db): base(1919043905, newId, db)
        {
        }

        public BuildTinyLumberMill(string newRawcode, ObjectDatabaseBase db): base(1919043905, newRawcode, db)
        {
        }
    }
}