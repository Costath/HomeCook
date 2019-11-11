using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class ReviewRepository : IReviewRepository
    {
        /// <summary>
        /// Review DB context
        /// </summary>
        private ApplicationDbContext context;

        public ReviewRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        /// <summary>
        /// Review DB table
        /// </summary>
        public IQueryable<Review> Reviews => context.Reviews;
        /// <summary>
        /// The a review in the database
        /// </summary>
        /// <param name="review"></param>
        public void SaveReview(Review review)
        {
            context.Reviews.Add(review);

            context.SaveChanges();
        }
    }
}
