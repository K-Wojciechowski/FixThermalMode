/*
 * FixThermalMode
 * Copyright © 2024 Krzysztof Wojciechowski
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <https://www.gnu.org/licenses/>.
 */

using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace FixThermalMode.Api;

public class ApiKeyAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions> {
  private readonly string _expectedAuthHeader;
  private readonly bool _apiKeyPresent;

  public const string SchemeName = "Bearer";
  public const string RoleName = "FTMUser";
  private const string FailureMessage = "Invalid Authorization header value";

  private static ClaimsPrincipal Principal => new(
    [
      new ClaimsIdentity(
        claims: [new Claim(ClaimTypes.Role, RoleName, ClaimValueTypes.String)],
        authenticationType: SchemeName
      )
    ]);

  public ApiKeyAuthenticationHandler(
    IConfiguration configuration,
    IOptionsMonitor<AuthenticationSchemeOptions> options,
    ILoggerFactory logger,
    UrlEncoder encoder)
    : base(options, logger, encoder) {
    var apiKey = configuration.GetValue<string>("ApiKey");
    _expectedAuthHeader = $"Bearer {apiKey}";
    _apiKeyPresent = !string.IsNullOrWhiteSpace(apiKey);
  }

  protected override Task<AuthenticateResult> HandleAuthenticateAsync() {
    if (_apiKeyPresent) {
      var authHeader = Request.Headers.Authorization;
      if (authHeader != _expectedAuthHeader) {
        return Task.FromResult(AuthenticateResult.Fail(FailureMessage));
      }
    }

    var ticket = new AuthenticationTicket(Principal, SchemeName);
    return Task.FromResult(AuthenticateResult.Success(ticket));
  }
}
