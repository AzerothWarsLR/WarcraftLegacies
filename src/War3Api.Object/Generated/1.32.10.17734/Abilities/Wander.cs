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
    public sealed class Wander : Ability
    {
        public Wander(): base(1851881281)
        {
        }

        public Wander(int newId): base(1851881281, newId)
        {
        }

        public Wander(string newRawcode): base(1851881281, newRawcode)
        {
        }

        public Wander(ObjectDatabaseBase db): base(1851881281, db)
        {
        }

        public Wander(int newId, ObjectDatabaseBase db): base(1851881281, newId, db)
        {
        }

        public Wander(string newRawcode, ObjectDatabaseBase db): base(1851881281, newRawcode, db)
        {
        }
    }
}