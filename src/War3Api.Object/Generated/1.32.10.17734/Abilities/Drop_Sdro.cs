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
    public sealed class Drop_Sdro : Ability
    {
        public Drop_Sdro(): base(1869767763)
        {
        }

        public Drop_Sdro(int newId): base(1869767763, newId)
        {
        }

        public Drop_Sdro(string newRawcode): base(1869767763, newRawcode)
        {
        }

        public Drop_Sdro(ObjectDatabaseBase db): base(1869767763, db)
        {
        }

        public Drop_Sdro(int newId, ObjectDatabaseBase db): base(1869767763, newId, db)
        {
        }

        public Drop_Sdro(string newRawcode, ObjectDatabaseBase db): base(1869767763, newRawcode, db)
        {
        }
    }
}