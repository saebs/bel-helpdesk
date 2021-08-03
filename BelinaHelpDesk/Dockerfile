FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["BelinaHelpDesk/BelinaHelpDesk.csproj", "BelinaHelpDesk/"]
RUN dotnet restore "BelinaHelpDesk/BelinaHelpDesk.csproj"
COPY . .
WORKDIR "/src/BelinaHelpDesk"
RUN dotnet build "BelinaHelpDesk.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BelinaHelpDesk.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BelinaHelpDesk.dll"]
