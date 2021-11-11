using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class FlagOrcBattleStandard : Ability
    {
        public FlagOrcBattleStandard(): base(2019969345)
        {
        }

        public FlagOrcBattleStandard(int newId): base(2019969345, newId)
        {
        }

        public FlagOrcBattleStandard(string newRawcode): base(2019969345, newRawcode)
        {
        }

        public FlagOrcBattleStandard(ObjectDatabase db): base(2019969345, db)
        {
        }

        public FlagOrcBattleStandard(int newId, ObjectDatabase db): base(2019969345, newId, db)
        {
        }

        public FlagOrcBattleStandard(string newRawcode, ObjectDatabase db): base(2019969345, newRawcode, db)
        {
        }
    }
}