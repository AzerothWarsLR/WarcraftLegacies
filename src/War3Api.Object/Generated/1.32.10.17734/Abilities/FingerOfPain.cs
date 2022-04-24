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
    public sealed class FingerOfPain : Ability
    {
        public FingerOfPain(): base(1684423489)
        {
        }

        public FingerOfPain(int newId): base(1684423489, newId)
        {
        }

        public FingerOfPain(string newRawcode): base(1684423489, newRawcode)
        {
        }

        public FingerOfPain(ObjectDatabaseBase db): base(1684423489, db)
        {
        }

        public FingerOfPain(int newId, ObjectDatabaseBase db): base(1684423489, newId, db)
        {
        }

        public FingerOfPain(string newRawcode, ObjectDatabaseBase db): base(1684423489, newRawcode, db)
        {
        }
    }
}