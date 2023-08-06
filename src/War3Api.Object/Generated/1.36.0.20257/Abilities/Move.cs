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
    public sealed class Move : Ability
    {
        public Move(): base(1987013953)
        {
        }

        public Move(int newId): base(1987013953, newId)
        {
        }

        public Move(string newRawcode): base(1987013953, newRawcode)
        {
        }

        public Move(ObjectDatabaseBase db): base(1987013953, db)
        {
        }

        public Move(int newId, ObjectDatabaseBase db): base(1987013953, newId, db)
        {
        }

        public Move(string newRawcode, ObjectDatabaseBase db): base(1987013953, newRawcode, db)
        {
        }
    }
}