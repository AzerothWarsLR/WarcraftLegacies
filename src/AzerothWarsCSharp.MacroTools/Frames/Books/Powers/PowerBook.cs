using System;
using System.Linq;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Frames.Books.Powers
{
  public sealed class PowerBook : Book<PowerPage>
  {
    private const float BottomButtonYOffset = 0.015f;
    private const float BottomButtonXOffset = 0.02f;
    private const float BookWidth = 0.25f;
    private const float BookHeight = 0.3f;

    // ReSharper disable once NotAccessedField.Local
    private static PowerBook? _instance;
    private static bool _initialized;

    private PowerBook(float width, float height, float bottomButtonXOffset, float bottomButtonYOffset) : base(width,
      height, bottomButtonXOffset, bottomButtonYOffset)
    {
      FactionSystem.PowerAdded += OnFactionSystemPowerAdded;
      var firstPage = AddPage();
      firstPage.Visible = true;
      AddAllPowers();
      LauncherName = "Powers";
      LauncherPosition = new Point(0.05f, 0.56f);
      Position = new Point(0.2f, 0.38f);
    }

    private void AddPower(Power power)
    {
      var lastPage = Pages.Last();
      if (lastPage.CardCount >= lastPage.CardLimit)
      {
        AddPage();
        lastPage = Pages.Last();
      }
      lastPage.AddPower(power);
    }

    private void AddAllPowers()
    {
      foreach (var power in FactionSystem.GetAllPowers()) AddPower(power);
    }

    private static void LoadToc(string tocFilePath)
    {
      if (!BlzLoadTOCFile(tocFilePath)) throw new Exception($"Failed to load TOC {tocFilePath}");
    }

    private void OnFactionSystemPowerAdded(object? sender, PowerEventArgs args)
    {
      AddPower(args.Power);
    }

    public static void Initialize()
    {
      if (!_initialized)
      {
        LoadToc(@"war3mapImported\ArtifactSystem.toc");
        LoadToc(@"ui\framedef\framedef.toc");
        _instance = new PowerBook(BookWidth, BookHeight, BottomButtonXOffset, BottomButtonYOffset);
        _initialized = true;
      }
    }

    protected override void DisposeEvents()
    {
      FactionSystem.PowerAdded -= OnFactionSystemPowerAdded;
    }
  }
}