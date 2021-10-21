using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ForkedLightningCreep : Ability
    {
        public ForkedLightningCreep(): base(1818641217)
        {
        }

        public ForkedLightningCreep(int newId): base(1818641217, newId)
        {
        }

        public ForkedLightningCreep(string newRawcode): base(1818641217, newRawcode)
        {
        }

        public ForkedLightningCreep(ObjectDatabase db): base(1818641217, db)
        {
        }

        public ForkedLightningCreep(int newId, ObjectDatabase db): base(1818641217, newId, db)
        {
        }

        public ForkedLightningCreep(string newRawcode, ObjectDatabase db): base(1818641217, newRawcode, db)
        {
        }
    }
}