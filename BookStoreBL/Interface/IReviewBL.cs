using BookStoreRL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBL.Interface
{
   public interface IReviewBL
    {
        public review AddReview(string bookId, string userId, review review);
        public List<review> getReview(string bookId);
    }
}
