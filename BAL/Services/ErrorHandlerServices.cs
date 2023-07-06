using BAL.Interface;
using DAL;
using MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public class ErrorHandlerServices : IErrorHandlerServices
    {
        private readonly ErrorEntities1 _context;
        public ErrorHandlerServices()
        {
            _context = new ErrorEntities1();
        }

        public List<Organization> getOrganizationList()
        {
            var result = _context.Database.SqlQuery<Organization>("exec SPGetOrganization").ToList();
            return result;
        }



        public List<Organization> GetOrganizationListById(int id)
        {
            var organizationId = new SqlParameter("@OrganizationId", id);
            string sql = "exec SpGetOrganizationById @OrganizationId";
            var result = _context.Database.SqlQuery<Organization>(sql, organizationId).ToList();
            return result;
        }




        public void InsertOrganization(Organization organizationModel)
        {
            try
            {
                string sql = "Exec SpInsertOrganization @OrganizationName,@OrganizationDescription,@OrganizationAddress,@OrganizationPhone,@OrganizationContactPerson";
                var organizationName = new SqlParameter("@OrganizationName", organizationModel.OrganizationName);
                var organizationDescription = new SqlParameter("@OrganizationDescription", organizationModel.OrganizationDescription);
                var organizationAddress = new SqlParameter("@OrganizationAddress", organizationModel.OrganizationAddress);
                var organizationPhone = new SqlParameter("@OrganizationPhone", organizationModel.OrganizationPhone);
                var organizationContactPerson = new SqlParameter("@OrganizationContactPerson", organizationModel.OrganizationContactPerson);
                _context.Database.ExecuteSqlCommand(sql, organizationName, organizationDescription, organizationAddress, organizationPhone, organizationContactPerson);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }





        public void UpdateOrganization(Organization organizationModel)
        {
            try
            {
                string sql = "Exec SpUpdateOrganization @OrganizationId,@OrganizationName,@OrganizationDescription,@OrganizationAddress,@OrganizationPhone,@OrganizationContactPerson";
                var organizationId = new SqlParameter("@OrganizationId", organizationModel.OrganizationId);
                var organizationName = new SqlParameter("@OrganizationName", organizationModel.OrganizationName);
                var organizationDescription = new SqlParameter("@OrganizationDescription", organizationModel.OrganizationDescription);
                var organizationAddress = new SqlParameter("@OrganizationAddress", organizationModel.OrganizationAddress);
                var organizationPhone = new SqlParameter("@OrganizationPhone", organizationModel.OrganizationPhone);
                var organizationContactPerson = new SqlParameter("@OrganizationContactPerson", organizationModel.OrganizationContactPerson);
                _context.Database.ExecuteSqlCommand(sql, organizationId, organizationName, organizationDescription, organizationAddress, organizationPhone, organizationContactPerson);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
        public void DeleteOrganization(int id)
        {
            string sql = "EXEC SpDeleteOrganization @OrganizationId";
            var organizationId = new SqlParameter("@OrganizationId", id);
            _context.Database.ExecuteSqlCommand(sql, organizationId);

        }

        public List<Project> getProjectList()
        {
            var result = _context.Database.SqlQuery<Project>("exec SPGetProject").ToList();
            return result;
        }

        public void InsertProject(Project projectModel)
        {
            try
            {
                string sql = "Exec SpInsertProject @ProjectName,@ProjectDescription,@OrganizationId";
                var projectName = new SqlParameter("@ProjectName", projectModel.ProjectName);
                var projectDescription = new SqlParameter("@ProjectDescription", projectModel.ProjectDescription);
                var organizationId = new SqlParameter("@OrganizationId", projectModel.OrganizationId);

                _context.Database.ExecuteSqlCommand(sql, projectName, projectDescription, organizationId);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public void DeleteProject(int id)
        {
            string sql = "EXEC SpDeleteProject @ProjectId";
            var projectId = new SqlParameter("@ProjectId", id);
            _context.Database.ExecuteSqlCommand(sql, projectId);
        }

        public List<Project> GetProjectListBy(int id)
        {
            var projectId = new SqlParameter("@ProjectId", id);
            string sql = "exec SpGetProjectById @ProjectId";
            var result = _context.Database.SqlQuery<Project>(sql, projectId).ToList();
            return result;
        }

        public void UpdateProject(Project projectModel)
        {
            try
            {
                string sql = "Exec SpUpdateProject @ProjectId,@ProjectName,@ProjectDescription,@OrganizationId";
                var projectName = new SqlParameter("@ProjectName", projectModel.ProjectName);
                var projectDescription = new SqlParameter("@ProjectDescription", projectModel.ProjectDescription);
                var organizationId = new SqlParameter("@OrganizationId", projectModel.OrganizationId);
                var projectId = new SqlParameter("@ProjectId", projectModel.ProjectId);

                _context.Database.ExecuteSqlCommand(sql, projectId, projectName, projectDescription, organizationId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<Module> getModuleList()
        {
            var result = _context.Database.SqlQuery<Module>("exec SpGetModule").ToList();
            return result;
        }

        public List<Project> getProjectListByOrganizationId(int id)
        {
            string sql = "EXEC SpGetProjectListByOrganizationId @OrganizationId";
            var organizationId = new SqlParameter("@OrganizationId", id);
            var result = _context.Database.SqlQuery<Project>(sql, organizationId).ToList();
            return result;
        }

        public List<Module> getModuleListByProjectId(int oid, int pid)
        {
            try
            {
                string sql = "EXEC SpGetModuleListByProjectId @OrganizaitonId,@ProjectId";
                var organizationId = new SqlParameter("@OrganizaitonId", oid);
                var projectId = new SqlParameter("@ProjectId", pid);
                var result = _context.Database.SqlQuery<Module>(sql, organizationId, projectId).ToList();
                return result;
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

        public void InsertModule(Module moduleModel)
        {
            try
            {
                string sql = "Exec SpInsertModule @ModuleName,@ModuleDescription,@ProjectId,@OrganizationId";
                var moduleName = new SqlParameter("@ModuleName", moduleModel.ModuleName);
                var moduleDescription = new SqlParameter("@ModuleDescription", moduleModel.ModuleDescription);
                var projectId = new SqlParameter("@ProjectId", moduleModel.ProjectId);
                var organizationId = new SqlParameter("@OrganizationId", moduleModel.OrganizationId);

                _context.Database.ExecuteSqlCommand(sql, moduleName, moduleDescription, projectId, organizationId);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public void DeleteModule(int id)
        {
            string sql = "EXEC SpDeleteModule @ModuleId";
            var moduleId = new SqlParameter("@ModuleId", id);
            _context.Database.ExecuteSqlCommand(sql, moduleId);
        }

        public List<Module> GetModuleListById(int id)
        {
            var moduleId = new SqlParameter("@ModuleId", id);
            string sql = "exec SpGetModuleById @ModuleId";
            var result = _context.Database.SqlQuery<Module>(sql, moduleId).ToList();
            return result;
        }

        public void UpdateModule(Module moduleModel)
        {
            try
            {
                string sql = "Exec SpUpdateModule @ModuleId,@ModuleName,@ModuleDescription,@ProjectId,@OrganizationId";
                var moduleId = new SqlParameter("@ModuleId", moduleModel.ModuleId);
                var moduleName = new SqlParameter("@ModuleName", moduleModel.ModuleName);
                var moduleDescription = new SqlParameter("@ModuleDescription", moduleModel.ModuleDescription);
                var projectId = new SqlParameter("@ProjectId", moduleModel.ProjectId);
                var organizationId = new SqlParameter("@OrganizationId", moduleModel.OrganizationId);


                _context.Database.ExecuteSqlCommand(sql, moduleId, moduleName, moduleDescription, projectId, organizationId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<User> getUserList()
        {
            var result = _context.Database.SqlQuery<User>("exec SpGetUser").ToList();
            return result;
        }



        public List<User> GetUserListById(int id)
        {
            var UserId = new SqlParameter("@UserId", id);
            string sql = "exec SpGetUserById @UserId";
            var result = _context.Database.SqlQuery<User>(sql, UserId).ToList();
            return result;
        }



        public void DeleteUser(int id)
        {
            string sql = "EXEC SpUserDelete @UserId";
            var UserId = new SqlParameter("@UserId", id);
            _context.Database.ExecuteSqlCommand(sql, UserId);

        }

        public void InserUser(User user)
        {
            try
            {
                string sql = "Exec SpInsertUser @FullName,@Email,@Username,@Pass,@RoleId";
                var fullName = new SqlParameter("@FullName", user.FullName);
                var email = new SqlParameter("@Email", user.Email);
                var userName = new SqlParameter("@UserName", user.UserName);
                var password = new SqlParameter("@Pass", user.Password);
                var roleId = new SqlParameter("@RoleId", user.RoleId);

                _context.Database.ExecuteSqlCommand(sql, fullName, email, userName, password, roleId);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public void UpdateUser(User user)
        {
            try
            {
                string sql = "Exec SpUpdateuser  @UserId,@FullName,@Email,@Username,@Pass, @RoleId";
                var UserId = new SqlParameter("@UserId", user.UserId);
                var FullName = new SqlParameter("@FullName", user.FullName);
                var Email = new SqlParameter("@Email", user.Email);
                var UserName = new SqlParameter("@UserName", user.UserName);
                var Password = new SqlParameter("@Pass", user.Password);
                var roleId = new SqlParameter("@RoleId", user.RoleId);
                _context.Database.ExecuteSqlCommand(sql, UserId, FullName, Email, UserName, Password, roleId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }




        public List<Role> getRoleList()
        {
            var result = _context.Database.SqlQuery<Role>("exec SpGetRole").ToList();
            return result;
        }



        public List<User> getDeveloperList()
        {
            var result = _context.Database.SqlQuery<User>("exec SpGetDeveloper").ToList();
            return result;
        }

        public void SaveIssueError(IssueErrorView modl)
        {
            try
            {
                string sql = "Exec SpSaveIssueError @OrganizationId ,@ProjectId ,@ModuleId, @UserId, @Image ";
                var organizationId = new SqlParameter("@OrganizationId", modl.OrganizationId);
                var projectId = new SqlParameter("@ProjectId", modl.ProjectId);
                var moduleId = new SqlParameter("@ModuleId", modl.ModuleId);
                var userId = new SqlParameter("@UserId", modl.UserId);
                var image = new SqlParameter("@Image", modl.ImagePath);

                _context.Database.ExecuteSqlCommand(sql, organizationId, projectId, moduleId,  userId, image);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
    }
}
