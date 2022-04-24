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
    public sealed class AgilityBonus10 : Ability
    {
        public AgilityBonus10(): base(2053196097)
        {
        }

        public AgilityBonus10(int newId): base(2053196097, newId)
        {
        }

        public AgilityBonus10(string newRawcode): base(2053196097, newRawcode)
        {
        }

        public AgilityBonus10(ObjectDatabaseBase db): base(2053196097, db)
        {
        }

        public AgilityBonus10(int newId, ObjectDatabaseBase db): base(2053196097, newId, db)
        {
        }

        public AgilityBonus10(string newRawcode, ObjectDatabaseBase db): base(2053196097, newRawcode, db)
        {
        }
    }
}