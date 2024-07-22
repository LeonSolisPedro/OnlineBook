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

  public enum RepeatType
  {
    EVERYDAY,
    EVERYNNNDAYS,
    SPECIFICDAYS
  }

  public enum Gender
  {
    FEMALE,
    MALE

  }

  public enum TourReservationStatus
  {
    PENDING,
    PAID,
    COMFIRMED,
  }


  public enum PopularType
  {
    POPULAR,
    OTHERTOURS
  }

  public enum ContactStatus
  {
    NEW,
    ATTENDING,
    CLEAR,
    SPAM
  }

  public enum TourType
  {
    SINGLEDAY,
    MULTIDAY
  }

  public enum SocialName
  {
    FACEBOOK,
    TWITTER,
    WHATSAPP,
    GOOGLEMAPS,
    INSTAGRAM,
    PINTEREST,
    YOUTUBE,
    LINKEDIN,
    TIKTOK
  }
}
