using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MODEL
{
    public class Organization
    {
        public Organization()
        {
            OrganizationList = new List<Organization>();
        }
        public int OrganizationId { get; set; }
        [Display(Name = "Organization Name")]
        public string OrganizationName { get; set; }

        [Display(Name = "Organization Description")]
        public string OrganizationDescription { get; set; }
        [Display(Name = "Organization Address")]

        public string OrganizationAddress { get; set; }
        [Display(Name = "Organization Phone")]

        public string OrganizationPhone { get; set; }
        [Display(Name = "Contact  Person")]

        public string OrganizationContactPerson { get; set; }
        public string CreatedBy { get; set; }
        //public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        // public DateTime ModifiedDate { get; set; }

        public List<Organization> OrganizationList { get; set; }
    }
}
