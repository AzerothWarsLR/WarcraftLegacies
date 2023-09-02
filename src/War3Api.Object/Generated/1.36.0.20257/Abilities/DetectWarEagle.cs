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
    public sealed class DetectWarEagle : Ability
    {
        public DetectWarEagle(): base(1920224833)
        {
        }

        public DetectWarEagle(int newId): base(1920224833, newId)
        {
        }

        public DetectWarEagle(string newRawcode): base(1920224833, newRawcode)
        {
        }

        public DetectWarEagle(ObjectDatabaseBase db): base(1920224833, db)
        {
        }

        public DetectWarEagle(int newId, ObjectDatabaseBase db): base(1920224833, newId, db)
        {
        }

        public DetectWarEagle(string newRawcode, ObjectDatabaseBase db): base(1920224833, newRawcode, db)
        {
        }
    }
}