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

        public PassiveUndeadSkeletalMasteryRusm(ObjectDatabaseBase db): base(1836283201, db)
        {
        }

        public PassiveUndeadSkeletalMasteryRusm(int newId, ObjectDatabaseBase db): base(1836283201, newId, db)
        {
        }

        public PassiveUndeadSkeletalMasteryRusm(string newRawcode, ObjectDatabaseBase db): base(1836283201, newRawcode, db)
        {
        }
    }
}