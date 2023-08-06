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
    public sealed class PurgeTotemSP : Ability
    {
        public PurgeTotemSP(): base(1936738625)
        {
        }

        public PurgeTotemSP(int newId): base(1936738625, newId)
        {
        }

        public PurgeTotemSP(string newRawcode): base(1936738625, newRawcode)
        {
        }

        public PurgeTotemSP(ObjectDatabaseBase db): base(1936738625, db)
        {
        }

        public PurgeTotemSP(int newId, ObjectDatabaseBase db): base(1936738625, newId, db)
        {
        }

        public PurgeTotemSP(string newRawcode, ObjectDatabaseBase db): base(1936738625, newRawcode, db)
        {
        }
    }
}