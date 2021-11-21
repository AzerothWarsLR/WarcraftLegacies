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
    public sealed class Ultravision : Ability
    {
        public Ultravision(): base(1953264961)
        {
        }

        public Ultravision(int newId): base(1953264961, newId)
        {
        }

        public Ultravision(string newRawcode): base(1953264961, newRawcode)
        {
        }

        public Ultravision(ObjectDatabaseBase db): base(1953264961, db)
        {
        }

        public Ultravision(int newId, ObjectDatabaseBase db): base(1953264961, newId, db)
        {
        }

        public Ultravision(string newRawcode, ObjectDatabaseBase db): base(1953264961, newRawcode, db)
        {
        }
    }
}