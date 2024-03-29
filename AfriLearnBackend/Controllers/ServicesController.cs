﻿using CafrilearnBackend.Constants;
using CafrilearnBackend.Models;
using CafrilearnBackend.Services;
using CafrilearnBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using System;
using System.IO;
using System.Text;

namespace CafrilearnBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = "Bearer")]
public class ServicesController : ControllerBase
{
    private readonly AfriLearnDbContext _context;
    private static IConfiguration Configuration;

    public ServicesController(AfriLearnDbContext context, IConfiguration configuration)
    {
        _context = context;
        Configuration = configuration;
    }

    [HttpPost("resetPassword")]
    [AllowAnonymous]
    public IActionResult ChangePasswordDto([FromBody] ChangePasswordDto changePasswordDto)
    {
        if (ModelState.IsValid)
        {
            var code = EmailServices.SendEmailForPasswordRecoveryCode(changePasswordDto.Email);

            return Ok(code);
        }

        return BadRequest($"Could not send password recovery code to user with email {changePasswordDto.Email}");
    }

    [HttpPost("Images")]
    public IActionResult StoreBlob([FromBody] BlobItemDto blobItemDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Invalid Request Parameters");
        }
        var reaiotConfiguration = Configuration.GetSection("BlobStorageDetails");
        var reaiotCredentials = reaiotConfiguration.Get<BlobStorageCredentials>();
        var connectionString = Encoding.ASCII.GetBytes(reaiotCredentials.ConnectionString1).ToString();
        var credentials = new BlobStorageCredentials()
        {
            ConnectionString1 = connectionString
        };
        var account = CloudStorageAccount.Parse(credentials.ConnectionString1);
        var blobClient = account.CreateCloudBlobClient();
        var container = blobClient.GetContainerReference(AppConstants.ContainerName);
        string uniqueName = Guid.NewGuid().ToString();
        var userKey = blobItemDto.ContainerName;
        var blockBlob = container.GetBlockBlobReference($"{userKey}{uniqueName}.jpg");
        blockBlob.UploadFromStreamAsync(new MemoryStream(blobItemDto.TakenImageBytes));

        return Ok(blockBlob.Uri.OriginalString);
    }
}

