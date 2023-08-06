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
    public sealed class Invulnerable : Ability
    {
        public Invulnerable(): base(1819637313)
        {
        }

        public Invulnerable(int newId): base(1819637313, newId)
        {
        }

        public Invulnerable(string newRawcode): base(1819637313, newRawcode)
        {
        }

        public Invulnerable(ObjectDatabaseBase db): base(1819637313, db)
        {
        }

        public Invulnerable(int newId, ObjectDatabaseBase db): base(1819637313, newId, db)
        {
        }

        public Invulnerable(string newRawcode, ObjectDatabaseBase db): base(1819637313, newRawcode, db)
        {
        }
    }
}