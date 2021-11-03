using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class BurrowBarbedArachnathid : Ability
    {
        public BurrowBarbedArachnathid(): base(896885313)
        {
        }

        public BurrowBarbedArachnathid(int newId): base(896885313, newId)
        {
        }

        public BurrowBarbedArachnathid(string newRawcode): base(896885313, newRawcode)
        {
        }

        public BurrowBarbedArachnathid(ObjectDatabase db): base(896885313, db)
        {
        }

        public BurrowBarbedArachnathid(int newId, ObjectDatabase db): base(896885313, newId, db)
        {
        }

        public BurrowBarbedArachnathid(string newRawcode, ObjectDatabase db): base(896885313, newRawcode, db)
        {
        }
    }
}