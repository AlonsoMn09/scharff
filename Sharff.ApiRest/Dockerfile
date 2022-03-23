#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Sharff.ApiRest/Sharff.ApiRest.csproj", "Sharff.ApiRest/"]
COPY ["Sharff.Domain.Model/Sharff.Domain.Model.csproj", "Sharff.Domain.Model/"]
COPY ["Shartff.Shared.ApiRest/Shartff.Shared.ApiRest.csproj", "Shartff.Shared.ApiRest/"]
COPY ["Sharff.Core/Sharff.Core.csproj", "Sharff.Core/"]
RUN dotnet restore "Sharff.ApiRest/Sharff.ApiRest.csproj"
COPY . .
WORKDIR "/src/Sharff.ApiRest"
RUN dotnet build "Sharff.ApiRest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sharff.ApiRest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sharff.ApiRest.dll"]