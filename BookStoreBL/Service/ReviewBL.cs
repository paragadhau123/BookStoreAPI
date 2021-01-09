using BookStoreBL.Interface;
using BookStoreRL;
using BookStoreRL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBL.Service
{
    public class ReviewBL :IReviewBL
    {
        public IReviewRL reviewRL;
        public ReviewBL(IReviewRL reviewRL)
        {
            this.reviewRL = reviewRL;
        }

        public review AddReview(string bookId, string userId, review review)
        {
            return this.reviewRL.AddReview(bookId, userId, review);
        }

        public List<review> getReview(string bookId)
        {
            return this.reviewRL.getReview(bookId);
        }
    }
}
