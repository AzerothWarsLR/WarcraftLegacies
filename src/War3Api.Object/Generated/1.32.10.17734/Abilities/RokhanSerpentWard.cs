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

        public RokhanSerpentWard(ObjectDatabaseBase db): base(2004054593, db)
        {
        }

        public RokhanSerpentWard(int newId, ObjectDatabaseBase db): base(2004054593, newId, db)
        {
        }

        public RokhanSerpentWard(string newRawcode, ObjectDatabaseBase db): base(2004054593, newRawcode, db)
        {
        }
    }
}