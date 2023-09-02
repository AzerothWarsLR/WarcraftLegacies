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
    public sealed class ItemInvisLesser : Ability
    {
        public ItemInvisLesser(): base(829835585)
        {
        }

        public ItemInvisLesser(int newId): base(829835585, newId)
        {
        }

        public ItemInvisLesser(string newRawcode): base(829835585, newRawcode)
        {
        }

        public ItemInvisLesser(ObjectDatabaseBase db): base(829835585, db)
        {
        }

        public ItemInvisLesser(int newId, ObjectDatabaseBase db): base(829835585, newId, db)
        {
        }

        public ItemInvisLesser(string newRawcode, ObjectDatabaseBase db): base(829835585, newRawcode, db)
        {
        }
    }
}