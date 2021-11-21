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
    public sealed class AbolishMagicCreep12Pos : Ability
    {
        public AbolishMagicCreep12Pos(): base(845431617)
        {
        }

        public AbolishMagicCreep12Pos(int newId): base(845431617, newId)
        {
        }

        public AbolishMagicCreep12Pos(string newRawcode): base(845431617, newRawcode)
        {
        }

        public AbolishMagicCreep12Pos(ObjectDatabaseBase db): base(845431617, db)
        {
        }

        public AbolishMagicCreep12Pos(int newId, ObjectDatabaseBase db): base(845431617, newId, db)
        {
        }

        public AbolishMagicCreep12Pos(string newRawcode, ObjectDatabaseBase db): base(845431617, newRawcode, db)
        {
        }
    }
}