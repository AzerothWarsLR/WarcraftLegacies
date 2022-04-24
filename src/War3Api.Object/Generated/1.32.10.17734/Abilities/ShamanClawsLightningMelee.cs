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
    public sealed class ShamanClawsLightningMelee : Ability
    {
        public ShamanClawsLightningMelee(): base(2020362561)
        {
        }

        public ShamanClawsLightningMelee(int newId): base(2020362561, newId)
        {
        }

        public ShamanClawsLightningMelee(string newRawcode): base(2020362561, newRawcode)
        {
        }

        public ShamanClawsLightningMelee(ObjectDatabaseBase db): base(2020362561, db)
        {
        }

        public ShamanClawsLightningMelee(int newId, ObjectDatabaseBase db): base(2020362561, newId, db)
        {
        }

        public ShamanClawsLightningMelee(string newRawcode, ObjectDatabaseBase db): base(2020362561, newRawcode, db)
        {
        }
    }
}