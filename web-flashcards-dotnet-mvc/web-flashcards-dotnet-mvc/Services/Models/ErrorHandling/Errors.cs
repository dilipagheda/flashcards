using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace web_flashcards_dotnet_mvc.Services.Models.ErrorHandling
{
    public class Errors
    {
        [JsonProperty("Errors")]
        public ErrorItems ErrorItems { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string TraceId { get; set; }
    }
}
