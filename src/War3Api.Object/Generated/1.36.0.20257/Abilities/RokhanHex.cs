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
    public sealed class RokhanHex : Ability
    {
        public RokhanHex(): base(2020101697)
        {
        }

        public RokhanHex(int newId): base(2020101697, newId)
        {
        }

        public RokhanHex(string newRawcode): base(2020101697, newRawcode)
        {
        }

        public RokhanHex(ObjectDatabaseBase db): base(2020101697, db)
        {
        }

        public RokhanHex(int newId, ObjectDatabaseBase db): base(2020101697, newId, db)
        {
        }

        public RokhanHex(string newRawcode, ObjectDatabaseBase db): base(2020101697, newRawcode, db)
        {
        }
    }
}