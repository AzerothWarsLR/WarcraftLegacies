using System;
using System.Collections.Generic;
using System.Linq;
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

        public PassiveOrcSpikedBarricadeRosp(ObjectDatabase db): base(1886613313, db)
        {
        }

        public PassiveOrcSpikedBarricadeRosp(int newId, ObjectDatabase db): base(1886613313, newId, db)
        {
        }

        public PassiveOrcSpikedBarricadeRosp(string newRawcode, ObjectDatabase db): base(1886613313, newRawcode, db)
        {
        }
    }
}