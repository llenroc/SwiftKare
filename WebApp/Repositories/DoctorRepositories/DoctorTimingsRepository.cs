﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Interfaces;
using DataAccess;
using WebApp.Helper;
using Newtonsoft.Json;

namespace WebApp.Repositories.DoctorRepositories
{
    class DoctorTimingsRepository : IRepository<DoctorTiming>
    {
        public DoctorTiming Add(DoctorTiming t)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(object id)
        {
            throw new NotImplementedException();
        }

        public DoctorTiming Find(object id)
        {
            throw new NotImplementedException();
        }

        public DoctorTiming GetById(long id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<DoctorTiming> GetList()
        {
            throw new NotImplementedException();
        }
        public IQueryable<DoctorTiming> GetListByDoctorId(long doctorId)
        {
            var response = ApiConsumerHelper.GetResponseString("api/DoctorTimings?doctorId=" + doctorId);
            var result = JsonConvert.DeserializeObject<IQueryable<DoctorTiming>>(response);
            return result;
        }

        public DoctorTiming Put(long id, DoctorTiming t)
        {
            throw new NotImplementedException();
        }
    }
}