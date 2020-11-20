﻿using System;
using System.Collections.Generic;
using System.Linq;
using CoachUp.DAL.Context;
using CoachUp.DAL.Entities;
using CoachUp.DAL.Interfaces;

namespace CoachUp.DAL.Repositories
{
    public class SportRepository : Repository<Sport>, IRepository<Sport>
    {
        public SportRepository(CoachUpContext context) : base(context)
        {
        }
    }
}
