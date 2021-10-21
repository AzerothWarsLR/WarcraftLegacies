using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class SpikedBarricades : Ability
    {
        public SpikedBarricades(): base(1768977217)
        {
        }

        public SpikedBarricades(int newId): base(1768977217, newId)
        {
        }

        public SpikedBarricades(string newRawcode): base(1768977217, newRawcode)
        {
        }

        public SpikedBarricades(ObjectDatabase db): base(1768977217, db)
        {
        }

        public SpikedBarricades(int newId, ObjectDatabase db): base(1768977217, newId, db)
        {
        }

        public SpikedBarricades(string newRawcode, ObjectDatabase db): base(1768977217, newRawcode, db)
        {
        }
    }
}