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
    public sealed class DropPilot : Ability
    {
        public DropPilot(): base(1885631553)
        {
        }

        public DropPilot(int newId): base(1885631553, newId)
        {
        }

        public DropPilot(string newRawcode): base(1885631553, newRawcode)
        {
        }

        public DropPilot(ObjectDatabaseBase db): base(1885631553, db)
        {
        }

        public DropPilot(int newId, ObjectDatabaseBase db): base(1885631553, newId, db)
        {
        }

        public DropPilot(string newRawcode, ObjectDatabaseBase db): base(1885631553, newRawcode, db)
        {
        }
    }
}