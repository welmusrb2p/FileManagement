using FileManagement.Application.Commands;
using FileManagement.Application.Commands.Delete;
using FileManagement.Application.Queries;
using FileManagement.Application.Queries.GetFileContent;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FileManagement.API.Controllers
{
    public class FileManagementController : BaseController
    {
        //private readonly IFileService _fileService;
        //public FileManagementController(IFileService fileService)
        //{
        //    _fileService = fileService;
        //}

        [HttpGet("GetFile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFile(Guid referenceNumber)
        {
            //var result = await _fileService.GetFileInfo(referenceNumber);
            //return Ok(result);

            return Ok(await Mediator.Send(new GetFileQuery { ReferenceNumber=referenceNumber}));

        }

        [HttpGet("GetFileContent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFileContent(Guid referenceNumber)
        {
            return Ok(await Mediator.Send(new GetFileContentQuery { ReferenceNumber= referenceNumber }));
        }



        [HttpPost("AddFile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> AddFile(IFormFile formFile)
        {
            return Ok(await Mediator.Send(new CreateFileCommand() { FormFile = formFile }));
        }

        //public async Task<IActionResult> AddFile(CreateFileCommand createFileCommand)
        //{
        //    return Ok(await Mediator.Send(createFileCommand));
        //}

        [HttpDelete("DeleteFile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteFile(Guid referenceNumber)
        {
            return Ok(await Mediator.Send(new DeleteFileCommand { ReferenceNumber=referenceNumber}));
        }
    }
}
