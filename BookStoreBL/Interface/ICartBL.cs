﻿using BookStoreRL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBL.Interface
{
    public interface ICartBL
    {
        Cart AddBookToCart(string userId, string bookId);
    }
}