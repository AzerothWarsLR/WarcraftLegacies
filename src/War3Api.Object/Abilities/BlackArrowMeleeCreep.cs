using System;
using System.Collections.Generic;
using System.Linq;
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

        public BlackArrowMeleeCreep(ObjectDatabase db): base(1801601857, db)
        {
        }

        public BlackArrowMeleeCreep(int newId, ObjectDatabase db): base(1801601857, newId, db)
        {
        }

        public BlackArrowMeleeCreep(string newRawcode, ObjectDatabase db): base(1801601857, newRawcode, db)
        {
        }
    }
}