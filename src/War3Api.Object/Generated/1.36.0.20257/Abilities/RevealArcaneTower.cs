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
    public sealed class RevealArcaneTower : Ability
    {
        public RevealArcaneTower(): base(1635010625)
        {
        }

        public RevealArcaneTower(int newId): base(1635010625, newId)
        {
        }

        public RevealArcaneTower(string newRawcode): base(1635010625, newRawcode)
        {
        }

        public RevealArcaneTower(ObjectDatabaseBase db): base(1635010625, db)
        {
        }

        public RevealArcaneTower(int newId, ObjectDatabaseBase db): base(1635010625, newId, db)
        {
        }

        public RevealArcaneTower(string newRawcode, ObjectDatabaseBase db): base(1635010625, newRawcode, db)
        {
        }
    }
}