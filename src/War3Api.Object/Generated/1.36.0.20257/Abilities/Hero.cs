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
    public sealed class Hero : Ability
    {
        public Hero(): base(1919240257)
        {
        }

        public Hero(int newId): base(1919240257, newId)
        {
        }

        public Hero(string newRawcode): base(1919240257, newRawcode)
        {
        }

        public Hero(ObjectDatabaseBase db): base(1919240257, db)
        {
        }

        public Hero(int newId, ObjectDatabaseBase db): base(1919240257, newId, db)
        {
        }

        public Hero(string newRawcode, ObjectDatabaseBase db): base(1919240257, newRawcode, db)
        {
        }
    }
}