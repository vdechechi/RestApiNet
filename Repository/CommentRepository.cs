﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using RESTAPI.Data;
using RESTAPI.DTOs.Stock;
using RESTAPI.Interfaces;
using RESTAPI.Models;

namespace RESTAPI.Repository
{
    public class CommentRepository : ICommentRepository
    {

        private readonly ApplicationDbContext _context;
        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;

        }
        public async Task<Comment> CreateAsync(Comment commentModel)
        {
            await _context
                .Comments
                .AddAsync(commentModel);

            await _context.SaveChangesAsync();

            return commentModel;
        }

        public Task<Comment?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync() ;

        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<Comment?> UpdateAsync(int id, Comment commentModel)
        {
            var existingComment = await _context.Comments.FindAsync(id);

            if (existingComment == null) return null;

            existingComment.Title =  commentModel.Title;
            existingComment.Content = commentModel.Content;

            await _context.SaveChangesAsync();

            return existingComment;



        }
    }
}
