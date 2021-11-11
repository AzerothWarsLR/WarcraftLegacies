using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class CreepSleep : Ability
    {
        public CreepSleep(): base(1886602049)
        {
        }

        public CreepSleep(int newId): base(1886602049, newId)
        {
        }

        public CreepSleep(string newRawcode): base(1886602049, newRawcode)
        {
        }

        public CreepSleep(ObjectDatabase db): base(1886602049, db)
        {
        }

        public CreepSleep(int newId, ObjectDatabase db): base(1886602049, newId, db)
        {
        }

        public CreepSleep(string newRawcode, ObjectDatabase db): base(1886602049, newRawcode, db)
        {
        }
    }
}