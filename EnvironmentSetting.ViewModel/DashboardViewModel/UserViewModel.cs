using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentSetting.ViewModel
{
    public class UserViewModel
    {
        public int UserID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNo { get; set; }
        public string MobNo { get; set; }
        public string FaxNo { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public int InvalidLoginCount { get; set; }
        public DateTime InvalidLoginDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public DateTime LastPasswordChangeDate { get; set; }
        public DateTime ActivatedDate { get; set; }
        public DateTime DeactivatedDate { get; set; }
        public bool SignOn { get; set; }
        public bool ResetPassword { get; set; }

        public bool Active { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
