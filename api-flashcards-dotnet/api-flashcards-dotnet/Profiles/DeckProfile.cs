using System;
using System.Collections.Generic;
using api_flashcards_dotnet.Dtos;
using api_flashcards_dotnet.Dtos.Models;
using api_flashcards_dotnet.Models;
using AutoMapper;

namespace api_flashcards_dotnet.Profiles
{
    public class DeckProfile:Profile
    {
        public DeckProfile()
        {
            CreateMap<Deck, DeckResponseDto>()
                .ForMember(dest => dest.TotalCards, opt => opt.MapFrom( src => src.Cards.Count));
            CreateMap<List<Deck>, DeckResponse>()
                .ForMember(dest => dest.Decks, opt => opt.MapFrom(src => src));
        }
    }
}
