using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object
{
    public sealed class Upgrade : BaseObject
    {
        private readonly LevelObjectDataModifications _modifications;
        private readonly Lazy<ObjectProperty<string>> _textName;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isTextNameModified;
        private readonly Lazy<ObjectProperty<string>> _textEditorSuffix;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isTextEditorSuffixModified;
        private readonly Lazy<ObjectProperty<string>> _textTooltip;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isTextTooltipModified;
        private readonly Lazy<ObjectProperty<string>> _textTooltipExtended;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isTextTooltipExtendedModified;
        private readonly Lazy<ObjectProperty<string>> _textHotkeyRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isTextHotkeyModified;
        private readonly Lazy<ObjectProperty<char>> _textHotkey;
        private readonly Lazy<ObjectProperty<string>> _artIconRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isArtIconModified;
        private readonly Lazy<ObjectProperty<string>> _artIcon;
        private readonly Lazy<ObjectProperty<string>> _techtreeRequirementsRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isTechtreeRequirementsModified;
        private readonly Lazy<ObjectProperty<IEnumerable<Tech>>> _techtreeRequirements;
        private readonly Lazy<ObjectProperty<string>> _techtreeRequirementsLevelsRaw;
        private readonly Lazy<ReadOnlyObjectProperty<bool>> _isTechtreeRequirementsLevelsModified;
        private readonly Lazy<ObjectProperty<IEnumerable<int>>> _techtreeRequirementsLevels;
        public Upgrade(UpgradeType upgradeType): this((int)upgradeType)
        {
        }

        public Upgrade(UpgradeType upgradeType, int newId): this((int)upgradeType, newId)
        {
        }

        public Upgrade(UpgradeType upgradeType, string newRawcode): this((int)upgradeType, newRawcode)
        {
        }

        public Upgrade(UpgradeType upgradeType, ObjectDatabaseBase db): this((int)upgradeType, db)
        {
        }

        public Upgrade(UpgradeType upgradeType, int newId, ObjectDatabaseBase db): this((int)upgradeType, newId, db)
        {
        }

        public Upgrade(UpgradeType upgradeType, string newRawcode, ObjectDatabaseBase db): this((int)upgradeType, newRawcode, db)
        {
        }

        private Upgrade(int oldId): base(oldId)
        {
            _modifications = new(this);
            _textName = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextName, SetTextName));
            _isTextNameModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextNameModified));
            _textEditorSuffix = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextEditorSuffix, SetTextEditorSuffix));
            _isTextEditorSuffixModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextEditorSuffixModified));
            _textTooltip = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltip, SetTextTooltip));
            _isTextTooltipModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextTooltipModified));
            _textTooltipExtended = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipExtended, SetTextTooltipExtended));
            _isTextTooltipExtendedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextTooltipExtendedModified));
            _textHotkeyRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextHotkeyRaw, SetTextHotkeyRaw));
            _isTextHotkeyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextHotkeyModified));
            _textHotkey = new Lazy<ObjectProperty<char>>(() => new ObjectProperty<char>(GetTextHotkey, SetTextHotkey));
            _artIconRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetArtIconRaw, SetArtIconRaw));
            _isArtIconModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsArtIconModified));
            _artIcon = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetArtIcon, SetArtIcon));
            _techtreeRequirementsRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTechtreeRequirementsRaw, SetTechtreeRequirementsRaw));
            _isTechtreeRequirementsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTechtreeRequirementsModified));
            _techtreeRequirements = new Lazy<ObjectProperty<IEnumerable<Tech>>>(() => new ObjectProperty<IEnumerable<Tech>>(GetTechtreeRequirements, SetTechtreeRequirements));
            _techtreeRequirementsLevelsRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTechtreeRequirementsLevelsRaw, SetTechtreeRequirementsLevelsRaw));
            _isTechtreeRequirementsLevelsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTechtreeRequirementsLevelsModified));
            _techtreeRequirementsLevels = new Lazy<ObjectProperty<IEnumerable<int>>>(() => new ObjectProperty<IEnumerable<int>>(GetTechtreeRequirementsLevels, SetTechtreeRequirementsLevels));
        }

        private Upgrade(int oldId, int newId): base(oldId, newId)
        {
            _modifications = new(this);
            _textName = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextName, SetTextName));
            _isTextNameModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextNameModified));
            _textEditorSuffix = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextEditorSuffix, SetTextEditorSuffix));
            _isTextEditorSuffixModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextEditorSuffixModified));
            _textTooltip = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltip, SetTextTooltip));
            _isTextTooltipModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextTooltipModified));
            _textTooltipExtended = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipExtended, SetTextTooltipExtended));
            _isTextTooltipExtendedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextTooltipExtendedModified));
            _textHotkeyRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextHotkeyRaw, SetTextHotkeyRaw));
            _isTextHotkeyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextHotkeyModified));
            _textHotkey = new Lazy<ObjectProperty<char>>(() => new ObjectProperty<char>(GetTextHotkey, SetTextHotkey));
            _artIconRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetArtIconRaw, SetArtIconRaw));
            _isArtIconModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsArtIconModified));
            _artIcon = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetArtIcon, SetArtIcon));
            _techtreeRequirementsRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTechtreeRequirementsRaw, SetTechtreeRequirementsRaw));
            _isTechtreeRequirementsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTechtreeRequirementsModified));
            _techtreeRequirements = new Lazy<ObjectProperty<IEnumerable<Tech>>>(() => new ObjectProperty<IEnumerable<Tech>>(GetTechtreeRequirements, SetTechtreeRequirements));
            _techtreeRequirementsLevelsRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTechtreeRequirementsLevelsRaw, SetTechtreeRequirementsLevelsRaw));
            _isTechtreeRequirementsLevelsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTechtreeRequirementsLevelsModified));
            _techtreeRequirementsLevels = new Lazy<ObjectProperty<IEnumerable<int>>>(() => new ObjectProperty<IEnumerable<int>>(GetTechtreeRequirementsLevels, SetTechtreeRequirementsLevels));
        }

        private Upgrade(int oldId, string newRawcode): base(oldId, newRawcode)
        {
            _modifications = new(this);
            _textName = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextName, SetTextName));
            _isTextNameModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextNameModified));
            _textEditorSuffix = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextEditorSuffix, SetTextEditorSuffix));
            _isTextEditorSuffixModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextEditorSuffixModified));
            _textTooltip = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltip, SetTextTooltip));
            _isTextTooltipModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextTooltipModified));
            _textTooltipExtended = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipExtended, SetTextTooltipExtended));
            _isTextTooltipExtendedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextTooltipExtendedModified));
            _textHotkeyRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextHotkeyRaw, SetTextHotkeyRaw));
            _isTextHotkeyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextHotkeyModified));
            _textHotkey = new Lazy<ObjectProperty<char>>(() => new ObjectProperty<char>(GetTextHotkey, SetTextHotkey));
            _artIconRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetArtIconRaw, SetArtIconRaw));
            _isArtIconModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsArtIconModified));
            _artIcon = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetArtIcon, SetArtIcon));
            _techtreeRequirementsRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTechtreeRequirementsRaw, SetTechtreeRequirementsRaw));
            _isTechtreeRequirementsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTechtreeRequirementsModified));
            _techtreeRequirements = new Lazy<ObjectProperty<IEnumerable<Tech>>>(() => new ObjectProperty<IEnumerable<Tech>>(GetTechtreeRequirements, SetTechtreeRequirements));
            _techtreeRequirementsLevelsRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTechtreeRequirementsLevelsRaw, SetTechtreeRequirementsLevelsRaw));
            _isTechtreeRequirementsLevelsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTechtreeRequirementsLevelsModified));
            _techtreeRequirementsLevels = new Lazy<ObjectProperty<IEnumerable<int>>>(() => new ObjectProperty<IEnumerable<int>>(GetTechtreeRequirementsLevels, SetTechtreeRequirementsLevels));
        }

        private Upgrade(int oldId, ObjectDatabaseBase db): base(oldId, db)
        {
            _modifications = new(this);
            _textName = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextName, SetTextName));
            _isTextNameModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextNameModified));
            _textEditorSuffix = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextEditorSuffix, SetTextEditorSuffix));
            _isTextEditorSuffixModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextEditorSuffixModified));
            _textTooltip = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltip, SetTextTooltip));
            _isTextTooltipModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextTooltipModified));
            _textTooltipExtended = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipExtended, SetTextTooltipExtended));
            _isTextTooltipExtendedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextTooltipExtendedModified));
            _textHotkeyRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextHotkeyRaw, SetTextHotkeyRaw));
            _isTextHotkeyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextHotkeyModified));
            _textHotkey = new Lazy<ObjectProperty<char>>(() => new ObjectProperty<char>(GetTextHotkey, SetTextHotkey));
            _artIconRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetArtIconRaw, SetArtIconRaw));
            _isArtIconModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsArtIconModified));
            _artIcon = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetArtIcon, SetArtIcon));
            _techtreeRequirementsRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTechtreeRequirementsRaw, SetTechtreeRequirementsRaw));
            _isTechtreeRequirementsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTechtreeRequirementsModified));
            _techtreeRequirements = new Lazy<ObjectProperty<IEnumerable<Tech>>>(() => new ObjectProperty<IEnumerable<Tech>>(GetTechtreeRequirements, SetTechtreeRequirements));
            _techtreeRequirementsLevelsRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTechtreeRequirementsLevelsRaw, SetTechtreeRequirementsLevelsRaw));
            _isTechtreeRequirementsLevelsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTechtreeRequirementsLevelsModified));
            _techtreeRequirementsLevels = new Lazy<ObjectProperty<IEnumerable<int>>>(() => new ObjectProperty<IEnumerable<int>>(GetTechtreeRequirementsLevels, SetTechtreeRequirementsLevels));
        }

        private Upgrade(int oldId, int newId, ObjectDatabaseBase db): base(oldId, newId, db)
        {
            _modifications = new(this);
            _textName = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextName, SetTextName));
            _isTextNameModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextNameModified));
            _textEditorSuffix = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextEditorSuffix, SetTextEditorSuffix));
            _isTextEditorSuffixModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextEditorSuffixModified));
            _textTooltip = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltip, SetTextTooltip));
            _isTextTooltipModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextTooltipModified));
            _textTooltipExtended = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipExtended, SetTextTooltipExtended));
            _isTextTooltipExtendedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextTooltipExtendedModified));
            _textHotkeyRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextHotkeyRaw, SetTextHotkeyRaw));
            _isTextHotkeyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextHotkeyModified));
            _textHotkey = new Lazy<ObjectProperty<char>>(() => new ObjectProperty<char>(GetTextHotkey, SetTextHotkey));
            _artIconRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetArtIconRaw, SetArtIconRaw));
            _isArtIconModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsArtIconModified));
            _artIcon = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetArtIcon, SetArtIcon));
            _techtreeRequirementsRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTechtreeRequirementsRaw, SetTechtreeRequirementsRaw));
            _isTechtreeRequirementsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTechtreeRequirementsModified));
            _techtreeRequirements = new Lazy<ObjectProperty<IEnumerable<Tech>>>(() => new ObjectProperty<IEnumerable<Tech>>(GetTechtreeRequirements, SetTechtreeRequirements));
            _techtreeRequirementsLevelsRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTechtreeRequirementsLevelsRaw, SetTechtreeRequirementsLevelsRaw));
            _isTechtreeRequirementsLevelsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTechtreeRequirementsLevelsModified));
            _techtreeRequirementsLevels = new Lazy<ObjectProperty<IEnumerable<int>>>(() => new ObjectProperty<IEnumerable<int>>(GetTechtreeRequirementsLevels, SetTechtreeRequirementsLevels));
        }

        private Upgrade(int oldId, string newRawcode, ObjectDatabaseBase db): base(oldId, newRawcode, db)
        {
            _modifications = new(this);
            _textName = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextName, SetTextName));
            _isTextNameModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextNameModified));
            _textEditorSuffix = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextEditorSuffix, SetTextEditorSuffix));
            _isTextEditorSuffixModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextEditorSuffixModified));
            _textTooltip = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltip, SetTextTooltip));
            _isTextTooltipModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextTooltipModified));
            _textTooltipExtended = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextTooltipExtended, SetTextTooltipExtended));
            _isTextTooltipExtendedModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextTooltipExtendedModified));
            _textHotkeyRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTextHotkeyRaw, SetTextHotkeyRaw));
            _isTextHotkeyModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTextHotkeyModified));
            _textHotkey = new Lazy<ObjectProperty<char>>(() => new ObjectProperty<char>(GetTextHotkey, SetTextHotkey));
            _artIconRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetArtIconRaw, SetArtIconRaw));
            _isArtIconModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsArtIconModified));
            _artIcon = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetArtIcon, SetArtIcon));
            _techtreeRequirementsRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTechtreeRequirementsRaw, SetTechtreeRequirementsRaw));
            _isTechtreeRequirementsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTechtreeRequirementsModified));
            _techtreeRequirements = new Lazy<ObjectProperty<IEnumerable<Tech>>>(() => new ObjectProperty<IEnumerable<Tech>>(GetTechtreeRequirements, SetTechtreeRequirements));
            _techtreeRequirementsLevelsRaw = new Lazy<ObjectProperty<string>>(() => new ObjectProperty<string>(GetTechtreeRequirementsLevelsRaw, SetTechtreeRequirementsLevelsRaw));
            _isTechtreeRequirementsLevelsModified = new Lazy<ReadOnlyObjectProperty<bool>>(() => new ReadOnlyObjectProperty<bool>(GetIsTechtreeRequirementsLevelsModified));
            _techtreeRequirementsLevels = new Lazy<ObjectProperty<IEnumerable<int>>>(() => new ObjectProperty<IEnumerable<int>>(GetTechtreeRequirementsLevels, SetTechtreeRequirementsLevels));
        }

        public LevelObjectDataModifications Modifications => _modifications;
        public ObjectProperty<string> TextName => _textName.Value;
        public ReadOnlyObjectProperty<bool> IsTextNameModified => _isTextNameModified.Value;
        public ObjectProperty<string> TextEditorSuffix => _textEditorSuffix.Value;
        public ReadOnlyObjectProperty<bool> IsTextEditorSuffixModified => _isTextEditorSuffixModified.Value;
        public string StatsRaceRaw
        {
            get => _modifications.GetModification(1667330663).ValueAsString;
            set => _modifications[1667330663] = new LevelObjectDataModification{Id = 1667330663, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsStatsRaceModified => _modifications.ContainsKey(1667330663);
        public UnitRace StatsRace
        {
            get => StatsRaceRaw.ToUnitRace(this);
            set => StatsRaceRaw = value.ToRaw(null, null);
        }

        public ObjectProperty<string> TextTooltip => _textTooltip.Value;
        public ReadOnlyObjectProperty<bool> IsTextTooltipModified => _isTextTooltipModified.Value;
        public ObjectProperty<string> TextTooltipExtended => _textTooltipExtended.Value;
        public ReadOnlyObjectProperty<bool> IsTextTooltipExtendedModified => _isTextTooltipExtendedModified.Value;
        public ObjectProperty<string> TextHotkeyRaw => _textHotkeyRaw.Value;
        public ReadOnlyObjectProperty<bool> IsTextHotkeyModified => _isTextHotkeyModified.Value;
        public ObjectProperty<char> TextHotkey => _textHotkey.Value;
        public int ArtButtonPositionX
        {
            get => _modifications.GetModification(2020631143).ValueAsInt;
            set => _modifications[2020631143] = new LevelObjectDataModification{Id = 2020631143, Type = ObjectDataType.Int, Value = value, Level = 0};
        }

        public bool IsArtButtonPositionXModified => _modifications.ContainsKey(2020631143);
        public int ArtButtonPositionY
        {
            get => _modifications.GetModification(2037408359).ValueAsInt;
            set => _modifications[2037408359] = new LevelObjectDataModification{Id = 2037408359, Type = ObjectDataType.Int, Value = value, Level = 0};
        }

        public bool IsArtButtonPositionYModified => _modifications.ContainsKey(2037408359);
        public ObjectProperty<string> ArtIconRaw => _artIconRaw.Value;
        public ReadOnlyObjectProperty<bool> IsArtIconModified => _isArtIconModified.Value;
        public ObjectProperty<string> ArtIcon => _artIcon.Value;
        public string StatsClassRaw
        {
            get => _modifications.GetModification(1936483175).ValueAsString;
            set => _modifications[1936483175] = new LevelObjectDataModification{Id = 1936483175, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsStatsClassModified => _modifications.ContainsKey(1936483175);
        public UpgradeClass StatsClass
        {
            get => StatsClassRaw.ToUpgradeClass(this);
            set => StatsClassRaw = value.ToRaw(null, 50);
        }

        public int StatsLevels
        {
            get => _modifications.GetModification(1819700327).ValueAsInt;
            set => _modifications[1819700327] = new LevelObjectDataModification{Id = 1819700327, Type = ObjectDataType.Int, Value = value, Level = 0};
        }

        public bool IsStatsLevelsModified => _modifications.ContainsKey(1819700327);
        public int StatsGoldBase
        {
            get => _modifications.GetModification(1651271527).ValueAsInt;
            set => _modifications[1651271527] = new LevelObjectDataModification{Id = 1651271527, Type = ObjectDataType.Int, Value = value, Level = 0};
        }

        public bool IsStatsGoldBaseModified => _modifications.ContainsKey(1651271527);
        public int StatsGoldIncrement
        {
            get => _modifications.GetModification(1835820903).ValueAsInt;
            set => _modifications[1835820903] = new LevelObjectDataModification{Id = 1835820903, Type = ObjectDataType.Int, Value = value, Level = 0};
        }

        public bool IsStatsGoldIncrementModified => _modifications.ContainsKey(1835820903);
        public int StatsLumberBase
        {
            get => _modifications.GetModification(1651338343).ValueAsInt;
            set => _modifications[1651338343] = new LevelObjectDataModification{Id = 1651338343, Type = ObjectDataType.Int, Value = value, Level = 0};
        }

        public bool IsStatsLumberBaseModified => _modifications.ContainsKey(1651338343);
        public int StatsLumberIncrement
        {
            get => _modifications.GetModification(1835887719).ValueAsInt;
            set => _modifications[1835887719] = new LevelObjectDataModification{Id = 1835887719, Type = ObjectDataType.Int, Value = value, Level = 0};
        }

        public bool IsStatsLumberIncrementModified => _modifications.ContainsKey(1835887719);
        public int StatsTimeBase
        {
            get => _modifications.GetModification(1651078247).ValueAsInt;
            set => _modifications[1651078247] = new LevelObjectDataModification{Id = 1651078247, Type = ObjectDataType.Int, Value = value, Level = 0};
        }

        public bool IsStatsTimeBaseModified => _modifications.ContainsKey(1651078247);
        public int StatsTimeIncrement
        {
            get => _modifications.GetModification(1835627623).ValueAsInt;
            set => _modifications[1835627623] = new LevelObjectDataModification{Id = 1835627623, Type = ObjectDataType.Int, Value = value, Level = 0};
        }

        public bool IsStatsTimeIncrementModified => _modifications.ContainsKey(1835627623);
        public string DataEffect1_gef1Raw
        {
            get => _modifications.GetModification(828794215).ValueAsString;
            set => _modifications[828794215] = new LevelObjectDataModification{Id = 828794215, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsDataEffect1_gef1Modified => _modifications.ContainsKey(828794215);
        public UpgradeEffect DataEffect1_gef1
        {
            get => DataEffect1_gef1Raw.ToUpgradeEffect(this);
            set => DataEffect1_gef1Raw = value.ToRaw(null, null);
        }

        public float DataEffect1_gba1
        {
            get => _modifications.GetModification(828465767).ValueAsFloat;
            set => _modifications[828465767] = new LevelObjectDataModification{Id = 828465767, Type = ObjectDataType.Unreal, Value = value, Level = 0};
        }

        public bool IsDataEffect1_gba1Modified => _modifications.ContainsKey(828465767);
        public float DataEffect1_gmo1
        {
            get => _modifications.GetModification(829386087).ValueAsFloat;
            set => _modifications[829386087] = new LevelObjectDataModification{Id = 829386087, Type = ObjectDataType.Unreal, Value = value, Level = 0};
        }

        public bool IsDataEffect1_gmo1Modified => _modifications.ContainsKey(829386087);
        public string DataEffect1_gco1
        {
            get => _modifications.GetModification(829383527).ValueAsString;
            set => _modifications[829383527] = new LevelObjectDataModification{Id = 829383527, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsDataEffect1_gco1Modified => _modifications.ContainsKey(829383527);
        public string DataEffect2_gef2Raw
        {
            get => _modifications.GetModification(845571431).ValueAsString;
            set => _modifications[845571431] = new LevelObjectDataModification{Id = 845571431, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsDataEffect2_gef2Modified => _modifications.ContainsKey(845571431);
        public UpgradeEffect DataEffect2_gef2
        {
            get => DataEffect2_gef2Raw.ToUpgradeEffect(this);
            set => DataEffect2_gef2Raw = value.ToRaw(null, null);
        }

        public float DataEffect2_gba2
        {
            get => _modifications.GetModification(845242983).ValueAsFloat;
            set => _modifications[845242983] = new LevelObjectDataModification{Id = 845242983, Type = ObjectDataType.Unreal, Value = value, Level = 0};
        }

        public bool IsDataEffect2_gba2Modified => _modifications.ContainsKey(845242983);
        public float DataEffect2_gmo2
        {
            get => _modifications.GetModification(846163303).ValueAsFloat;
            set => _modifications[846163303] = new LevelObjectDataModification{Id = 846163303, Type = ObjectDataType.Unreal, Value = value, Level = 0};
        }

        public bool IsDataEffect2_gmo2Modified => _modifications.ContainsKey(846163303);
        public string DataEffect2_gco2
        {
            get => _modifications.GetModification(846160743).ValueAsString;
            set => _modifications[846160743] = new LevelObjectDataModification{Id = 846160743, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsDataEffect2_gco2Modified => _modifications.ContainsKey(846160743);
        public string DataEffect3_gef3Raw
        {
            get => _modifications.GetModification(862348647).ValueAsString;
            set => _modifications[862348647] = new LevelObjectDataModification{Id = 862348647, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsDataEffect3_gef3Modified => _modifications.ContainsKey(862348647);
        public UpgradeEffect DataEffect3_gef3
        {
            get => DataEffect3_gef3Raw.ToUpgradeEffect(this);
            set => DataEffect3_gef3Raw = value.ToRaw(null, null);
        }

        public float DataEffect3_gba3
        {
            get => _modifications.GetModification(862020199).ValueAsFloat;
            set => _modifications[862020199] = new LevelObjectDataModification{Id = 862020199, Type = ObjectDataType.Unreal, Value = value, Level = 0};
        }

        public bool IsDataEffect3_gba3Modified => _modifications.ContainsKey(862020199);
        public float DataEffect3_gmo3
        {
            get => _modifications.GetModification(862940519).ValueAsFloat;
            set => _modifications[862940519] = new LevelObjectDataModification{Id = 862940519, Type = ObjectDataType.Unreal, Value = value, Level = 0};
        }

        public bool IsDataEffect3_gmo3Modified => _modifications.ContainsKey(862940519);
        public string DataEffect3_gco3
        {
            get => _modifications.GetModification(862937959).ValueAsString;
            set => _modifications[862937959] = new LevelObjectDataModification{Id = 862937959, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsDataEffect3_gco3Modified => _modifications.ContainsKey(862937959);
        public string DataEffect4_gef4Raw
        {
            get => _modifications.GetModification(879125863).ValueAsString;
            set => _modifications[879125863] = new LevelObjectDataModification{Id = 879125863, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsDataEffect4_gef4Modified => _modifications.ContainsKey(879125863);
        public UpgradeEffect DataEffect4_gef4
        {
            get => DataEffect4_gef4Raw.ToUpgradeEffect(this);
            set => DataEffect4_gef4Raw = value.ToRaw(null, null);
        }

        public float DataEffect4_gba4
        {
            get => _modifications.GetModification(878797415).ValueAsFloat;
            set => _modifications[878797415] = new LevelObjectDataModification{Id = 878797415, Type = ObjectDataType.Unreal, Value = value, Level = 0};
        }

        public bool IsDataEffect4_gba4Modified => _modifications.ContainsKey(878797415);
        public float DataEffect4_gmo4
        {
            get => _modifications.GetModification(879717735).ValueAsFloat;
            set => _modifications[879717735] = new LevelObjectDataModification{Id = 879717735, Type = ObjectDataType.Unreal, Value = value, Level = 0};
        }

        public bool IsDataEffect4_gmo4Modified => _modifications.ContainsKey(879717735);
        public string DataEffect4_gco4
        {
            get => _modifications.GetModification(879715175).ValueAsString;
            set => _modifications[879715175] = new LevelObjectDataModification{Id = 879715175, Type = ObjectDataType.String, Value = value, Level = 0};
        }

        public bool IsDataEffect4_gco4Modified => _modifications.ContainsKey(879715175);
        public int StatsTransferWithUnitOwnershipRaw
        {
            get => _modifications.GetModification(1752066407).ValueAsInt;
            set => _modifications[1752066407] = new LevelObjectDataModification{Id = 1752066407, Type = ObjectDataType.Int, Value = value, Level = 0};
        }

        public bool IsStatsTransferWithUnitOwnershipModified => _modifications.ContainsKey(1752066407);
        public bool StatsTransferWithUnitOwnership
        {
            get => StatsTransferWithUnitOwnershipRaw.ToBool(this);
            set => StatsTransferWithUnitOwnershipRaw = value.ToRaw(null, null);
        }

        public ObjectProperty<string> TechtreeRequirementsRaw => _techtreeRequirementsRaw.Value;
        public ReadOnlyObjectProperty<bool> IsTechtreeRequirementsModified => _isTechtreeRequirementsModified.Value;
        public ObjectProperty<IEnumerable<Tech>> TechtreeRequirements => _techtreeRequirements.Value;
        public ObjectProperty<string> TechtreeRequirementsLevelsRaw => _techtreeRequirementsLevelsRaw.Value;
        public ReadOnlyObjectProperty<bool> IsTechtreeRequirementsLevelsModified => _isTechtreeRequirementsLevelsModified.Value;
        public ObjectProperty<IEnumerable<int>> TechtreeRequirementsLevels => _techtreeRequirementsLevels.Value;
        public int StatsAppliesToAllUnitsRaw
        {
            get => _modifications.GetModification(1651469415).ValueAsInt;
            set => _modifications[1651469415] = new LevelObjectDataModification{Id = 1651469415, Type = ObjectDataType.Int, Value = value, Level = 0};
        }

        public bool IsStatsAppliesToAllUnitsModified => _modifications.ContainsKey(1651469415);
        public bool StatsAppliesToAllUnits
        {
            get => StatsAppliesToAllUnitsRaw.ToBool(this);
            set => StatsAppliesToAllUnitsRaw = value.ToRaw(null, null);
        }

        public static explicit operator LevelObjectModification(Upgrade upgrade) => new LevelObjectModification{OldId = upgrade.OldId, NewId = upgrade.NewId, Modifications = upgrade.Modifications.ToList()};
        internal override bool TryGetLevelModifications([NotNullWhen(true)] out LevelObjectDataModifications? modifications)
        {
            modifications = _modifications;
            return true;
        }

        public void AddModifications(List<LevelObjectDataModification> modifications)
        {
          foreach (var modification in modifications)
            _modifications[modification.Id, modification.Level] = modification;
        }

        private string GetTextName(int level)
        {
            return _modifications.GetModification(1835101799, level).ValueAsString;
        }

        private void SetTextName(int level, string value)
        {
            _modifications[1835101799, level] = new LevelObjectDataModification{Id = 1835101799, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private bool GetIsTextNameModified(int level)
        {
            return _modifications.ContainsKey(1835101799, level);
        }

        private string GetTextEditorSuffix(int level)
        {
            return _modifications.GetModification(1718840935, level).ValueAsString;
        }

        private void SetTextEditorSuffix(int level, string value)
        {
            _modifications[1718840935, level] = new LevelObjectDataModification{Id = 1718840935, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private bool GetIsTextEditorSuffixModified(int level)
        {
            return _modifications.ContainsKey(1718840935, level);
        }

        private string GetTextTooltip(int level)
        {
            return _modifications.GetModification(829453415, level).ValueAsString;
        }

        private void SetTextTooltip(int level, string value)
        {
            _modifications[829453415, level] = new LevelObjectDataModification{Id = 829453415, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private bool GetIsTextTooltipModified(int level)
        {
            return _modifications.ContainsKey(829453415, level);
        }

        private string GetTextTooltipExtended(int level)
        {
            return _modifications.GetModification(828536167, level).ValueAsString;
        }

        private void SetTextTooltipExtended(int level, string value)
        {
            _modifications[828536167, level] = new LevelObjectDataModification{Id = 828536167, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private bool GetIsTextTooltipExtendedModified(int level)
        {
            return _modifications.ContainsKey(828536167, level);
        }

        private string GetTextHotkeyRaw(int level)
        {
            return _modifications.GetModification(829122663, level).ValueAsString;
        }

        private void SetTextHotkeyRaw(int level, string value)
        {
            _modifications[829122663, level] = new LevelObjectDataModification{Id = 829122663, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private bool GetIsTextHotkeyModified(int level)
        {
            return _modifications.ContainsKey(829122663, level);
        }

        private char GetTextHotkey(int level)
        {
            return GetTextHotkeyRaw(level).ToChar(this);
        }

        private void SetTextHotkey(int level, char value)
        {
            SetTextHotkeyRaw(level, value.ToRaw(null, null));
        }

        private string GetArtIconRaw(int level)
        {
            return _modifications.GetModification(829579623, level).ValueAsString;
        }

        private void SetArtIconRaw(int level, string value)
        {
            _modifications[829579623, level] = new LevelObjectDataModification{Id = 829579623, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private bool GetIsArtIconModified(int level)
        {
            return _modifications.ContainsKey(829579623, level);
        }

        private string GetArtIcon(int level)
        {
            return GetArtIconRaw(level).ToString(this);
        }

        private void SetArtIcon(int level, string value)
        {
            SetArtIconRaw(level, value.ToRaw(null, 200));
        }

        private string GetTechtreeRequirementsRaw(int level)
        {
            return _modifications.GetModification(1902473831, level).ValueAsString;
        }

        private void SetTechtreeRequirementsRaw(int level, string value)
        {
            _modifications[1902473831, level] = new LevelObjectDataModification{Id = 1902473831, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private bool GetIsTechtreeRequirementsModified(int level)
        {
            return _modifications.ContainsKey(1902473831, level);
        }

        private IEnumerable<Tech> GetTechtreeRequirements(int level)
        {
            return GetTechtreeRequirementsRaw(level).ToIEnumerableTech(this);
        }

        private void SetTechtreeRequirements(int level, IEnumerable<Tech> value)
        {
            SetTechtreeRequirementsRaw(level, value.ToRaw(null, null));
        }

        private string GetTechtreeRequirementsLevelsRaw(int level)
        {
            return _modifications.GetModification(1668379239, level).ValueAsString;
        }

        private void SetTechtreeRequirementsLevelsRaw(int level, string value)
        {
            _modifications[1668379239, level] = new LevelObjectDataModification{Id = 1668379239, Type = ObjectDataType.String, Value = value, Level = level};
        }

        private bool GetIsTechtreeRequirementsLevelsModified(int level)
        {
            return _modifications.ContainsKey(1668379239, level);
        }

        private IEnumerable<int> GetTechtreeRequirementsLevels(int level)
        {
            return GetTechtreeRequirementsLevelsRaw(level).ToIEnumerableInt(this);
        }

        private void SetTechtreeRequirementsLevels(int level, IEnumerable<int> value)
        {
            SetTechtreeRequirementsLevelsRaw(level, value.ToRaw(null, null));
        }
    }
}
