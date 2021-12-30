using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vital_BusinessLogic.Interface;
using Vital_Models;

namespace PMS_VitalSigns.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VitalSignController : ControllerBase
    {
        private readonly IVitalBusiness _vitalBusiness;
        public VitalSignController(IVitalBusiness vitalBusiness)
        {
            _vitalBusiness = vitalBusiness;
        }

        [HttpPost]
        public async Task<int> AddVital(VitalSignModel vital)
        {
            int result = 0;
            try
            {
                result = await _vitalBusiness.AddVitalSigns(vital);
            }
            catch(Exception e)
            {

            }
            return result;
        }
    }
}
