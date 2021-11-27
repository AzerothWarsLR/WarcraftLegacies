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
    public sealed class DropInstant : Ability
    {
        public DropInstant(): base(1769104449)
        {
        }

        public DropInstant(int newId): base(1769104449, newId)
        {
        }

        public DropInstant(string newRawcode): base(1769104449, newRawcode)
        {
        }

        public DropInstant(ObjectDatabaseBase db): base(1769104449, db)
        {
        }

        public DropInstant(int newId, ObjectDatabaseBase db): base(1769104449, newId, db)
        {
        }

        public DropInstant(string newRawcode, ObjectDatabaseBase db): base(1769104449, newRawcode, db)
        {
        }
    }
}