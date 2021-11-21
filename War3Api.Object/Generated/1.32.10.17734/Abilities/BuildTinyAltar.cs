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
    public sealed class BuildTinyAltar : Ability
    {
        public BuildTinyAltar(): base(1751271745)
        {
        }

        public BuildTinyAltar(int newId): base(1751271745, newId)
        {
        }

        public BuildTinyAltar(string newRawcode): base(1751271745, newRawcode)
        {
        }

        public BuildTinyAltar(ObjectDatabaseBase db): base(1751271745, db)
        {
        }

        public BuildTinyAltar(int newId, ObjectDatabaseBase db): base(1751271745, newId, db)
        {
        }

        public BuildTinyAltar(string newRawcode, ObjectDatabaseBase db): base(1751271745, newRawcode, db)
        {
        }
    }
}