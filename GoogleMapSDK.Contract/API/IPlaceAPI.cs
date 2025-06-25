using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapSDK.Contract.API.Models.RequestModels;
using GoogleMapSDK.Contract.API.Models.ResponseModels;


namespace GoogleMapSDK.Contract.API
{
    public interface IPlaceAPI
    {
        /// <summary>
        /// Find a place from text input
        /// </summary>
        /// <param name="model">Find place request parameters</param>
        /// <returns>Find place response</returns>
        Task<FindPlaceResponseModel> FindPlaceAsync(FindPlaceRequestModel model);

        /// <summary>
        /// Search for nearby places
        /// </summary>
        /// <param name="model">Nearby search request parameters</param>
        /// <returns>Nearby search response</returns>
        Task<NearBySearchResponseModel> NearBySearchAsync(NearBySearchRequestModel model);

        /// <summary>
        /// Search for places using text query
        /// </summary>
        /// <param name="model">Text search request parameters</param>
        /// <returns>Text search response</returns>
        Task<TextSearchResponseModel> TextSearchAsync(TextSearchRequestModel model);

        /// <summary>
        /// Get detailed information about a place
        /// </summary>
        /// <param name="model">Place detail request parameters</param>
        /// <returns>Place detail response</returns>
        Task<PlaceDetailResponseModel> PlaceDetailAsync(PlaceDetailRequestModel model);

        /// <summary>
        /// Get place autocomplete suggestions
        /// </summary>
        /// <param name="model">Place autocomplete request parameters</param>
        /// <returns>Place autocomplete response</returns>
        Task<PlaceAutoComplelteResponseModel> PlaceAutocomplete(PlaceAutoComplelteRequestModel model);

        /// <summary>
        /// Get a photo of a place
        /// </summary>
        /// <param name="model">Place photo request parameters</param>
        /// <returns>Bitmap image of the place</returns>
        Task<Bitmap> PlacePhoto(PlacePhotoRequestModel model);

        /// <summary>
        /// Get a photo by photo reference
        /// </summary>
        /// <param name="photoModel">Photo reference request parameters</param>
        /// <returns>Bitmap image</returns>
        Task<Bitmap> PhotoReference(PhotoRequest photoModel);

        /// <summary>
        /// Get query autocomplete suggestions
        /// </summary>
        /// <param name="model">Query autocomplete request parameters</param>
        /// <returns>Query autocomplete response</returns>
        Task<QueryAutoCompleteResponseModel> QueryAutoComplete(QueryAutoCompleteRequestModel model);
    }
}
