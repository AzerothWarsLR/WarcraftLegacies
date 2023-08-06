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
    public sealed class Flag : Ability
    {
        public Flag(): base(1818642753)
        {
        }

        public Flag(int newId): base(1818642753, newId)
        {
        }

        public Flag(string newRawcode): base(1818642753, newRawcode)
        {
        }

        public Flag(ObjectDatabaseBase db): base(1818642753, db)
        {
        }

        public Flag(int newId, ObjectDatabaseBase db): base(1818642753, newId, db)
        {
        }

        public Flag(string newRawcode, ObjectDatabaseBase db): base(1818642753, newRawcode, db)
        {
        }
    }
}