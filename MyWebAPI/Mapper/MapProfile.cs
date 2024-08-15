using AutoMapper;
using MyWebAPI.DTOs;
using MyWebAPI.Models;

namespace MyWebAPI.Mapper;

public class MapProfile : Profile
{
	public MapProfile()
	{
		CreateMap<Category, CategoryDTO>().ReverseMap();
	}
}
