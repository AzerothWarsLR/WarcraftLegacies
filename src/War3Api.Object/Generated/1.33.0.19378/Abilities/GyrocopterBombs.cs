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
    public sealed class GyrocopterBombs : Ability
    {
        public GyrocopterBombs(): base(1652123457)
        {
        }

        public GyrocopterBombs(int newId): base(1652123457, newId)
        {
        }

        public GyrocopterBombs(string newRawcode): base(1652123457, newRawcode)
        {
        }

        public GyrocopterBombs(ObjectDatabaseBase db): base(1652123457, db)
        {
        }

        public GyrocopterBombs(int newId, ObjectDatabaseBase db): base(1652123457, newId, db)
        {
        }

        public GyrocopterBombs(string newRawcode, ObjectDatabaseBase db): base(1652123457, newRawcode, db)
        {
        }
    }
}