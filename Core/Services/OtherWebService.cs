using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Dto;
using Core.Entites._Other;
using Core.Repositories;

namespace Core.Services;

public class OtherWebService
{
  private readonly IGenericRepository<OtherGallery> _genericGalleryRepository;
  private readonly IGenericRepository<OtherContactForm> _genericContactRepository;
  private readonly IGenericRepository<OtherPrivacyNotice> _genericPrivacyRepository;
  private readonly IGenericRepository<OtherTermsCondition> _genericTermsRepository;

  public OtherWebService(IGenericRepository<OtherGallery> genericGalleryRepository, IGenericRepository<OtherContactForm> genericContactRepository, IGenericRepository<OtherPrivacyNotice> genericPrivacyRepository, IGenericRepository<OtherTermsCondition> genericTermsRepository)
  {
    _genericGalleryRepository = genericGalleryRepository;
    _genericContactRepository = genericContactRepository;
    _genericPrivacyRepository = genericPrivacyRepository;
    _genericTermsRepository = genericTermsRepository;
  }


  public async Task<List<OtherGallery>> GetGalleries()
  {
    var list = await _genericGalleryRepository.GetList(x => x.IdAgency == 1);
    return list.OrderBy(x => x.Order).ToList();
  }

  public async Task<Response> SendInfo(OtherContactForm model)
  {
    model.IdAgency = 1;
    model.ContactDate = DateTime.UtcNow;
    model.ContactDateTimeZone = TimeZoneInfo.Local.Id;

    _genericContactRepository.Create(model);
    await _genericContactRepository.SaveChanges();

    var response = new Response
    {
      Message = "Mensaje enviado correctamente",
      Success = true,
      Data = model
    };

    return response;
  }

  public async Task<OtherTermsCondition> TermsCondition()
  {
    return await _genericTermsRepository.GetOrNull(x => x.IdAgency == 1) ?? new OtherTermsCondition();
  }

  public async Task<OtherPrivacyNotice> PrivacyNotice()
  {
    return await _genericPrivacyRepository.GetOrNull(x => x.IdAgency == 1) ?? new OtherPrivacyNotice();
  }

}
