using GPS.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPS.Service.CareTeam
{
    public interface ICareTeamService
    {
        IList<CareTeamMemberView> GetTeamMembersInitialInformation(string key, string value);
        void AddnewTeamMember(CareTeamMemberView member);
    }
}
