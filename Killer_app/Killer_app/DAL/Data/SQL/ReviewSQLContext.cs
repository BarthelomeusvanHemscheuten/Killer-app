using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Killer_app.Model;
namespace Killer_app.Data
{
    class ReviewSQLContext : IReviewContext
    {
        Database database;

        public ReviewSQLContext()
        {
            database = new Database();
        }
        public List<object[]> GetAllReviews()
        {
            string query = @"SELECT * FROM [Review]";
            return database.ExecuteReaderListObject(query);
        }
        public List<object[]> GetPositiveReviews()
        {
            string query = @"SELECT * FROM [Review] WHERE [Beoordeeling] > 5";
            return database.ExecuteReaderListObject(query);
        }
        public List<object[]> GetNegativeReviews()
        {
            string query = @"SELECT * FROM [Review] WHERE [Beoordeeling] < 6";
            return database.ExecuteReaderListObject(query);
        }
        public List<object[]> GetGameReviews(int id)
        {
            string query = @"SELECT * FROM [Review] WHERE [Game-ID] = @id";
            query = query.Replace("@id", id.ToString());
            return database.ExecuteReaderListObject(query);
        }

        public bool WriteReview(string userNaam, int gameID, string titel, string description, int beoordeeling, string afbeelding)
        {
            string query = @"INSERT INTO [Review]([User-Naam], [Game-ID], [Descriptie], [Beoordeeling], [Afbeelding], [Titel]) VALUES ('@userNaam', @gameID, '@descriptie', @beoordeeling, '@afbeelding', '@titel')";
            query = query.Replace("@userNaam", userNaam)
                .Replace("@gameID", gameID.ToString())
                .Replace("@descriptie", description)
                .Replace("@beoordeeling", beoordeeling.ToString())
                .Replace("@afbeelding", afbeelding)
                .Replace("@titel", titel);
            return database.ExecuteNonQuery(query);
        }
        public bool DeleteReview(int reviewID)
        {
            string query = @"DELETE FROM [Review] WHERE [Review-ID] = @reviewID";
            query = query.Replace("@reviewID", reviewID.ToString());
            return database.ExecuteNonQuery(query);
        }


    }
}
