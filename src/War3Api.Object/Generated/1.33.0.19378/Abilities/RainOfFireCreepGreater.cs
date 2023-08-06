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
    public sealed class RainOfFireCreepGreater : Ability
    {
        public RainOfFireCreepGreater(): base(1735541569)
        {
        }

        public RainOfFireCreepGreater(int newId): base(1735541569, newId)
        {
        }

        public RainOfFireCreepGreater(string newRawcode): base(1735541569, newRawcode)
        {
        }

        public RainOfFireCreepGreater(ObjectDatabaseBase db): base(1735541569, db)
        {
        }

        public RainOfFireCreepGreater(int newId, ObjectDatabaseBase db): base(1735541569, newId, db)
        {
        }

        public RainOfFireCreepGreater(string newRawcode, ObjectDatabaseBase db): base(1735541569, newRawcode, db)
        {
        }
    }
}