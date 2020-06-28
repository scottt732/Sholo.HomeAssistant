![Banner](Images/Banner.png)

# Sholo.HomeAssistant

[![Sholo.HomeAssistant NuGet Package](https://img.shields.io/nuget/v/Sholo.HomeAssistant.svg)](https://www.nuget.org/packages/Sholo.Utils/)
[![Twitter URL](https://img.shields.io/twitter/url/http/shields.io.svg?style=social)](https://twitter.com/scottt732)
[![Twitter Follow](https://img.shields.io/twitter/follow/scottt732.svg?style=social&label=Follow)](https://twitter.com/scottt732)

This repository contains libraries which allow communication with Home Assistant in the following ways:

- **A REST API client**: Strongly-typed HttpClient-based client based on the [Rest API docs found here](https://developers.home-assistant.io/docs/api/rest/)
- **A durable Websockets API client**: Repairs connections & restores subscriptions (but doesn't recover from missed messages) baed on the [WebSocket API docs found here](https://developers.home-assistant.io/docs/api/websocket).  This makes use of Reactive Extensions/`IObservable` and NETStandard2.1's `IAsyncEnumerable`.
- **MQTT Device Discovery**: The ability to expose devices or application code as devices in Home Assistant via MQTT discovery based on [the docs found here](https://www.home-assistant.io/docs/mqtt/discovery/)

## Status

Treat this as an early alpha for now.  The API surface area is subject to change without notice and there are
some known incomplete or broken spots.

- Some of the code was manually tested against a dev instance of Home Assistant
- A little bit has been running 24/7 against my primary Home Assistant instance
- Most of the code was written while reading the HA docs and hasn't been tested
- Unit/integration tests are on the roadmap before a 1.0 release
- I keep my Home Assistant instances up-to-date.  I don't plan on supporting 
  older versions (possibly ever, at a minimum until HA hits 1.0 and stabilizes).

It may be rough around the edges. I was building the features out very quickly as I needed them.  I'm happy to accept
contributions but please submit an issue or pull request / be patient if you run into rough spots.

If anyone is interested in contributing or helping out in any way please reach out.

## Thanks

Thanks to the [Home Assistant](https://www.home-assistant.io/) team & [contributors](https://github.com/home-assistant/core/graphs/contributors)!

A huge thanks to [@RahenSaeedUK](https://twitter.com/RehanSaeedUK) for the [.NET Boxed Templates](https://github.com/Dotnet-Boxed/Templates), without which I probably
would have never gotten around to releasing any of this.

## Related Projects

I've been building a bunch of small utilities, applications, and container related to home automation,
primarily using MQTT and/or [Home Assistant](https://www.home-assistant.io/).

There are a few foundational libraries/frameworks that I've created along the way.  The table shows the third-party pieces
they're built on.

<table width="100%">
    <tr>
        <th colspan="4">Home Automation Foundation Libraries</th>
    </tr>
    <tr>
        <th width="25%"><a href="https://github.com/scottt732/Sholo.CommandLine">Sholo.CommandLine</a></td>
        <th width="25%"><a href="https://github.com/scottt732/Sholo.HomeAssistant">Sholo.HomeAssistant</a></td>
        <th width="25%"><a href="https://github.com/scottt732/Sholo.Mqtt">Sholo.Mqtt</a></td>
        <th width="25%"><a href="https://github.com/scottt732/Sholo.Utils">Sholo.Utils</a></td>
    </tr>
    <tr>
        <th width="25%"><a href="https://github.com/natemcmaster/CommandLineUtils">natemcmaster/CommandLineUtils</a></td>
        <th width="25%">-</td>
        <th width="25%"><a href="https://github.com/chkr1011/MQTTnet">chkr1011/MQTTnet</a></td>
        <th width="25%">-</td>
    </tr>
</table>

And a handful of applications that I plan to publish soon.

## License

MIT License

Copyright (c) 2020 Scott Holodak

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
