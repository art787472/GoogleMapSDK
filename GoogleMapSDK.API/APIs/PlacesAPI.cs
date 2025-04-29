using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using GoogleMapSDK.API.Models.RequestModels;
using GoogleMapSDK.API.Models.ResponseModels;
using GoogleMapSDK.API.Utility;
using Request = HttpRequest.HttpRequest;

namespace GoogleMapSDK.API.APIs
{
    public class PlacesAPI
    {
        private readonly Request _request;

        public PlacesAPI(Request request)
        {
            _request = request;
        }

        public async Task<FindPlaceResponseModel> FindPlaceAsync(FindPlaceRequestModel model)
        {
            var baseUrl = $"https://maps.googleapis.com/maps/api/place/findplacefromtext/json";

            var param = model.param;
            param["key"] = _request.Token;




            return await _request.GetAsync<FindPlaceResponseModel>(baseUrl, model.param);
        }

        public async Task<NearBySearchResponseModel> NearBySearchAsync(NearBySearchRequestModel model)
        {
            var baseUrl = $"https://maps.googleapis.com/maps/api/place/nearbysearch/json";

            var param = model.ToDictionary();
            param["key"] = _request.Token;




            return await _request.GetAsync<NearBySearchResponseModel>(baseUrl, param);
        }

        public async Task<TextSearchResponseModel> TextSearchAsync(string query)
        {
            var baseUrl = $"https://maps.googleapis.com/maps/api/place/textsearch/json?query={query}&key={_request.Token}";

            return await _request.GetAsync<TextSearchResponseModel>(baseUrl);
        }

        public async Task<PlaceDetailResponseModel> PlaceDetailAsync(PlaceDetailRequestModel model)
        {
            var baseUrl = $"https://maps.googleapis.com/maps/api/place/details/json";
            var param = model.param;
            param["key"] = _request.Token;
            return await _request.GetAsync<PlaceDetailResponseModel>(baseUrl, model.param);


        }

        public async Task<PlaceAutoComplelteResponseModel> PlaceAutocomplete(PlaceAutoComplelteRequestModel model)
        {
            var baseUrl = $"https://maps.googleapis.com/maps/api/place/autocomplete/json";

            var param = model.ToDictionary();
            param["key"] = _request.Token;




            return await _request.GetAsync<PlaceAutoComplelteResponseModel>(baseUrl, param);
        }

        public async Task<Bitmap> PlacePhoto(PlacePhotoRequestModel model)
        {
            var baseUrl = $"https://maps.googleapis.com/maps/api/place/details/json?placeid={model.Photo_Id}&key={_request.Token}";

            var param = model.ToDictionary();
            param["key"] = _request.Token;
            var photoDetail = await _request.GetAsync<PlacePhotoResponseModel>(baseUrl);
            var photoReference = photoDetail.result.photos[0].photo_reference;
            var photoUrl = $"https://maps.googleapis.com/maps/api/place/photo?maxwidth={model.MaxWidth}&photo_reference={photoReference}&key={_request.Token}";
            var photo = await _request.GetImgAsync(photoUrl);
            return photo;
        }

        public async Task<QueryAutoCompleteResponseModel> QueryAutoComplete(string query)
        {
            var baseUrl = $"https://maps.googleapis.com/maps/api/place/queryautocomplete/json";
            var param = new Dictionary<string, string> { { "query", query } };
            param["key"] = _request.Token;
            return await _request.GetAsync<QueryAutoCompleteResponseModel>(baseUrl, param);
        }
    }
}
