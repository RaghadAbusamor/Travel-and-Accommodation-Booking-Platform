#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
ENV ASPNETCORE_URLS=http://+:8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TravelAccommodationBooking.Web/TravelAccommodationBooking.Web.csproj", "TravelAccommodationBooking.Web/"]
COPY ["TravelAccommodationBooking.BLL/TravelAccommodationBooking.BLL.csproj", "TravelAccommodationBooking.BLL/"]
COPY ["TravelAccommodationBooking.Model/TravelAccommodationBooking.Model.csproj", "TravelAccommodationBooking.Model/"]
COPY ["TravelAccommodationBooking.Security/TravelAccommodationBooking.Security.csproj", "TravelAccommodationBooking.Security/"]
COPY ["TravelAccommodationBooking.Config/TravelAccommodationBooking.Config.csproj", "TravelAccommodationBooking.Config/"]
RUN dotnet restore "./TravelAccommodationBooking.Web/TravelAccommodationBooking.Web.csproj"
COPY . .
WORKDIR "/src/TravelAccommodationBooking.Web"
RUN dotnet build "./TravelAccommodationBooking.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TravelAccommodationBooking.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TravelAccommodationBooking.Web.dll"]