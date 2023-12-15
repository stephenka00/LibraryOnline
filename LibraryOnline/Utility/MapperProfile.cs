using AutoMapper;
using LibraryModels;
using LibraryWeb.Models.BookViewModel;
using LibraryWeb.Models.CategoryViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryViewModels.Utility
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Book, BookViewModel>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Categories.CategoryName));
            CreateMap<BookViewModel, Book>();
            CreateMap<Category, CategoryViewModel>();
        }
    }
}
