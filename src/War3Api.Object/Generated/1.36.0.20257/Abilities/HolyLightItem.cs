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
    public sealed class HolyLightItem : Ability
    {
        public HolyLightItem(): base(1818773825)
        {
        }

        public HolyLightItem(int newId): base(1818773825, newId)
        {
        }

        public HolyLightItem(string newRawcode): base(1818773825, newRawcode)
        {
        }

        public HolyLightItem(ObjectDatabaseBase db): base(1818773825, db)
        {
        }

        public HolyLightItem(int newId, ObjectDatabaseBase db): base(1818773825, newId, db)
        {
        }

        public HolyLightItem(string newRawcode, ObjectDatabaseBase db): base(1818773825, newRawcode, db)
        {
        }
    }
}