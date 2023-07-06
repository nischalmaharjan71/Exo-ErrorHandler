using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interface
{
    public interface IErrorHandlerServices
    {
        List<Organization> getOrganizationList();
        List<Organization> GetOrganizationListById(int id);
        void InsertOrganization(Organization productModel);

        void UpdateOrganization(Organization productModel);

        void DeleteOrganization(int id);

        List<Project> getProjectList();
        void DeleteProject(int id);

        void InsertProject(Project projectModel);
        List<Project> GetProjectListBy(int id);
        void UpdateProject(Project project);


        List<Project> getProjectListByOrganizationId(int id);
        List<Module> getModuleListByProjectId(int oid, int pid);
        List<Module> getModuleList();

        void InsertModule(Module moduleModel);
        void DeleteModule(int id);
        List<Module> GetModuleListById(int id);
        void UpdateModule(Module moduleModel);


        List<User> getUserList();
        List<User> GetUserListById(int id);
        void InserUser(User user);

        void UpdateUser(User user);

        void DeleteUser(int id);

        List<Role> getRoleList();
        List<User> getDeveloperList();

        void SaveIssueError(IssueErrorView modl);
    }
}
