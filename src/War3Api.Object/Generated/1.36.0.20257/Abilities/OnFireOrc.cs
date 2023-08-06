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
    public sealed class OnFireOrc : Ability
    {
        public OnFireOrc(): base(1869178433)
        {
        }

        public OnFireOrc(int newId): base(1869178433, newId)
        {
        }

        public OnFireOrc(string newRawcode): base(1869178433, newRawcode)
        {
        }

        public OnFireOrc(ObjectDatabaseBase db): base(1869178433, db)
        {
        }

        public OnFireOrc(int newId, ObjectDatabaseBase db): base(1869178433, newId, db)
        {
        }

        public OnFireOrc(string newRawcode, ObjectDatabaseBase db): base(1869178433, newRawcode, db)
        {
        }
    }
}