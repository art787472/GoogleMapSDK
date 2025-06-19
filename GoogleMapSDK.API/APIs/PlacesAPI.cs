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
        private readonly string _baseURL = "https://maps.googleapis.com/maps/api/place";
        public PlacesAPI(Request request)
        {
            _request = request;
        }

        public async Task<FindPlaceResponseModel> FindPlaceAsync(FindPlaceRequestModel model)
        {
            var baseUrl = $"{_baseURL}/findplacefromtext/json";
            return await _request.GetAsync<FindPlaceResponseModel>(baseUrl + model.ToUri());
        }

        public async Task<NearBySearchResponseModel> NearBySearchAsync(NearBySearchRequestModel model)
        {
            var baseUrl = $"{_baseURL}/nearbysearch/json";
            return await _request.GetAsync<NearBySearchResponseModel>(baseUrl + model.ToUri());
        }

        public async Task<TextSearchResponseModel> TextSearchAsync(TextSearchRequestModel model)
        {
            var baseUrl = $"{_baseURL}/textsearch/json";
            return await _request.GetAsync<TextSearchResponseModel>(baseUrl + model.ToUri());
        }

        public async Task<PlaceDetailResponseModel> PlaceDetailAsync(PlaceDetailRequestModel model)
        {
            var baseUrl = $"{_baseURL}/details/json";
            return await _request.GetAsync<PlaceDetailResponseModel>(baseUrl + model.ToUri());


        }

        public async Task<PlaceAutoComplelteResponseModel> PlaceAutocomplete(PlaceAutoComplelteRequestModel model)
        {
            var baseUrl = $"{_baseURL}/autocomplete/json";
            return await _request.GetAsync<PlaceAutoComplelteResponseModel>(baseUrl + model.ToUri());
        }

        public async Task<Bitmap> PlacePhoto(PlacePhotoRequestModel model)
        {
            var baseUrl = $"{_baseURL}/details/json";
            var photoDetail = await _request.GetAsync<PlacePhotoResponseModel>(baseUrl + model.ToUri());
            var photoReference = photoDetail.result.photos[0].photo_reference;
            var photoModel = new PhotoRequest { MaxWidth = model.MaxWidth, Photo_reference = photoReference };
           
            return await PhotoReference(photoModel);
        }

        public async Task<Bitmap> PhotoReference(PhotoRequest photoModel)
        {
            var photoUrl = $"{_baseURL}/photo" + photoModel.ToUri();
            var photo = await _request.GetImgAsync(photoUrl);
            return photo;
        }

        public async Task<QueryAutoCompleteResponseModel> QueryAutoComplete(QueryAutoCompleteRequestModel model)
        {
            var baseUrl = $"{_baseURL}/queryautocomplete/json";
            return await _request.GetAsync<QueryAutoCompleteResponseModel>(baseUrl + model.ToUri());
        }
    }
}
