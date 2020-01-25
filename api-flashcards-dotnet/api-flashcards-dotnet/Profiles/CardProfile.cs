using System;
using System.Collections.Generic;
using api_flashcards_dotnet.Dtos;
using api_flashcards_dotnet.Dtos.Models;
using api_flashcards_dotnet.Models;
using AutoMapper;

namespace api_flashcards_dotnet.Profiles
{
    public class CardProfile:Profile
    {
        public CardProfile()
        {
            CreateMap<Card, CardResponseDto>();
            CreateMap<List<Card>, CardResponse>()
                .ForMember(dest => dest.Cards, opt => opt.MapFrom(src => src));
            
        }
    }
}
