using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class RokhanSerpentWard : Ability
    {
        public RokhanSerpentWard(): base(2004054593)
        {
        }

        public RokhanSerpentWard(int newId): base(2004054593, newId)
        {
        }

        public RokhanSerpentWard(string newRawcode): base(2004054593, newRawcode)
        {
        }

        public RokhanSerpentWard(ObjectDatabase db): base(2004054593, db)
        {
        }

        public RokhanSerpentWard(int newId, ObjectDatabase db): base(2004054593, newId, db)
        {
        }

        public RokhanSerpentWard(string newRawcode, ObjectDatabase db): base(2004054593, newRawcode, db)
        {
        }
    }
}