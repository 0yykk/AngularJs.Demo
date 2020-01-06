using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Demo.Domain;
using Demo.Provider.Provider;

namespace AngularJs.Demo.Controllers
{
    [RoutePrefix("api/Album")] 
    public class AlbumController : ApiController
    {
        private readonly IAlbumProvider _albumProvider;
        public AlbumController(IAlbumProvider albumProvider)
        {
            _albumProvider = albumProvider;
        }

        [HttpGet]
        [Route("GetAllAlbumAsync")]
        public async Task<List<AlbumViewModel>> GetAllAlbumAsync()
        {
            var albumlist = new List<AlbumViewModel>();
            albumlist = await _albumProvider.GetAllAlbumAsync();
            return albumlist;
        }
        //[HttpGet]
        //[Route("GetAllAlbum")]
        //public List<AlbumViewModel> GetAllAlbum()
        //{
        //    var albumlist = new List<AlbumViewModel>();
        //    albumlist =  _albumProvider.GetAllAlbum();
        //    return albumlist;
        //}
        [HttpGet]
        [Route("details/{id}")]
        public async Task<AlbumViewModel> GetAlbumById(int id)
        {
            var album = new AlbumViewModel();
            album = await _albumProvider.GetAlbumById(id);
            return album;
        }
    }
}
