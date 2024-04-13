﻿using MetamodulTradeApp.Core.Exceptions;
using MetamodulTradeApp.Core.Models.Post;
using MetamodulTradeApp.Core.Models.Product;
using MetamodulTradeApp.Core.Services.Contracts;
using MetamodulTradeApp.Data;
using MetamodulTradeApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace MetamodulTradeApp.Core.Services
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext context;

        public PostService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task AddPostAsync(PostFormViewModel model)
        {
            Post post = new Post()
            {
                Title = model.Title,
                CreatedOn = DateTime.Now,
                CreatorId = model.CreatorId,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
            };

            await context.Posts.AddAsync(post);
            await context.SaveChangesAsync();
        }

        public async Task EditPostAsync(PostFormViewModel model ,int id)
        {
            Post? post = await context.Posts.FindAsync(id);

            if (post != null)
            {
                post.Title = model.Title;
                post.Description = model.Description;
                post.ImageUrl = model.ImageUrl;

                await context.SaveChangesAsync();
            }
            else
            {
                throw new NullEntityModelException("Post entity model is null!");
            }

        }

        public async Task<PostAllViewModel> GetAllPostsAsync(
            string searchTerm = "",
            int itemsPerPage = 0,
            int currentPage = 0
            )
        {

            var posts = context.Posts
                .AsNoTracking()
                .Select(p => new PostServiceModel()
                {
                    Id = p.Id,
                    ImageUrl = p.ImageUrl,
                    CreatedOn = p.CreatedOn.ToString(),
                    Title = p.Title,
                    Creator = p.Creator.UserName
                });

            var filteredPosts = await GetAllFilteredPostsAsync(searchTerm, currentPage, itemsPerPage, posts);


            return new PostAllViewModel()
            {
                Posts = filteredPosts == null ? posts : filteredPosts,
                CurrentPage = currentPage,
                TotalPostsCount = posts.Count()
            };
        }

        public async Task<PostDetailsViewModel?> GetDetailsAsync(int id)
        {
            return await context.Posts
                .AsNoTracking()
                .Where(p => p.Id == id)
                .Select(p => new PostDetailsViewModel()
                {
                    Id = p.Id,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    CreatedOn = p.CreatedOn.ToString(),
                    Title = p.Title,
                    Creator = p.Creator.UserName,
                    Comments = p.Comments.Select(c => new Models.Comment.CommentAllViewModel()
                    {
                        Id = c.Id,
                        CreatedOn = c.CreatedOn.ToString(),
                        CreatorId = c.CreatorId,
                        Text = c.Text,
                        PostId = c.PostId
                    })
                    .ToList()
                })
                .FirstOrDefaultAsync();
                
        }

        public async Task<PostDetailsViewModel?> GetPostByIdAsync(int id)
        {
            return await context.Posts
                .Where(p => p.Id == id)
                .Select(p => new PostDetailsViewModel()
                {
                    Id = p.Id,
                    ImageUrl = p.ImageUrl,
                    CreatedOn = p.CreatedOn.ToString(),
                    Title = p.Title,
                    Description = p.Description,
                    Creator = p.Creator.UserName,
                })
                .FirstOrDefaultAsync();
        }

        public async Task RemovePostAsync(int id)
        {
            Post? post = await context.Posts.FindAsync(id);

            if (post != null)
            {
                context.Posts.Remove(post);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new NullEntityModelException("Post entity model is null!");
            }
    
        }


        private async Task<List<PostServiceModel>?> GetAllFilteredPostsAsync(
         string? searchTerm,
         int currentPage,
         int itemsPerPage,
         IQueryable<PostServiceModel> posts)
        {
            var normalisedSearchTerm = searchTerm?.ToLower();
            List<PostServiceModel>? filteredPosts = null;

            if (normalisedSearchTerm != null)
            {
                 filteredPosts = await posts
                  .Where(p => p.Title.ToLower().Contains(normalisedSearchTerm))
                  .Skip((currentPage - 1) * itemsPerPage)
                  .Take(itemsPerPage)
                  .ToListAsync();
            }

            return filteredPosts;
        }


    }
}
