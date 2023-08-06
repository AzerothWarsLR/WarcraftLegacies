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
    public sealed class MaxManaBonusLeastest : Ability
    {
        public MaxManaBonusLeastest(): base(2053982529)
        {
        }

        public MaxManaBonusLeastest(int newId): base(2053982529, newId)
        {
        }

        public MaxManaBonusLeastest(string newRawcode): base(2053982529, newRawcode)
        {
        }

        public MaxManaBonusLeastest(ObjectDatabaseBase db): base(2053982529, db)
        {
        }

        public MaxManaBonusLeastest(int newId, ObjectDatabaseBase db): base(2053982529, newId, db)
        {
        }

        public MaxManaBonusLeastest(string newRawcode, ObjectDatabaseBase db): base(2053982529, newRawcode, db)
        {
        }
    }
}