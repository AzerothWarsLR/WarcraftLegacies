using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class CrushingWaveLesser : Ability
    {
        public CrushingWaveLesser(): base(862143297)
        {
        }

        public CrushingWaveLesser(int newId): base(862143297, newId)
        {
        }

        public CrushingWaveLesser(string newRawcode): base(862143297, newRawcode)
        {
        }

        public CrushingWaveLesser(ObjectDatabase db): base(862143297, db)
        {
        }

        public CrushingWaveLesser(int newId, ObjectDatabase db): base(862143297, newId, db)
        {
        }

        public CrushingWaveLesser(string newRawcode, ObjectDatabase db): base(862143297, newRawcode, db)
        {
        }
    }
}