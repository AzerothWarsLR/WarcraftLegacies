using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
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

        public RainOfFireCreepGreater(ObjectDatabase db): base(1735541569, db)
        {
        }

        public RainOfFireCreepGreater(int newId, ObjectDatabase db): base(1735541569, newId, db)
        {
        }

        public RainOfFireCreepGreater(string newRawcode, ObjectDatabase db): base(1735541569, newRawcode, db)
        {
        }
    }
}