﻿using CafrilearnBackend.IRepositories;
using CafrilearnBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CafrilearnBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = "Bearer")]
public class HelpController : ControllerBase
{
    private readonly IHelpRepository _helpRepository;

    public HelpController(IHelpRepository helpRepository)
    {
        _helpRepository = helpRepository;
    }


    [HttpPost("add")]
    public async Task<ActionResult> Add(Help help)
    {
        if (ModelState.IsValid)
        {
            await _helpRepository.AddHelpRequest(help);

            return Ok(help);
        }

        return BadRequest();
    }

    [HttpGet("all")]
    public ActionResult GetAll()
    {
        return Ok(_helpRepository.GetHelpRequests());
    }

    [HttpGet("getById/{id}")]
    public ActionResult GetById(int id)
    {
        return Ok(_helpRepository.GetHelpRequestById(id));
    }

    [HttpPut("update")]
    public async Task<ActionResult> Update(Help help)
    {
        if (ModelState.IsValid)
        {
            await _helpRepository.UpdateHelpRequest(help);

            return Ok(help);
        }

        return BadRequest();
    }

    [HttpDelete("delete/{id}")]
    public ActionResult Delete(int id)
    {
        var help = _helpRepository.GetHelpRequestById(id);

        if (help != null)
        {
            _helpRepository.DeleteHelpRequest(id);

            return Ok(help);
        }

        return BadRequest();
    }
}

