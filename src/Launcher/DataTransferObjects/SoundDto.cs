namespace Launcher.DataTransferObjects;

public sealed class SoundDto
{
  public string Name { get; set; }
  public string FilePath { get; set; }
  public string EaxSetting { get; set; }
  public int Flags { get; set; }
  public int FadeInRate { get; set; }
  public int FadeOutRate { get; set; }
  public int Volume { get; set; }
  public double Pitch { get; set; }
  public double PitchVariance { get; set; }
  public int Priority { get; set; }
  public int Channel { get; set; }
  public double MinDistance { get; set; }
  public double MaxDistance { get; set; }
  public double DistanceCutoff { get; set; }
  public double ConeAngleInside { get; set; }
  public double ConeAngleOutside { get; set; }
  public int ConeOutsideVolume { get; set; }
  public Vector3Dto ConeOrientation { get; set; }
  public string SoundName { get; set; }
  public int DialogueTextKey { get; set; }
  public string Unk2 { get; set; }
  public int DialogueSpeakerNameKey { get; set; }
  public int Unk4 { get; set; }
  public object Unk5 { get; set; }
  public string Unk6 { get; set; }
  public string Unk7 { get; set; }
  public string FacialAnimationLabel { get; set; }
  public string FacialAnimationGroupLabel { get; set; }
  public string FacialAnimationSetFilepath { get; set; }
  public int Unk11 { get; set; }
}
