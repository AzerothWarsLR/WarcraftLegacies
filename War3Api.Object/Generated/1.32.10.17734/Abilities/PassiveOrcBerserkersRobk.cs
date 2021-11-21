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
    public sealed class PassiveOrcBerserkersRobk : Ability
    {
        public PassiveOrcBerserkersRobk(): base(1801613121)
        {
        }

        public PassiveOrcBerserkersRobk(int newId): base(1801613121, newId)
        {
        }

        public PassiveOrcBerserkersRobk(string newRawcode): base(1801613121, newRawcode)
        {
        }

        public PassiveOrcBerserkersRobk(ObjectDatabaseBase db): base(1801613121, db)
        {
        }

        public PassiveOrcBerserkersRobk(int newId, ObjectDatabaseBase db): base(1801613121, newId, db)
        {
        }

        public PassiveOrcBerserkersRobk(string newRawcode, ObjectDatabaseBase db): base(1801613121, newRawcode, db)
        {
        }
    }
}