using System;
using System.Collections.Generic;
using System.Linq;
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

        public ShamanClawsLightningMelee(ObjectDatabase db): base(2020362561, db)
        {
        }

        public ShamanClawsLightningMelee(int newId, ObjectDatabase db): base(2020362561, newId, db)
        {
        }

        public ShamanClawsLightningMelee(string newRawcode, ObjectDatabase db): base(2020362561, newRawcode, db)
        {
        }
    }
}