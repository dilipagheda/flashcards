using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Http;
using web_flashcards_dotnet_mvc.Services.Models;
using web_flashcards_dotnet_mvc.Services.Models.ErrorHandling;

namespace web_flashcards_dotnet_mvc.Services
{
    public class FlashcardClient
    {
        private readonly string _baseUrl;
        private readonly string _token;

        public FlashcardClient(string baseUrl, IHttpContextAccessor httpContextAccessor)
        {
            _baseUrl = baseUrl;
            var claims = httpContextAccessor.HttpContext.User?.Identities?.First()?.Claims?.ToList();
            _token = claims?.FirstOrDefault(claim => claim.Type == "AccessToken")?.Value;
        }

        public async Task<ApplicationUser> Login(string email, string password)
        {
            ApplicationUser applicationUser = null;
            try
            {
                applicationUser = await _baseUrl.AppendPathSegment("/user/login")
                                                    .PostJsonAsync(new
                                                    {
                                                        Email = email,
                                                        Password = password
                                                    })
                                                    .ReceiveJson<ApplicationUser>();

                
            }
            catch (FlurlHttpException e)
            {
                return null;
            }

            return applicationUser;

        }

        public async Task<RegisterResponse> Register(string email, string password, string displayName)
        {
            RegisterResponse registerResponse = null;

            try
            {
                registerResponse = await _baseUrl.AppendPathSegment("/user/register")
                                                    .PostJsonAsync(new
                                                    {
                                                        Email = email,
                                                        Password = password,
                                                        DisplayName = displayName
                                                    })
                                                    .ReceiveJson<RegisterResponse>();
            }
            catch (FlurlHttpException e)
            {
                return null;
            }

            return registerResponse;
        }

        public async Task<DeckResponse> GetDecks()
        {
            DeckResponse deckResponse = null;

            if (!CheckToken()) return null;

            try
            {
                deckResponse = await _baseUrl.AppendPathSegment("/decks")
                                             .WithOAuthBearerToken(_token)
                                             .GetJsonAsync<DeckResponse>();
            }
            catch (FlurlHttpException e)
            {
                return null;
            }
            return deckResponse;
        }

        public async Task<CreateDeckResponse> CreateDeck(string deckName)
        {
            var response = new CreateDeckResponse();

            try
            {
                var result = await _baseUrl.AppendPathSegment("/decks")
                              .WithOAuthBearerToken(_token)
                              .PostJsonAsync(new
                              {
                                  Name = deckName
                              });

                response.isSuccess = result.IsSuccessStatusCode;

            }
            catch(FlurlHttpException e)
            {

                response.Errors = await e.GetResponseJsonAsync<Errors>();
            }

            return response;
        }

        public async Task<Deck> GetDeckById(int id)
        {
            Deck deck = null;

            if (!CheckToken()) return null;

            try
            {
                deck = await _baseUrl.AppendPathSegment($"/decks/{id}")
                                             .WithOAuthBearerToken(_token)
                                             .GetJsonAsync<Deck>();
            }
            catch (FlurlHttpException e)
            {
                return null;
            }
            return deck;
        }

        public async Task<GetCardByIdResponse> GetCardsByDeckId(int deckId)
        {
            GetCardByIdResponse getCardByIdResponse = null;

            if (!CheckToken()) return null;

            try
            {
                getCardByIdResponse = await _baseUrl.AppendPathSegment($"/decks/{deckId}/cards")
                                                     .WithOAuthBearerToken(_token)
                                                     .GetJsonAsync<GetCardByIdResponse>();
            }
            catch (FlurlHttpException e)
            {
                return null;
            }
            return getCardByIdResponse;
        }

        private bool CheckToken()
        {
            if (_token == null || _token.Length == 0) return false;

            return true;
        }
    }
}
