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
    public sealed class ReassignableAttributeBonus1 : Ability
    {
        public ReassignableAttributeBonus1(): base(1836468545)
        {
        }

        public ReassignableAttributeBonus1(int newId): base(1836468545, newId)
        {
        }

        public ReassignableAttributeBonus1(string newRawcode): base(1836468545, newRawcode)
        {
        }

        public ReassignableAttributeBonus1(ObjectDatabaseBase db): base(1836468545, db)
        {
        }

        public ReassignableAttributeBonus1(int newId, ObjectDatabaseBase db): base(1836468545, newId, db)
        {
        }

        public ReassignableAttributeBonus1(string newRawcode, ObjectDatabaseBase db): base(1836468545, newRawcode, db)
        {
        }
    }
}