using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class SoulTrap : Ability
    {
        public SoulTrap(): base(1869826369)
        {
        }

        public SoulTrap(int newId): base(1869826369, newId)
        {
        }

        public SoulTrap(string newRawcode): base(1869826369, newRawcode)
        {
        }

        public SoulTrap(ObjectDatabase db): base(1869826369, db)
        {
        }

        public SoulTrap(int newId, ObjectDatabase db): base(1869826369, newId, db)
        {
        }

        public SoulTrap(string newRawcode, ObjectDatabase db): base(1869826369, newRawcode, db)
        {
        }
    }
}