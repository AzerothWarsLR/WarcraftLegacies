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
    public sealed class LoadPilot : Ability
    {
        public LoadPilot(): base(1886155841)
        {
        }

        public LoadPilot(int newId): base(1886155841, newId)
        {
        }

        public LoadPilot(string newRawcode): base(1886155841, newRawcode)
        {
        }

        public LoadPilot(ObjectDatabaseBase db): base(1886155841, db)
        {
        }

        public LoadPilot(int newId, ObjectDatabaseBase db): base(1886155841, newId, db)
        {
        }

        public LoadPilot(string newRawcode, ObjectDatabaseBase db): base(1886155841, newRawcode, db)
        {
        }
    }
}