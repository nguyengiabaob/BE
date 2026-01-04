using System.ComponentModel;

public enum UserType {
  [Description("facebook")]
  FACEBOOK = 0,
  [Description("google")]
  GOOGLE = 1,
  [Description("default")]
  DEFAULT = 2
}