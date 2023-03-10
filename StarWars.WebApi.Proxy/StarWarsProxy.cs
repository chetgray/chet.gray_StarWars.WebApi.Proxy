using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;

using StarWars.WebApi.Proxy.Models;

namespace StarWars.WebApi.Proxy
{
    /// <summary>
    /// Provides access to the Star Wars Web API.
    /// </summary>
    public class StarWarsProxy
    {
        /// <summary>
        /// The <see cref="HttpClient">HttpClient</see> instance used to call the API.
        /// </summary>
        private readonly HttpClient apiClient;

        /// <summary>
        /// The base <see cref="Uri">URI</see> used to call the API.
        /// </summary>
        private readonly Uri baseUri;

        /// <summary>
        /// The <see cref="JsonSerializerSettings">settings</see> used to deserialize JSON
        /// responses.
        /// </summary>
        private readonly JsonSerializerSettings settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="StarWarsProxy"/> class.
        /// </summary>
        public StarWarsProxy()
        {
            ApiHelper.InitializeClient();
            apiClient = ApiHelper.ApiClient;
            baseUri = new Uri("http://localhost:8002/api/");
            settings = new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
            };
        }

        /// <summary>
        /// Gets the first <see cref="CharacterModel">character</see> with the specified
        /// <paramref name="name">name</paramref>.
        /// </summary>
        /// <param name="name">
        /// The <see cref="CharacterModel.Name">name</see> to filter for.
        /// </param>
        /// <returns>
        /// The <see cref="Task{CharacterModel}">task object</see> representing the asynchronous
        /// operation, returning the first <see cref="CharacterModel">character</see> with the
        /// specified <paramref name="name">name</paramref>, or <c><see
        /// langword="null">null</see></c> if none is found.
        /// </returns>
        /// <exception cref="HttpRequestException">
        /// The <see cref="HttpResponseMessage">HTTP response</see> <see
        /// cref="HttpResponseMessage.StatusCode">status code</see> does not indicate success.
        /// </exception>
        public async Task<CharacterModel> GetCharacterByNameAsync(string name)
        {
            Uri requestUri = new Uri(baseUri, $"Characters/ByName/{name}");
            string json;
            using (HttpResponseMessage response = await apiClient.GetAsync(requestUri))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException(
                        "Response status code does not indicate success: "
                            + $"{(int)response.StatusCode} ({response.ReasonPhrase})."
                    );
                }
                json = await response.Content.ReadAsStringAsync();
            }
            CharacterModel character = JsonConvert.DeserializeObject<CharacterModel>(
                json,
                settings
            );
            return character;
        }

        /// <summary>
        /// Gets all <see cref="CharacterModel">character</see>s.
        /// </summary>
        /// <returns>
        /// The <see cref="Task{IList{CharacterModel}}">task object</see> representing the
        /// asynchronous operation, returning a <see
        /// cref="IList{CharacterModel}">collection</see> of all <see
        /// cref="CharacterModel">character</see>s.
        /// </returns>
        /// <exception cref="HttpRequestException">
        /// The <see cref="HttpResponseMessage">HTTP response</see> <see
        /// cref="HttpResponseMessage.StatusCode">status code</see> does not indicate success.
        /// </exception>
        public async Task<IList<CharacterModel>> ListCharactersAsync()
        {
            Uri requestUri = new Uri(baseUri, "Characters");
            string json;
            using (HttpResponseMessage response = await apiClient.GetAsync(requestUri))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException(
                        "Response status code does not indicate success: "
                            + $"{(int)response.StatusCode} ({response.ReasonPhrase})."
                    );
                }
                json = await response.Content.ReadAsStringAsync();
            }
            IList<CharacterModel> characters = JsonConvert.DeserializeObject<
                List<CharacterModel>
            >(json, settings);
            return characters;
        }

        /// <summary>
        /// Gets all <see cref="CharacterModel">character</see>s with the specified <paramref
        /// name="allegiance">allegiance</paramref>.
        /// </summary>
        /// <param name="allegiance">
        /// The <see cref="CharacterModel.Allegiance">allegiance</see> to filter for.
        /// </param>
        /// <returns>
        /// The <see cref="Task{IList{CharacterModel}}">task object</see> representing the
        /// asynchronous operation, returning a <see
        /// cref="IList{CharacterModel}">collection</see> of all <see
        /// cref="CharacterModel">character</see>s with the specified <paramref
        /// name="allegiance">allegiance</paramref>.
        /// </returns>
        /// <exception cref="HttpRequestException">
        /// The <see cref="HttpResponseMessage">HTTP response</see> <see
        /// cref="HttpResponseMessage.StatusCode">status code</see> does not indicate success.
        /// </exception>
        public async Task<IList<CharacterModel>> ListCharactersByAllegianceAsync(
            Allegiance allegiance
        )
        {
            Uri requestUri = new Uri(baseUri, $"Characters/AllByAllegiance/{allegiance}");
            string json;
            using (HttpResponseMessage response = await apiClient.GetAsync(requestUri))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException(
                        "Response status code does not indicate success: "
                            + $"{(int)response.StatusCode} ({response.ReasonPhrase})."
                    );
                }
                json = await response.Content.ReadAsStringAsync();
            }
            IList<CharacterModel> characters = JsonConvert.DeserializeObject<
                List<CharacterModel>
            >(json, settings);
            return characters;
        }

        /// <summary>
        /// Gets all <see cref="CharacterModel">character</see>s that are introduced in the
        /// specified <paramref name="trilogy">trilogy</paramref>.
        /// </summary>
        /// <param name="trilogy">
        /// The <see cref="CharacterModel.TrilogyIntroducedIn">trilogy</see> to filter for.
        /// </param>
        /// <returns>
        /// The <see cref="Task{IList{CharacterModel}}">task object</see> representing the
        /// asynchronous operation, returning a <see
        /// cref="IList{CharacterModel}">collection</see> of all <see
        /// cref="CharacterModel">character</see>s that are introduced in the specified
        /// <paramref name="trilogy">trilogy</paramref>.
        /// </returns>
        /// <exception cref="HttpRequestException">
        /// The <see cref="HttpResponseMessage">HTTP response</see> <see
        /// cref="HttpResponseMessage.StatusCode">status code</see> does not indicate success.
        /// </exception>
        public async Task<IList<CharacterModel>> ListCharactersByTrilogyAsync(Trilogy trilogy)
        {
            Uri requestUri = new Uri(baseUri, $"Characters/AllByTrilogy/{trilogy}");
            string json;
            using (HttpResponseMessage response = await apiClient.GetAsync(requestUri))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException(
                        "Response status code does not indicate success: "
                            + $"{(int)response.StatusCode} ({response.ReasonPhrase})."
                    );
                }
                json = await response.Content.ReadAsStringAsync();
            }
            IList<CharacterModel> characters = JsonConvert.DeserializeObject<
                List<CharacterModel>
            >(json, settings);
            return characters;
        }
    }
}
