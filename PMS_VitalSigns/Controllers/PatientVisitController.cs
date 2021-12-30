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
    public class PatientVisitController : ControllerBase
    {
        private readonly IPatientVisitBusiness _patientVisitBusiness;
        public PatientVisitController(IPatientVisitBusiness patientVisitBusiness)
        {
            _patientVisitBusiness = patientVisitBusiness;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Physician,Nurse")]
        public async Task<VisitDetailsModel> Get()
        {
            try
            {
                return await _patientVisitBusiness.GetAll();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<VisitDetailsModel> Get(int id)
        {
            try
            {
                return await _patientVisitBusiness.GetByPatientId(id);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<bool> Post(PatientVisitModel treatmentDetails)
        {
            try
            {
                return await _patientVisitBusiness.AddPatientTreatmentDetails(treatmentDetails);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPut]
        public async Task<bool> Put(PatientVisitModel treatmentDetails)
        {
            try
            {
                return await _patientVisitBusiness.UpdatePatientTreatmentDetails(treatmentDetails);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
