using CalculateFunding.Common.ApiClient.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.IntegrationTests.Models
{
    public class UserPermission
    {
        public string UserId { get; set; }

        public string FundingStreamId { get; set; }

        public FundingStreamPermissionUpdateModel Permissions { get; set; }
    }
}
