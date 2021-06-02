﻿using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Repository
{
    public interface ICivilStateRepository
    {
        CivilState Get(int id);

        CivilState GetByName(string name);

        List<CivilState> GetAll();

        List<CivilState> GetOnlyActives();

        int Save(CivilState civilState);

        bool Delete(int id);
    }
}
