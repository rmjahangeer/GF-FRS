﻿using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using FRS.Interfaces.IServices;
using FRS.Models.ResponseModels;
using FRS.Web.ModelMappers;
using FRS.Web.Models;
using FRS.Web.Models.MT940Load;

namespace FRS.Web.Areas.Api.Controllers
{
    public class MT940LoadController : ApiController
    {

        #region Private

        private readonly ILoadService loadService;

        #endregion

        #region Constructor

        public MT940LoadController(ILoadService loadService)
        {
            this.loadService = loadService;
        }

        #endregion

        #region Public

        #region Get

        public BaseDataMT940Load Get()
        {
            MT940LoadBaseDataResponse response = loadService.GetBaseDataResponse();
            BaseDataMT940Load baseData = new BaseDataMT940Load
            {
                Loads = response.Loads.Select(x => x.CreateFromServerToClient()).ToList(),
                LoadMetadataDropDown = response.LoadMetadataDropDown
            };
            return baseData;
        }

        #endregion

        #region Post
        public bool Post(Load load)
        {
            //if (!ModelState.IsValid)
            //{
            //    throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            //}
            if (loadService != null)
            {
                try
                {
                    return true;
                    //var loadToSave = load.CreateFromClientToServer();
                    //if (loadService.SaveLoad(loadToSave))
                    //{
                    //    return true;
                    //}
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }

        #endregion

        #endregion
    }
}