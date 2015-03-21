using SE.BussinessLogic;
using SE.DataAccess;
using SE.WebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SE.WebService.Controllers
{
    public class ComminityController : ApiController
    {
        private CommunityBussinessLogic _communityBll;
        private ChinaAreaBussinessLogic _chinaBll;
        public ComminityController(CommunityBussinessLogic communityBll, ChinaAreaBussinessLogic chinaBll)
        {
            _communityBll = communityBll;
            _chinaBll = chinaBll;
        }

        /// <summary>
        /// 根据区县获取楼宇
        /// </summary>
        /// <param name="countyId"></param>
        /// <returns></returns>
        [ActionStatus(typeof(ComminityModelStatus))]
        [HttpGet]
        public ResultModel<CommunityModel[]> GetCommunities(int countyId)
        {
            var county = _chinaBll.GetChinaCounty(countyId);
            if (county == null)
            {
                return ResultModel<CommunityModel[]>.Conclude(ComminityModelStatus.CountyNotExisted);
            }
            var models = BatchTranslator<Community, CommunityModel>.Translate(county.Communities.ToList());
            return ResultModel<CommunityModel[]>.Conclude(ComminityModelStatus.Success, models.ToArray());
        }
        

    }
}