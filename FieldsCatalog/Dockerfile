#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
RUN apt-get update
RUN apt-get install -y apt-utils
RUN apt-get install -y libgdiplus
RUN ln -s /usr/lib/libgdiplus.so /usr/lib/gdiplus.dll
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["FieldsCatalog/FieldsCatalog.csproj", "FieldsCatalog/"]
RUN dotnet restore "FieldsCatalog/FieldsCatalog.csproj"
COPY . .
WORKDIR "/src/FieldsCatalog"
RUN dotnet build "FieldsCatalog.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FieldsCatalog.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FieldsCatalog.dll"]