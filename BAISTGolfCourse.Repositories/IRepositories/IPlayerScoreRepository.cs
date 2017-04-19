﻿using BAISTGolfCourse.Data.Models;
using BAISTGolfCourse.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAISTGolfCourse.Repositories.IRepositories
{
    public interface IPlayerScoreRepository: IRepository<PlayerScore>
    {
        List<PlayerScore> GetAllPlayerScores();
    }
}
