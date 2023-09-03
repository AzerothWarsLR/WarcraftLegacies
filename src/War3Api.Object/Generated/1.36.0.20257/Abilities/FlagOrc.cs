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
    public sealed class FlagOrc : Ability
    {
        public FlagOrc(): base(1868974401)
        {
        }

        public FlagOrc(int newId): base(1868974401, newId)
        {
        }

        public FlagOrc(string newRawcode): base(1868974401, newRawcode)
        {
        }

        public FlagOrc(ObjectDatabaseBase db): base(1868974401, db)
        {
        }

        public FlagOrc(int newId, ObjectDatabaseBase db): base(1868974401, newId, db)
        {
        }

        public FlagOrc(string newRawcode, ObjectDatabaseBase db): base(1868974401, newRawcode, db)
        {
        }
    }
}