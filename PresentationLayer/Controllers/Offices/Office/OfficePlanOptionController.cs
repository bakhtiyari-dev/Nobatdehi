﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.DTO;

namespace PresentationLayer.Controllers.Offices.OfficePlanOption
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]

    public class OfficePlanOptionController : ControllerBase
    {
        private BusinessLogicLayer.BLOffices.OfficePlanOption _blOfficePlanOption;
        private BusinessLogicLayer.BLOffices.Office _blOffice;
        private BusinessLogicLayer.BLPlans.Plan _blPlan;
        private BusinessLogicLayer.BLOffices.WeekPlan _blWeek;
        private BusinessLogicLayer.BLTurns.TurnPool _blPool;
        private BusinessLogicLayer.Application.ApplicationMethods _application;
        public OfficePlanOptionController()
        {
            _blOfficePlanOption = new BusinessLogicLayer.BLOffices.OfficePlanOption();
            _blOffice = new BusinessLogicLayer.BLOffices.Office();
            _blPlan = new BusinessLogicLayer.BLPlans.Plan();
            _blWeek = new BusinessLogicLayer.BLOffices.WeekPlan();
            _blPool = new BusinessLogicLayer.BLTurns.TurnPool();
            _application = new BusinessLogicLayer.Application.ApplicationMethods();
        }

        [HttpGet("{officeId}/{planId}")]
        public EntityModel.Offices.OfficePlanOption? GetOfficePlanOption(int officeId, int planId)
        {
            return _blOfficePlanOption.Get(officeId, planId);
        }

        [HttpGet]
        public ActionResult<List<EntityModel.Offices.OfficePlanOption>?> GetOfficePlanOptionList([FromQuery] PaginationDto pagination)
        {
            var officePlans = _blOfficePlanOption.GetAll();

            if (officePlans != null)
            {
                try
                {
                    var result = _application.GetPaginatedResult(officePlans, pagination.PageNumber, pagination.PageSize);
                    return Ok(result);
                }
                catch (ArgumentException ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            return NotFound("NotFound Any OfficePlanOptions");
        }

        [HttpPost]
        public ActionResult<EntityModel.Offices.OfficePlanOption> CreateOfficePlanOption(int officeId, int planId, [FromQuery] opoDto opo)
        {
            var planOption = _blPlan.GetPlanOption(planId);
            var office = _blOffice.Get(officeId);
            var plan = _blPlan.GetPlan(planId);

            if (_blOfficePlanOption.Get(officeId, planId) == null)
            {
                if (office != null && office.Status != false && plan != null && plan.Status != false)
                {
                    if (opo.FromDate >= planOption.FromDate && opo.ToDate <= planOption.ToDate)
                    {
                        EntityModel.Offices.OfficePlanOption officePlanOption = new EntityModel.Offices.OfficePlanOption();

                        officePlanOption.FromDate = opo.FromDate;
                        officePlanOption.ToDate = opo.ToDate;
                        officePlanOption.Capacity = opo.Capacity;
                        officePlanOption.Status = true;

                        _blOfficePlanOption.Create(office, plan, officePlanOption);

                        return Ok("OPO Was Added Successfully");
                    }
                    else
                    {
                        return Conflict("Selected Date Times Has Conflict With Plan Date Range");
                    }
                }
                else
                {
                    return NotFound("Office Or Plan Was Not Found");
                }

            }

            return Conflict("There Are OPO For This Office And Plan");
        }

        [HttpPut]
        public ActionResult<EntityModel.Offices.OfficePlanOption>? UpdateOfficePlanOption(int officeId, int planId, [FromQuery] uopoDto uopo)
        {
            var officePlan = _blOfficePlanOption.Get(officeId, planId);
            var planOption = _blPlan.GetPlanOption(planId);

            if (officePlan != null)
            {
                if (officePlan.Status)
                {
                    if (officePlan.FromDate >= planOption.FromDate && officePlan.ToDate <= planOption.ToDate)
                    {
                        officePlan.FromDate = uopo.FromDate ?? officePlan.FromDate;
                        officePlan.ToDate = uopo.ToDate ?? officePlan.ToDate;
                        officePlan.Capacity = uopo.Capacity ?? officePlan.Capacity;

                        _blOfficePlanOption.Update(officeId, planId, officePlan);

                        return Ok(_blOfficePlanOption.Get(officeId, planId));
                    }
                    else
                    {
                        return Conflict("Selected Date Times Has Conflict With Plan Date Range");
                    }
                }
                else
                {
                    return Conflict("this Office Plan Option has disabled!");
                }
            }
            return NotFound("OPO Was Not Found");
        }

        [HttpDelete]
        public ActionResult<EntityModel.Offices.OfficePlanOption>? DeleteOfficePlanOption(int officeId, int planId)
        {
            var officePlan = _blOfficePlanOption.Get(officeId, planId);

            if (officePlan != null && officePlan.Status != false)
            {
                var check = _blWeek.GetWeekPlan(officePlan.Id);

                if (check != null)
                {
                    _blWeek.Delete(check);

                    if (_blPool.isOpoExist(officePlan.Id))
                    {
                        _blPool.Delete(officePlan.Id);
                    }
                }

                _blOfficePlanOption.Delete(officeId, planId);

                return Ok("OPO Was Desabled Successfully");
            }

            return NotFound("OPO Was Not Found");
        }
    }
}

