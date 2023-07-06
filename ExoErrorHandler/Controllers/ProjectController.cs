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
    public class ProjectController : Controller
    {
        IErrorHandlerServices _iErrorHandlerServices;

        public ProjectController()
        {
            _iErrorHandlerServices = new ErrorHandlerServices();

        }

        // GET: Project
        public ActionResult Index()
        {
            var list = new Project();
            list.ProjectList = _iErrorHandlerServices.getProjectList();
            return View(list);
        }

        [HttpGet]
        public ActionResult AddEdit(int id)
        {
            if (id > 0)
            {
                List<Project> productList = _iErrorHandlerServices.GetProjectListBy(id); // Assuming you have a method to retrieve the list
                List<Organization> organizationList = _iErrorHandlerServices.getOrganizationList();

                var model = new Project
                {
                    ProjectId = productList[0].ProjectId,
                    ProjectName = productList[0].ProjectName,
                    ProjectDescription = productList[0].ProjectDescription,
                    OrganizationId = productList[0].OrganizationId,
                    OrganizationName = productList[0].OrganizationName
                };
                //int test = organizationList.FirstOrDefault(x => x.OrganizationName == productList[0].OrganizationName)?.OrganizationId;
                ViewBag.OrganizationSelectList = new SelectList(organizationList, "OrganizationId", "OrganizationName");
                return View(model);

            }
            else

            {
                ViewBag.OrganizationSelectList = new SelectList(_iErrorHandlerServices.getOrganizationList(), "OrganizationId", "OrganizationName");
                return View();
            }

        }
        [HttpPost]
        public ActionResult AddEdit(Project model)
        {


            if (model.ProjectId > 0)
            {
                _iErrorHandlerServices.UpdateProject(model);
            }
            else
            {
                _iErrorHandlerServices.InsertProject(model);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _iErrorHandlerServices.DeleteProject(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var list = new Project();
            list.ProjectList = _iErrorHandlerServices.GetProjectListBy(id);
            return View(list);
        }

    }
}