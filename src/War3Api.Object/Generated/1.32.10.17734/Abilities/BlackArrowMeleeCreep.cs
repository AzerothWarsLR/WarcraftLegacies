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
    public sealed class BlackArrowMeleeCreep : Ability
    {
        public BlackArrowMeleeCreep(): base(1801601857)
        {
        }

        public BlackArrowMeleeCreep(int newId): base(1801601857, newId)
        {
        }

        public BlackArrowMeleeCreep(string newRawcode): base(1801601857, newRawcode)
        {
        }

        public BlackArrowMeleeCreep(ObjectDatabaseBase db): base(1801601857, db)
        {
        }

        public BlackArrowMeleeCreep(int newId, ObjectDatabaseBase db): base(1801601857, newId, db)
        {
        }

        public BlackArrowMeleeCreep(string newRawcode, ObjectDatabaseBase db): base(1801601857, newRawcode, db)
        {
        }
    }
}