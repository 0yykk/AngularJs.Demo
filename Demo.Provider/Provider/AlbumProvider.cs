﻿using Demo.Data.Respositories;
using Demo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Provider.Provider
{
    public interface IAlbumProvider
    {
        Task<List<AlbumViewModel>> GetAllAlbumAsync();
        List<AlbumViewModel> GetAllAlbum();
        void UpdateAlbum(AlbumViewModel albumViewModel);
        Task<AlbumViewModel> GetAlbumByTittle(string title);
        Task<List<AlbumViewModel>> GetAlbumByGenre(string genreName);
        Task<List<AlbumViewModel>> GetAlbumByArtist(string artist);
        Task<AlbumViewModel> GetAlbumById(int id);
        Task<List<AlbumViewModel>> GetAlbumByDate(DateTime date);
        int DeleteAlbum(int id);
    }
    public class AlbumProvider:IAlbumProvider
    {
        private readonly IAlbumRespository _albumRespository;
        public AlbumProvider(IAlbumRespository albumRespository)
        {
            _albumRespository = albumRespository;
        }
        public async Task<List<AlbumViewModel>> GetAllAlbumAsync()
        {
            var searchVm = new List<AlbumViewModel>();
             searchVm=await _albumRespository.GetAllAlbumAsync();
            return searchVm;
        }
        public List<AlbumViewModel> GetAllAlbum()
        {
            var searchVm = new List<AlbumViewModel>();
            searchVm = _albumRespository.GetAllAlbum();
            return searchVm;
        }
        public void UpdateAlbum(AlbumViewModel albumViewModel)
        {
            _albumRespository.UpdateAlbum(albumViewModel);
        }
        public async Task<AlbumViewModel> GetAlbumByTittle(string title)
        {
            try
            {
                var album = new AlbumViewModel();
                album = await _albumRespository.GetAlbumByTittle(title);
                return album;
            }
            catch(Exception ex)
            {
                return new AlbumViewModel();
            }
        }
        public async Task<List<AlbumViewModel>> GetAlbumByDate(DateTime date)
        {
            try
            {
                var alist = new List<AlbumViewModel>();
                alist = await _albumRespository.GetAlbumByDate(date);
                return alist;
            }
            catch(Exception ex)
            {
                return new List<AlbumViewModel>();
            }
        }
        public async Task<List<AlbumViewModel>> GetAlbumByGenre(string genreName)
        {
            try
            {
                var albumList = new List<AlbumViewModel>();
                albumList = await _albumRespository.GetAlbumByGenre(genreName);
                return albumList;
            }
            catch(Exception ex)
            {
                return new List<AlbumViewModel>();
            }
            
        }
        public async Task<List<AlbumViewModel>> GetAlbumByArtist(string artist)
        {
            try
            {
                var albumList = new List<AlbumViewModel>();
                albumList = await _albumRespository.GetAlbumByArtist(artist);
                return albumList;
            }
            catch(Exception ex)
            {
                return new List<AlbumViewModel>();
            }
        }
        public async Task<AlbumViewModel> GetAlbumById(int id)
        {
            var album = new AlbumViewModel();
            album = await _albumRespository.GetAlbumById(id);
            return album;
        }
        public int DeleteAlbum(int id)
        {
            int returnValue;
            returnValue = _albumRespository.DeleteAlbum(id);
            return returnValue;
        }
    }
    
}
