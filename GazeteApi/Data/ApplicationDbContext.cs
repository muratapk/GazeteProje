﻿using Microsoft.EntityFrameworkCore;

namespace GazeteApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        //costuctor nesne bu nedemek çağır çağırmaz otomatik database bağlanacak
        //public ApplicationDbContext() { }
        public ApplicationDbContext()
        {
        }
    }
}
