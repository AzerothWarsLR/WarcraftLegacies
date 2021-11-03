using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class GarithosShockWave : Ability
    {
        public GarithosShockWave(): base(1752387137)
        {
        }

        public GarithosShockWave(int newId): base(1752387137, newId)
        {
        }

        public GarithosShockWave(string newRawcode): base(1752387137, newRawcode)
        {
        }

        public GarithosShockWave(ObjectDatabase db): base(1752387137, db)
        {
        }

        public GarithosShockWave(int newId, ObjectDatabase db): base(1752387137, newId, db)
        {
        }

        public GarithosShockWave(string newRawcode, ObjectDatabase db): base(1752387137, newRawcode, db)
        {
        }
    }
}