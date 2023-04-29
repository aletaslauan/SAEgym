#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SAEgym/SAEgym.csproj", "SAEgym/"]
RUN dotnet restore "SAEgym/SAEgym.csproj"
COPY . .
WORKDIR "/src/SAEgym"
RUN dotnet build "SAEgym.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SAEgym.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SAEgym.dll"]