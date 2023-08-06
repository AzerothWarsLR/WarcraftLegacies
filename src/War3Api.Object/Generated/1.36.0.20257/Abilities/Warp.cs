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
    public sealed class Warp : Ability
    {
        private readonly Lazy<ObjectProperty<float>> _dataTeleportAreaWidth;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataTeleportAreaWidthModified;
        private readonly Lazy<ObjectProperty<float>> _dataTeleportAreaHeight;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isDataTeleportAreaHeightModified;
        public Warp(): base(1886549825)
        {
            _dataTeleportAreaWidth = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTeleportAreaWidth, SetDataTeleportAreaWidth));
            _isDataTeleportAreaWidthModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTeleportAreaWidthModified));
            _dataTeleportAreaHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTeleportAreaHeight, SetDataTeleportAreaHeight));
            _isDataTeleportAreaHeightModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTeleportAreaHeightModified));
        }

        public Warp(int newId): base(1886549825, newId)
        {
            _dataTeleportAreaWidth = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTeleportAreaWidth, SetDataTeleportAreaWidth));
            _isDataTeleportAreaWidthModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTeleportAreaWidthModified));
            _dataTeleportAreaHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTeleportAreaHeight, SetDataTeleportAreaHeight));
            _isDataTeleportAreaHeightModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTeleportAreaHeightModified));
        }

        public Warp(string newRawcode): base(1886549825, newRawcode)
        {
            _dataTeleportAreaWidth = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTeleportAreaWidth, SetDataTeleportAreaWidth));
            _isDataTeleportAreaWidthModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTeleportAreaWidthModified));
            _dataTeleportAreaHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTeleportAreaHeight, SetDataTeleportAreaHeight));
            _isDataTeleportAreaHeightModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTeleportAreaHeightModified));
        }

        public Warp(ObjectDatabaseBase db): base(1886549825, db)
        {
            _dataTeleportAreaWidth = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTeleportAreaWidth, SetDataTeleportAreaWidth));
            _isDataTeleportAreaWidthModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTeleportAreaWidthModified));
            _dataTeleportAreaHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTeleportAreaHeight, SetDataTeleportAreaHeight));
            _isDataTeleportAreaHeightModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTeleportAreaHeightModified));
        }

        public Warp(int newId, ObjectDatabaseBase db): base(1886549825, newId, db)
        {
            _dataTeleportAreaWidth = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTeleportAreaWidth, SetDataTeleportAreaWidth));
            _isDataTeleportAreaWidthModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTeleportAreaWidthModified));
            _dataTeleportAreaHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTeleportAreaHeight, SetDataTeleportAreaHeight));
            _isDataTeleportAreaHeightModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTeleportAreaHeightModified));
        }

        public Warp(string newRawcode, ObjectDatabaseBase db): base(1886549825, newRawcode, db)
        {
            _dataTeleportAreaWidth = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTeleportAreaWidth, SetDataTeleportAreaWidth));
            _isDataTeleportAreaWidthModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTeleportAreaWidthModified));
            _dataTeleportAreaHeight = new Lazy<ObjectProperty<float>>(() => new ObjectProperty<float>(GetDataTeleportAreaHeight, SetDataTeleportAreaHeight));
            _isDataTeleportAreaHeightModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsDataTeleportAreaHeightModified));
        }

        public ObjectProperty<float> DataTeleportAreaWidth => _dataTeleportAreaWidth.Value;
        public ReadOnlyObjectProperty<bool> IsDataTeleportAreaWidthModified => _isDataTeleportAreaWidthModified.Value;
        public ObjectProperty<float> DataTeleportAreaHeight => _dataTeleportAreaHeight.Value;
        public ReadOnlyObjectProperty<bool> IsDataTeleportAreaHeightModified => _isDataTeleportAreaHeightModified.Value;
        private float GetDataTeleportAreaWidth(int level)
        {
            return _modifications.GetModification(829452887, level).ValueAsFloat;
        }

        private void SetDataTeleportAreaWidth(int level, float value)
        {
            _modifications[829452887, level] = new LevelObjectDataModification{Id = 829452887, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 1};
        }

        private bool GetIsDataTeleportAreaWidthModified(int level)
        {
            return _modifications.ContainsKey(829452887, level);
        }

        private float GetDataTeleportAreaHeight(int level)
        {
            return _modifications.GetModification(846230103, level).ValueAsFloat;
        }

        private void SetDataTeleportAreaHeight(int level, float value)
        {
            _modifications[846230103, level] = new LevelObjectDataModification{Id = 846230103, Type = ObjectDataType.Unreal, Value = value, Level = level, Pointer = 2};
        }

        private bool GetIsDataTeleportAreaHeightModified(int level)
        {
            return _modifications.ContainsKey(846230103, level);
        }
    }
}