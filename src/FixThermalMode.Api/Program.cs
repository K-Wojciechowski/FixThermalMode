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

using FixThermalMode.Api;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Hosting.WindowsServices;


var builder = WebApplication.CreateBuilder(new WebApplicationOptions {
  Args = args,
  ContentRootPath = WindowsServiceHelpers.IsWindowsService() ? AppContext.BaseDirectory : default
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(options => {
  options.DefaultScheme = ApiKeyAuthenticationHandler.SchemeName;
  options.DefaultAuthenticateScheme = ApiKeyAuthenticationHandler.SchemeName;
  options.DefaultChallengeScheme = ApiKeyAuthenticationHandler.SchemeName;
}).AddScheme<AuthenticationSchemeOptions, ApiKeyAuthenticationHandler>(
  ApiKeyAuthenticationHandler.SchemeName, _ => { });
builder.Host.UseWindowsService();

if (WindowsServiceHelpers.IsWindowsService()) {
  builder.WebHost.UseUrls("http://localhost:3386/");
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
