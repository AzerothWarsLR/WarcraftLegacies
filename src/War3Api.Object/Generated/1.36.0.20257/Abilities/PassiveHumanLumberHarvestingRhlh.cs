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
    public sealed class PassiveHumanLumberHarvestingRhlh : Ability
    {
        public PassiveHumanLumberHarvestingRhlh(): base(1751935041)
        {
        }

        public PassiveHumanLumberHarvestingRhlh(int newId): base(1751935041, newId)
        {
        }

        public PassiveHumanLumberHarvestingRhlh(string newRawcode): base(1751935041, newRawcode)
        {
        }

        public PassiveHumanLumberHarvestingRhlh(ObjectDatabaseBase db): base(1751935041, db)
        {
        }

        public PassiveHumanLumberHarvestingRhlh(int newId, ObjectDatabaseBase db): base(1751935041, newId, db)
        {
        }

        public PassiveHumanLumberHarvestingRhlh(string newRawcode, ObjectDatabaseBase db): base(1751935041, newRawcode, db)
        {
        }
    }
}