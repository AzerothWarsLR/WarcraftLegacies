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
    public sealed class PenguinSqueek : Ability
    {
        public PenguinSqueek(): base(2054179137)
        {
        }

        public PenguinSqueek(int newId): base(2054179137, newId)
        {
        }

        public PenguinSqueek(string newRawcode): base(2054179137, newRawcode)
        {
        }

        public PenguinSqueek(ObjectDatabaseBase db): base(2054179137, db)
        {
        }

        public PenguinSqueek(int newId, ObjectDatabaseBase db): base(2054179137, newId, db)
        {
        }

        public PenguinSqueek(string newRawcode, ObjectDatabaseBase db): base(2054179137, newRawcode, db)
        {
        }
    }
}