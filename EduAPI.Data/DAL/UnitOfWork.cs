﻿using EduAPI.Data.Context;
using EduAPI.Data.DAL.Interfaces;
using EduAPI.Data.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduAPI.Data.DAL
{
    public class UnitOfWork
    {
        private EduContext _context;

        public IAuthorRepository Authors { get; }
        //public IMaterialRepository Materials { get; }
        //public IMatTypeRepository Types { get; }
        //public IReviewRepository Reviews { get; }

        public UnitOfWork(EduContext context)
        {
            _context = context;
            Authors = new AuthorRepository(_context);
            //Materials = new MaterialRepository(_context);
            //Types = new MatTypeRepository(_context);
            //Seasons = new SeasonRepository(_context);
            //Reviews = new ReviewRepository(_context);
        }

        public async Task<int> CompleteUnitAsync()
            => await _context.SaveChangesAsync();
    }
}
