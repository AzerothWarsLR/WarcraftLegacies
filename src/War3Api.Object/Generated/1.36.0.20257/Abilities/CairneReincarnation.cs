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
    public sealed class CairneReincarnation : Ability
    {
        public CairneReincarnation(): base(863129409)
        {
        }

        public CairneReincarnation(int newId): base(863129409, newId)
        {
        }

        public CairneReincarnation(string newRawcode): base(863129409, newRawcode)
        {
        }

        public CairneReincarnation(ObjectDatabaseBase db): base(863129409, db)
        {
        }

        public CairneReincarnation(int newId, ObjectDatabaseBase db): base(863129409, newId, db)
        {
        }

        public CairneReincarnation(string newRawcode, ObjectDatabaseBase db): base(863129409, newRawcode, db)
        {
        }
    }
}