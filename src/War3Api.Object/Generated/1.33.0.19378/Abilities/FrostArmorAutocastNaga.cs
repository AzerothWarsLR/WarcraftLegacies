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
    public sealed class FrostArmorAutocastNaga : Ability
    {
        public FrostArmorAutocastNaga(): base(1969636161)
        {
        }

        public FrostArmorAutocastNaga(int newId): base(1969636161, newId)
        {
        }

        public FrostArmorAutocastNaga(string newRawcode): base(1969636161, newRawcode)
        {
        }

        public FrostArmorAutocastNaga(ObjectDatabaseBase db): base(1969636161, db)
        {
        }

        public FrostArmorAutocastNaga(int newId, ObjectDatabaseBase db): base(1969636161, newId, db)
        {
        }

        public FrostArmorAutocastNaga(string newRawcode, ObjectDatabaseBase db): base(1969636161, newRawcode, db)
        {
        }
    }
}