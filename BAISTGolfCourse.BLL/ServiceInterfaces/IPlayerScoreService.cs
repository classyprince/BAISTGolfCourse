using BAISTGolfCourse.ViewModels.InputModels.PlayerScore;
using BAISTGolfCourse.ViewModels.ViewModels.PlayerScore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAISTGolfCourse.BLL.ServiceInterfaces
{
    public interface IPlayerScoreService
    {
        CreateInputModel GetInputModel(string userIdentity);
        CreateInputModelWithMember GetInputModelForAdmin();
        CreateInputModel CreatePlayerScore(CreateInputModel model, string userIdentity);
        CreateInputModelWithMember CreatePlayerScore(CreateInputModelWithMember model);
        List<ReservationScoreViewModel> GetReservationsForMember(string memberID);
        ScoreReport GetWeeklyReport(string userIdentity);
        List<UserScoreViewModel> GetAllUserScores();
        List<UserScoreViewModel> GetAllUserScoresMale();
        List<UserScoreViewModel> GetAllUserScoresFemale();
    }
}
