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
    public sealed class FrostBreathNewHasIcon : Ability
    {
        public FrostBreathNewHasIcon(): base(1668441665)
        {
        }

        public FrostBreathNewHasIcon(int newId): base(1668441665, newId)
        {
        }

        public FrostBreathNewHasIcon(string newRawcode): base(1668441665, newRawcode)
        {
        }

        public FrostBreathNewHasIcon(ObjectDatabaseBase db): base(1668441665, db)
        {
        }

        public FrostBreathNewHasIcon(int newId, ObjectDatabaseBase db): base(1668441665, newId, db)
        {
        }

        public FrostBreathNewHasIcon(string newRawcode, ObjectDatabaseBase db): base(1668441665, newRawcode, db)
        {
        }
    }
}