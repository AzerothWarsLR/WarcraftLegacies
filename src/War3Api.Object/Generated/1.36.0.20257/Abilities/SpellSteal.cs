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
    public sealed class SpellSteal : Ability
    {
        public SpellSteal(): base(1936749377)
        {
        }

        public SpellSteal(int newId): base(1936749377, newId)
        {
        }

        public SpellSteal(string newRawcode): base(1936749377, newRawcode)
        {
        }

        public SpellSteal(ObjectDatabaseBase db): base(1936749377, db)
        {
        }

        public SpellSteal(int newId, ObjectDatabaseBase db): base(1936749377, newId, db)
        {
        }

        public SpellSteal(string newRawcode, ObjectDatabaseBase db): base(1936749377, newRawcode, db)
        {
        }
    }
}