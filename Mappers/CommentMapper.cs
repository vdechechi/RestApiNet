﻿using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using RESTAPI.DTOs.Comment;
using RESTAPI.DTOs.Stock;
using RESTAPI.Models;

namespace RESTAPI.Mappers
{
    public static class CommentMapper
    {
     public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {   
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn,
                StockId = commentModel.StockId,


            };
        }

        public static Comment ToCommentFromCreate(this CreateCommentRequestDto commentDto, int stockId)
        {
            return new Comment
            {
               Title = commentDto.Title,
               Content = commentDto.Content,
               StockId = stockId,

            };  
        }
    }
}
