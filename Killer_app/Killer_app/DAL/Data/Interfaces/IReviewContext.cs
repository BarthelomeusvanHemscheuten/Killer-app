using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Killer_app.Model;

namespace Killer_app.Data
{
    interface IReviewContext
    {
        List<object[]> GetAllReviews();
        List<object[]> GetPositiveReviews();
        List<object[]> GetNegativeReviews();
        List<object[]> GetGameReviews(int id);

        bool WriteReview(string userNaam, int gameID, string titel, string description, int beoordeeling, string afbeelding);
        bool DeleteReview(int reviewID);



    }
}
