﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TodoItems.Core;
using ToDoList.Api.Models;
using ToDoList.Api.Services;

namespace ToDoList.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v2/[controller]")]
    [AllowAnonymous]
    public class ToDoItemsV2Controller : ControllerBase
    {

        private readonly ITodoItemService _toDoItemService;
        private readonly ILogger<ToDoItemsV2Controller> _logger;


        public ToDoItemsV2Controller(ITodoItemService toDoItemService, ILogger<ToDoItemsV2Controller> logger)
        {
            _toDoItemService = toDoItemService;
            _logger = logger;

        }



        [HttpPost]
        [ProducesResponseType(typeof(ToDoItemDto), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [SwaggerOperation(
            Summary = "Create New Item",
            Description = "Create a new to-do item"
            )]

        public async Task<ActionResult<ToDoItemDto>> PostAsync([FromBody] ToDoItemCreateRequest toDoItemCreateRequest)
        {
            var toDoItemDto = new ToDoItemDto
            {
                Description = toDoItemCreateRequest.Description,
                Done = toDoItemCreateRequest.Done,
                Favorite = toDoItemCreateRequest.Favorite,
                CreatedTime = DateTime.Now
        };
            TodoItemDto mappedTodoItem = ToDoItemDto.MapToTodoItemDto(toDoItemDto);

            await _toDoItemService.CreateItem(mappedTodoItem);
            return toDoItemDto;
        }

    }
}
