using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class CrushingWaveDragonTurtle : Ability
    {
        public CrushingWaveDragonTurtle(): base(845366081)
        {
        }

        public CrushingWaveDragonTurtle(int newId): base(845366081, newId)
        {
        }

        public CrushingWaveDragonTurtle(string newRawcode): base(845366081, newRawcode)
        {
        }

        public CrushingWaveDragonTurtle(ObjectDatabase db): base(845366081, db)
        {
        }

        public CrushingWaveDragonTurtle(int newId, ObjectDatabase db): base(845366081, newId, db)
        {
        }

        public CrushingWaveDragonTurtle(string newRawcode, ObjectDatabase db): base(845366081, newRawcode, db)
        {
        }
    }
}