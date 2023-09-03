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
    public sealed class ChenBreathOfFire : Ability
    {
        public ChenBreathOfFire(): base(1717784129)
        {
        }

        public ChenBreathOfFire(int newId): base(1717784129, newId)
        {
        }

        public ChenBreathOfFire(string newRawcode): base(1717784129, newRawcode)
        {
        }

        public ChenBreathOfFire(ObjectDatabaseBase db): base(1717784129, db)
        {
        }

        public ChenBreathOfFire(int newId, ObjectDatabaseBase db): base(1717784129, newId, db)
        {
        }

        public ChenBreathOfFire(string newRawcode, ObjectDatabaseBase db): base(1717784129, newRawcode, db)
        {
        }
    }
}