using AutoMapper;
using cSharpAPIDemo.Models.Dtos;
using cSharpAPIDemo.Models;
namespace cSharpAPIDemo.appMapper
{
    public class appMappers: Profile
    {
        public appMappers()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
