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
    public sealed class OnFireUndead : Ability
    {
        public OnFireUndead(): base(1969841729)
        {
        }

        public OnFireUndead(int newId): base(1969841729, newId)
        {
        }

        public OnFireUndead(string newRawcode): base(1969841729, newRawcode)
        {
        }

        public OnFireUndead(ObjectDatabaseBase db): base(1969841729, db)
        {
        }

        public OnFireUndead(int newId, ObjectDatabaseBase db): base(1969841729, newId, db)
        {
        }

        public OnFireUndead(string newRawcode, ObjectDatabaseBase db): base(1969841729, newRawcode, db)
        {
        }
    }
}