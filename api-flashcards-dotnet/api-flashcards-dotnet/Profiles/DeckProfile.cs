using System;
using System.Collections.Generic;
using api_flashcards_dotnet.Dtos;
using api_flashcards_dotnet.Models;
using AutoMapper;

namespace api_flashcards_dotnet.Profiles
{
    public class DeckProfile:Profile
    {
        public DeckProfile()
        {
            CreateMap<Deck, DeckResponse>();
        }
    }
}
