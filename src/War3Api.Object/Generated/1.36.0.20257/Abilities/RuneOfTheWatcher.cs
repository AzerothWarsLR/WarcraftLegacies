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
    public sealed class RuneOfTheWatcher : Ability
    {
        public RuneOfTheWatcher(): base(1953976385)
        {
        }

        public RuneOfTheWatcher(int newId): base(1953976385, newId)
        {
        }

        public RuneOfTheWatcher(string newRawcode): base(1953976385, newRawcode)
        {
        }

        public RuneOfTheWatcher(ObjectDatabaseBase db): base(1953976385, db)
        {
        }

        public RuneOfTheWatcher(int newId, ObjectDatabaseBase db): base(1953976385, newId, db)
        {
        }

        public RuneOfTheWatcher(string newRawcode, ObjectDatabaseBase db): base(1953976385, newRawcode, db)
        {
        }
    }
}