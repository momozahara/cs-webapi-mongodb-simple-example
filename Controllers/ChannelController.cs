using Microsoft.AspNetCore.Mvc;

using myapi.Models;
using myapi.Services;

namespace myapi.Controllers;

[Route("Channel")]
public class ChannelController : ControllerBase
{
    private readonly ILogger<ChannelController> _logger;
    private readonly ChannelService _channelService;

    public ChannelController(ILogger<ChannelController> logger, ChannelService channelService)
    {
        _logger = logger;
        _channelService = channelService;
    }

    [HttpGet("Get", Name = "GetChannel")]
    public async Task<ChannelResponse> Get()
    {
        List<ChannelWithoutId> channels = await _channelService.GetWithoutIdAsync();

        if (channels is null)
        {
            return null;
        }

        ChannelResponse response = new ChannelResponse();
        response.Channels = channels.OrderBy(channel => channel.Weight).ToList();

        return response;
    }
}

[Route("Dbg/Channel")]
public class ChannelDebugController : ControllerBase
{
    private readonly ILogger<ChannelDebugController> _logger;
    private readonly ChannelService _channelService;

    public ChannelDebugController(ILogger<ChannelDebugController> logger, ChannelService channelService)
    {
        _logger = logger;
        _channelService = channelService;
    }

    [HttpGet("Get", Name = "GetChannelDebug")]
    public async Task<ChannelDebugResponse> Get()
    {
        List<Channel> channels = await _channelService.GetAsync();

        if (channels is null)
        {
            return null;
        }

        ChannelDebugResponse response = new ChannelDebugResponse();
        response.channels = channels.OrderBy(channel => channel.Weight).ToList();

        return response;
    }
}
