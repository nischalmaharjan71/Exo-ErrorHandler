
using BAL.Interface;
using BAL.Services;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExoErrorHandler.Controllers
{
    public class ModuleController : Controller
    {
        IErrorHandlerServices _iErrorHandlerServices;

        public ModuleController()
        {
            _iErrorHandlerServices = new ErrorHandlerServices();

        }

        // GET: Module
        public ActionResult Index()
        {
            var list = new Module();
            list.ModuleList = _iErrorHandlerServices.getModuleList();
            return View(list);
        }


        [HttpGet]
        public ActionResult AddEdit(int id)
        {
            if (id > 0)
            {

                List<Module> moduleList = _iErrorHandlerServices.GetModuleListById(id); // Assuming you have a method to retrieve the list

                var model = new Module
                {
                    ModuleId = moduleList[0].ModuleId,
                    ModuleName = moduleList[0].ModuleName,
                    ModuleDescription = moduleList[0].ModuleDescription,
                    OrganizationId = moduleList[0].OrganizationId,
                    OrganizationName = moduleList[0].OrganizationName,
                    ProjectId = moduleList[0].ProjectId,
                    ProjectName = moduleList[0].ProjectName
                };


                ViewBag.OrganizationList = new SelectList(_iErrorHandlerServices.getOrganizationList(), "OrganizationId", "OrganizationName");

                return View(model);
            }
            else

            {
                ViewBag.OrganizationList = new SelectList(_iErrorHandlerServices.getOrganizationList(), "OrganizationId", "OrganizationName");

                return View();
            }

        }
        [HttpPost]
        public ActionResult AddEdit(Module model)
        {
            if (model.ModuleId > 0)
            {
                _iErrorHandlerServices.UpdateModule(model);
            }
            else
            {
                _iErrorHandlerServices.InsertModule(model);
            }

            return RedirectToAction("Index");
        }

        public JsonResult GetProjectByOrganizationId(int organizationId)
        {

            List<Project> projectList;

            projectList = _iErrorHandlerServices.getProjectListByOrganizationId(organizationId);

            return Json(projectList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetModuleByProjectId(int organizationId, int projectId)
        {

            List<Module> moduleList;

            moduleList = _iErrorHandlerServices.getModuleListByProjectId(organizationId, projectId);

            return Json(moduleList, JsonRequestBehavior.AllowGet);
        }



        public ActionResult Delete(int id)
        {
            _iErrorHandlerServices.DeleteModule(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var list = new Module();
            list.ModuleList = _iErrorHandlerServices.GetModuleListById(id);
            return View(list);
        }

    }
}