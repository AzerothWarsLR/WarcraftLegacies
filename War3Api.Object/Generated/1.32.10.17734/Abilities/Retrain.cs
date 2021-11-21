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
    public sealed class Retrain : Ability
    {
        public Retrain(): base(1952805441)
        {
        }

        public Retrain(int newId): base(1952805441, newId)
        {
        }

        public Retrain(string newRawcode): base(1952805441, newRawcode)
        {
        }

        public Retrain(ObjectDatabaseBase db): base(1952805441, db)
        {
        }

        public Retrain(int newId, ObjectDatabaseBase db): base(1952805441, newId, db)
        {
        }

        public Retrain(string newRawcode, ObjectDatabaseBase db): base(1952805441, newRawcode, db)
        {
        }
    }
}