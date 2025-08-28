using AutoMapper;
using LMS.Application.DTOs;
using LMSAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Common.Mappings
{
    public class BookDetailsMapping : Profile
    {
        public BookDetailsMapping() 
        {
            CreateMap<BookDetails, BookDetailsDTO>().ReverseMap();
        }
    }
}
