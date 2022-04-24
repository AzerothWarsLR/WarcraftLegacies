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
    public sealed class RainOfChaosButton02 : Ability
    {
        public RainOfChaosButton02(): base(863129153)
        {
        }

        public RainOfChaosButton02(int newId): base(863129153, newId)
        {
        }

        public RainOfChaosButton02(string newRawcode): base(863129153, newRawcode)
        {
        }

        public RainOfChaosButton02(ObjectDatabaseBase db): base(863129153, db)
        {
        }

        public RainOfChaosButton02(int newId, ObjectDatabaseBase db): base(863129153, newId, db)
        {
        }

        public RainOfChaosButton02(string newRawcode, ObjectDatabaseBase db): base(863129153, newRawcode, db)
        {
        }
    }
}