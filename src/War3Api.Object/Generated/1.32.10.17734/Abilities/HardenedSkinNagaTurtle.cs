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
    public sealed class HardenedSkinNagaTurtle : Ability
    {
        public HardenedSkinNagaTurtle(): base(1802726977)
        {
        }

        public HardenedSkinNagaTurtle(int newId): base(1802726977, newId)
        {
        }

        public HardenedSkinNagaTurtle(string newRawcode): base(1802726977, newRawcode)
        {
        }

        public HardenedSkinNagaTurtle(ObjectDatabaseBase db): base(1802726977, db)
        {
        }

        public HardenedSkinNagaTurtle(int newId, ObjectDatabaseBase db): base(1802726977, newId, db)
        {
        }

        public HardenedSkinNagaTurtle(string newRawcode, ObjectDatabaseBase db): base(1802726977, newRawcode, db)
        {
        }
    }
}