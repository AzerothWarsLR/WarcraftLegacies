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
    public sealed class MaxManaBonusLeastestReally : Ability
    {
        public MaxManaBonusLeastestReally(): base(1986873665)
        {
        }

        public MaxManaBonusLeastestReally(int newId): base(1986873665, newId)
        {
        }

        public MaxManaBonusLeastestReally(string newRawcode): base(1986873665, newRawcode)
        {
        }

        public MaxManaBonusLeastestReally(ObjectDatabaseBase db): base(1986873665, db)
        {
        }

        public MaxManaBonusLeastestReally(int newId, ObjectDatabaseBase db): base(1986873665, newId, db)
        {
        }

        public MaxManaBonusLeastestReally(string newRawcode, ObjectDatabaseBase db): base(1986873665, newRawcode, db)
        {
        }
    }
}