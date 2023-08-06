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
    public sealed class PassiveHumanAnimalBreedingRhan : Ability
    {
        public PassiveHumanAnimalBreedingRhan(): base(1851877441)
        {
        }

        public PassiveHumanAnimalBreedingRhan(int newId): base(1851877441, newId)
        {
        }

        public PassiveHumanAnimalBreedingRhan(string newRawcode): base(1851877441, newRawcode)
        {
        }

        public PassiveHumanAnimalBreedingRhan(ObjectDatabaseBase db): base(1851877441, db)
        {
        }

        public PassiveHumanAnimalBreedingRhan(int newId, ObjectDatabaseBase db): base(1851877441, newId, db)
        {
        }

        public PassiveHumanAnimalBreedingRhan(string newRawcode, ObjectDatabaseBase db): base(1851877441, newRawcode, db)
        {
        }
    }
}