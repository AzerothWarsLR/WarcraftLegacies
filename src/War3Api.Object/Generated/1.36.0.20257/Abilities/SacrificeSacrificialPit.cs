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
    public sealed class SacrificeSacrificialPit : Ability
    {
        public SacrificeSacrificialPit(): base(1667330881)
        {
        }

        public SacrificeSacrificialPit(int newId): base(1667330881, newId)
        {
        }

        public SacrificeSacrificialPit(string newRawcode): base(1667330881, newRawcode)
        {
        }

        public SacrificeSacrificialPit(ObjectDatabaseBase db): base(1667330881, db)
        {
        }

        public SacrificeSacrificialPit(int newId, ObjectDatabaseBase db): base(1667330881, newId, db)
        {
        }

        public SacrificeSacrificialPit(string newRawcode, ObjectDatabaseBase db): base(1667330881, newRawcode, db)
        {
        }
    }
}