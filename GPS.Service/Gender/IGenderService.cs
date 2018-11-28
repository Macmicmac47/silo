using System;
using System.Collections.Generic;
using System.Text;

namespace GPS.Service.Gender
{
    public interface IGenderService
    {
        void AddGender(Core.Domain.Gender gender);
    }
}
