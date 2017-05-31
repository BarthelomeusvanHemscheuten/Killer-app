using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Killer_app.Data;
using Killer_app.Model;

namespace Killer_app.Logic
{
    class ReviewRepository
    {
        private IReviewContext context;
        public ReviewRepository(IReviewContext context)
        {
            this.context = context;
        }

        public List<Review> GetAllReviews()
        {
            List<Review> reviews = new List<Review>();
            List<object[]> data = context.GetAllReviews();
            foreach (object[] review_data in data)
            {
                reviews.Add(SetReview(review_data));
            }
            return reviews;
        }
        public List<Review> GetAllPositiveReview()
        {
            List<Review> reviews = new List<Review>();
            List<object[]> data = context.GetPositiveReviews();
            foreach (object[] review_data in data)
            {
                reviews.Add(SetReview(review_data));
            }
            return reviews;
        }
        public List<Review> GetAllNegativeReview()
        {
            List<Review> reviews = new List<Review>();
            List<object[]> data = context.GetNegativeReviews();
            foreach (object[] review_data in data)
            {
                reviews.Add(SetReview(review_data));
            }
            return reviews;
        }
        public List<Review> GetGameReviews(int id)
        {
            List<Review> reviews = new List<Review>();
            List<object[]> data = context.GetGameReviews(id);
            foreach (object[] review_data in data)
            {
                reviews.Add(SetReview(review_data));
            }
            return reviews;
        }
        public bool WriteReview(string userNaam, int gameID, string titel, string description, int beoordeeling, string afbeelding)
        {
            return context.WriteReview(userNaam, gameID, titel, description, beoordeeling, afbeelding);
        }
        public bool DeleteReview(int reviewID)
        {
            return context.DeleteReview(reviewID);
        }
        private Review SetReview(object[] data)
        {
            return new Review((int)data[0], (string)data[1], (int)data[2], (string)data[3], (int)data[4], (string)data[5], (string)data[6]);
        }


    }
}
