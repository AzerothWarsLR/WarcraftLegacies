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
    public sealed class Ethereal : Ability
    {
        public Ethereal(): base(1819567425)
        {
        }

        public Ethereal(int newId): base(1819567425, newId)
        {
        }

        public Ethereal(string newRawcode): base(1819567425, newRawcode)
        {
        }

        public Ethereal(ObjectDatabaseBase db): base(1819567425, db)
        {
        }

        public Ethereal(int newId, ObjectDatabaseBase db): base(1819567425, newId, db)
        {
        }

        public Ethereal(string newRawcode, ObjectDatabaseBase db): base(1819567425, newRawcode, db)
        {
        }
    }
}