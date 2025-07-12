using AutoMapper;
using ScrollsTracker.Api.Requests;
using ScrollsTracker.Domain.Models;

namespace ScrollsTracker.Api.AutoMapperProfile
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<ObraRequest, Obra>().ReverseMap();
		}
	}
}
