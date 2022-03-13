using FileManagement.API.Infrastructure.Filters;
using FileManagement.Core.Dtos;
using FileManagement.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileManagement.API.Controllers
{
    public class FileManagementController : ControllerBase
    {
        private readonly IFileService _fileService;
        public FileManagementController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet("GetFile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFile(Guid referenceNumber)
        {
            var result = await _fileService.GetFileInfo(referenceNumber);

            return Ok(result);
        }

        [HttpGet("GetFileContent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFileContent(Guid referenceNumber)
        {
            var result = await _fileService.GetFileContent(referenceNumber);

            return Ok(result);
        }

        [HttpGet("GetFileContentByPath")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFileContentByPath(string path)
        {
            var result = await _fileService.GetFileContent(path);

            return Ok(result);
        }


        [HttpPost("AddFile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ModelValidationAttribute]
        public async Task<IActionResult> AddFile(CreateFileDto createFileDto)
        {
                var result = await _fileService.AddFile(createFileDto);

            return Ok( new {Reference_Number = result });
        }

        [HttpDelete("DeleteFile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteFile(Guid referenceNumber)
        {
            var result = await _fileService.DeleteFile(referenceNumber);

            return Ok(result);
        }
    }
}
