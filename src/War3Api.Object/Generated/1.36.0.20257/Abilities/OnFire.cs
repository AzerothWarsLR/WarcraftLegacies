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
    public sealed class OnFire : Ability
    {
        public OnFire(): base(1919510081)
        {
        }

        public OnFire(int newId): base(1919510081, newId)
        {
        }

        public OnFire(string newRawcode): base(1919510081, newRawcode)
        {
        }

        public OnFire(ObjectDatabaseBase db): base(1919510081, db)
        {
        }

        public OnFire(int newId, ObjectDatabaseBase db): base(1919510081, newId, db)
        {
        }

        public OnFire(string newRawcode, ObjectDatabaseBase db): base(1919510081, newRawcode, db)
        {
        }
    }
}