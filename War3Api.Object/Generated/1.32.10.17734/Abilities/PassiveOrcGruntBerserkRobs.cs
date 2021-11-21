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
    public sealed class PassiveOrcGruntBerserkRobs : Ability
    {
        public PassiveOrcGruntBerserkRobs(): base(1935830849)
        {
        }

        public PassiveOrcGruntBerserkRobs(int newId): base(1935830849, newId)
        {
        }

        public PassiveOrcGruntBerserkRobs(string newRawcode): base(1935830849, newRawcode)
        {
        }

        public PassiveOrcGruntBerserkRobs(ObjectDatabaseBase db): base(1935830849, db)
        {
        }

        public PassiveOrcGruntBerserkRobs(int newId, ObjectDatabaseBase db): base(1935830849, newId, db)
        {
        }

        public PassiveOrcGruntBerserkRobs(string newRawcode, ObjectDatabaseBase db): base(1935830849, newRawcode, db)
        {
        }
    }
}