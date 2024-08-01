using Core.Dto;
using Core.Entites._Other;
using Core.Repositories;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Core.Services;

public class OtherWebService
{
  private readonly IGenericRepository<OtherGallery> _genericGalleryRepository;
  private readonly IGenericRepository<OtherContactForm> _genericContactRepository;
  private readonly IGenericRepository<OtherPrivacyNotice> _genericPrivacyRepository;
  private readonly IGenericRepository<OtherTermsCondition> _genericTermsRepository;
  private readonly ILogger<OtherWebService> _logger;
  private readonly IMemoryCache _cache;

  public OtherWebService(IGenericRepository<OtherGallery> genericGalleryRepository, IGenericRepository<OtherContactForm> genericContactRepository, IGenericRepository<OtherPrivacyNotice> genericPrivacyRepository, IGenericRepository<OtherTermsCondition> genericTermsRepository, ILogger<OtherWebService> logger, IMemoryCache cache)
  {
    _genericGalleryRepository = genericGalleryRepository;
    _genericContactRepository = genericContactRepository;
    _genericPrivacyRepository = genericPrivacyRepository;
    _genericTermsRepository = genericTermsRepository;
    _logger = logger;
    _cache = cache;
  }


  public async Task<List<OtherGallery>> GetGalleries()
  {
    var list = new List<OtherGallery>();
    try
    {
      var cache = _cache.Get<List<OtherGallery>>("Other.GetGalleries1");
      if (cache != null) return cache;

      list = await _genericGalleryRepository.GetList(x => x.IdAgency == 1);
      list = list.OrderBy(x => x.Order).ToList();
      return _cache.Set("Other.GetGalleries1", list);
    }
    catch (Exception e)
    {
      _logger.LogError(e, "Error");
    }
    return list;
  }

  public async Task<OtherTermsCondition> TermsCondition()
  {
    var other = new OtherTermsCondition();
    try
    {
      var cache = _cache.Get<OtherTermsCondition>("Other.TermsCondition1");
      if (cache != null) return cache;

      other = await _genericTermsRepository.GetOrNull(x => x.IdAgency == 1) ?? new OtherTermsCondition();
      return _cache.Set("Other.TermsCondition1", other);
    }
    catch (Exception e)
    {
      _logger.LogError(e, "Error");
    }
    return other;
  }

  public async Task<OtherPrivacyNotice> PrivacyNotice()
  {
    var other = new OtherPrivacyNotice();
    try
    {
      var cache = _cache.Get<OtherPrivacyNotice>("Other.PrivacyNotice1");
      if (cache != null) return cache;

      other = await _genericPrivacyRepository.GetOrNull(x => x.IdAgency == 1) ?? new OtherPrivacyNotice();
      return _cache.Set("Other.PrivacyNotice1", other);
    }
    catch (Exception e)
    {
      _logger.LogError(e, "Error");
    }
    return other;
  }

  public async Task<Response> SendInfo(OtherContactForm model)
  {
    var response = new Response();
    try
    {
      model.IdAgency = 1;
      model.ContactDate = DateTime.UtcNow;
      model.ContactDateTimeZone = TimeZoneInfo.Local.Id;
      _genericContactRepository.Create(model);
      await _genericContactRepository.SaveChanges();
      response.Success = true;
      response.Message = "Mensaje enviado correctamente";
    }
    catch (Exception e)
    {
      _logger.LogError(e, "Error");
      response.Message = "Error";
    }
    return response;
  }
}
