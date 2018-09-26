using Harman.Data.Entity.Entities;
using Harman.Data.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Harman.Data.Entity.Mapper
{
    public abstract class AbstractMapper
    {
        public virtual  IEnumerable<PatientEntity> MapEntity()
        {
            throw new NotImplementedException();
        }        

    }
}
