using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class PassiveUndeadSkeletalMasteryRusm : Ability
    {
        public PassiveUndeadSkeletalMasteryRusm(): base(1836283201)
        {
        }

        public PassiveUndeadSkeletalMasteryRusm(int newId): base(1836283201, newId)
        {
        }

        public PassiveUndeadSkeletalMasteryRusm(string newRawcode): base(1836283201, newRawcode)
        {
        }

        public PassiveUndeadSkeletalMasteryRusm(ObjectDatabase db): base(1836283201, db)
        {
        }

        public PassiveUndeadSkeletalMasteryRusm(int newId, ObjectDatabase db): base(1836283201, newId, db)
        {
        }

        public PassiveUndeadSkeletalMasteryRusm(string newRawcode, ObjectDatabase db): base(1836283201, newRawcode, db)
        {
        }
    }
}