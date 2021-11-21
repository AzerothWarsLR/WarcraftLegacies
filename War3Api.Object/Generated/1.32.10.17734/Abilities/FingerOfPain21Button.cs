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
    public sealed class FingerOfPain21Button : Ability
    {
        public FingerOfPain21Button(): base(862339905)
        {
        }

        public FingerOfPain21Button(int newId): base(862339905, newId)
        {
        }

        public FingerOfPain21Button(string newRawcode): base(862339905, newRawcode)
        {
        }

        public FingerOfPain21Button(ObjectDatabaseBase db): base(862339905, db)
        {
        }

        public FingerOfPain21Button(int newId, ObjectDatabaseBase db): base(862339905, newId, db)
        {
        }

        public FingerOfPain21Button(string newRawcode, ObjectDatabaseBase db): base(862339905, newRawcode, db)
        {
        }
    }
}