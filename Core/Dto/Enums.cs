using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Dto;

public class Enums
{
  public enum DurationType
  {
    HOURS,
    DAYS
  }

  public enum IncludeType
  {
    INCLUDES,
    EXCLUDES,
    RECOMENDATIONS
  }
}
