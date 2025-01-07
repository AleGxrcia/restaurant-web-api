using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantApiV2.WebApi.Controllers;
using RestaurantWebApi.Core.Application.Dtos.Tables;
using RestaurantWebApi.Core.Application.Enums;
using RestaurantWebApi.Core.Application.Interfaces.Services;

namespace Restaurant.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Authorize(Roles = $"{nameof(Roles.Admin)},{nameof(Roles.Admin)}")]

    public class TableController : BaseApiController
    {
        private readonly ITableService _tableService;

        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(TableSaveDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var table = await _tableService.Add(dto);
                return CreatedAtAction(nameof(GetById), new { id = table.Id }, table);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TableSaveDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, TableSaveDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _tableService.Update(dto, id);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = $"{nameof(Roles.Admin)},{nameof(Roles.Waiter)}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TableDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> List()
        {
            try
            {
                var tables = await _tableService.GetAllDto();

                if (tables == null || tables.Count == 0)
                {
                    return NoContent();
                }

                return Ok(tables);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = $"{nameof(Roles.Admin)},{nameof(Roles.Waiter)}")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TableSaveDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var table = await _tableService.GetByIdSaveDto(id);

                if (table == null)
                {
                    return NoContent();
                }

                table.Status = Enum.Parse<Status>(table.Status.ToString());

                table.Status = (Status)Enum.Parse(typeof(Status), table.Status.ToString());

                return Ok(table);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = nameof(Roles.Waiter))]
        [HttpGet("tableOrders/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TableDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTableOrden(int id)
        {
            try
            {
                var table = await _tableService.GetTableOrden(id);

                if (table == null)
                {
                    return NoContent();
                }

                return Ok(table);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = nameof(Roles.Waiter))]
        [HttpPatch("ChangeStatus")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ChangeStatus(int id, Status status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                await _tableService.ChangeStatus(id, status);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);

            }
        }
    }
}
