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
    public sealed class AbolishMagicNaga : Ability
    {
        public AbolishMagicNaga(): base(1835298369)
        {
        }

        public AbolishMagicNaga(int newId): base(1835298369, newId)
        {
        }

        public AbolishMagicNaga(string newRawcode): base(1835298369, newRawcode)
        {
        }

        public AbolishMagicNaga(ObjectDatabaseBase db): base(1835298369, db)
        {
        }

        public AbolishMagicNaga(int newId, ObjectDatabaseBase db): base(1835298369, newId, db)
        {
        }

        public AbolishMagicNaga(string newRawcode, ObjectDatabaseBase db): base(1835298369, newRawcode, db)
        {
        }
    }
}