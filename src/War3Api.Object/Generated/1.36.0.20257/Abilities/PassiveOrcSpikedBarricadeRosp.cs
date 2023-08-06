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
    public sealed class PassiveOrcSpikedBarricadeRosp : Ability
    {
        public PassiveOrcSpikedBarricadeRosp(): base(1886613313)
        {
        }

        public PassiveOrcSpikedBarricadeRosp(int newId): base(1886613313, newId)
        {
        }

        public PassiveOrcSpikedBarricadeRosp(string newRawcode): base(1886613313, newRawcode)
        {
        }

        public PassiveOrcSpikedBarricadeRosp(ObjectDatabaseBase db): base(1886613313, db)
        {
        }

        public PassiveOrcSpikedBarricadeRosp(int newId, ObjectDatabaseBase db): base(1886613313, newId, db)
        {
        }

        public PassiveOrcSpikedBarricadeRosp(string newRawcode, ObjectDatabaseBase db): base(1886613313, newRawcode, db)
        {
        }
    }
}