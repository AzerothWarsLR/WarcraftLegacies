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
    public sealed class UnholyFrenzyItem : Ability
    {
        public UnholyFrenzyItem(): base(1718962497)
        {
        }

        public UnholyFrenzyItem(int newId): base(1718962497, newId)
        {
        }

        public UnholyFrenzyItem(string newRawcode): base(1718962497, newRawcode)
        {
        }

        public UnholyFrenzyItem(ObjectDatabaseBase db): base(1718962497, db)
        {
        }

        public UnholyFrenzyItem(int newId, ObjectDatabaseBase db): base(1718962497, newId, db)
        {
        }

        public UnholyFrenzyItem(string newRawcode, ObjectDatabaseBase db): base(1718962497, newRawcode, db)
        {
        }
    }
}