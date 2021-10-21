using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class FreezingBreath : Ability
    {
        public FreezingBreath(): base(2054317633)
        {
        }

        public FreezingBreath(int newId): base(2054317633, newId)
        {
        }

        public FreezingBreath(string newRawcode): base(2054317633, newRawcode)
        {
        }

        public FreezingBreath(ObjectDatabase db): base(2054317633, db)
        {
        }

        public FreezingBreath(int newId, ObjectDatabase db): base(2054317633, newId, db)
        {
        }

        public FreezingBreath(string newRawcode, ObjectDatabase db): base(2054317633, newRawcode, db)
        {
        }
    }
}