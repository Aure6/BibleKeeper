using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

// Ajout des namespaces nécessaires pour les services et modèles
using Blazored.LocalStorage;
using BibleKeeper.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthenticationStateDeserialization();

// Ajout du service de gestion des favoris
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<FavoritesService>();

await builder.Build().RunAsync();
