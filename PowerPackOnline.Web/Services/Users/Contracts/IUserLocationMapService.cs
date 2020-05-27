using PowerPack.Models;
using PowerPackOnline.Web.EditModels;
using PowerPackOnline.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PowerPackOnline.Web.Services
{
    /// <summary>
    /// Author : Tejal Chaudhari
    /// Created Date : 16-JUN-2019
    /// </summary>
    public interface IUserLocationMapService
    {
        IEnumerable<UserLocationMap> GetUserLocationMapsByUserId(int id);
        bool InsertUserLocationMaps(IEnumerable<UserLocationMap> userLocationMapEdit);
    }
}