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
    public sealed class FingerOfDeathItem : Ability
    {
        public FingerOfDeathItem(): base(2053523777)
        {
        }

        public FingerOfDeathItem(int newId): base(2053523777, newId)
        {
        }

        public FingerOfDeathItem(string newRawcode): base(2053523777, newRawcode)
        {
        }

        public FingerOfDeathItem(ObjectDatabaseBase db): base(2053523777, db)
        {
        }

        public FingerOfDeathItem(int newId, ObjectDatabaseBase db): base(2053523777, newId, db)
        {
        }

        public FingerOfDeathItem(string newRawcode, ObjectDatabaseBase db): base(2053523777, newRawcode, db)
        {
        }
    }
}