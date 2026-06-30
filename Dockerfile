# FROM docker-registry-002.zeuslearning.com/zeuslearning/dotnet/sdk:10.0-alpine AS build
# WORKDIR /src
# COPY . .
# RUN dotnet restore
# RUN dotnet publish -c Release -o /app

# FROM docker-registry-002.zeuslearning.com/zeuslearning/dotnet/aspnet:10.0-alpine
# WORKDIR /app
# COPY --from=build /app .
# ENTRYPOINT ["dotnet", "TraineeManagement.dll"]


FROM docker-registry-002.zeuslearning.com/zeuslearning/dotnet/aspnet:10.0-alpine AS runtime
WORKDIR /app

ENV ASPNETCORE_ENVIRONMENT=Development
ENV DOTNET_RUNNING_IN_CONTAINER=true

COPY ./TraineeManagement/publish .

ENTRYPOINT ["dotnet", "TraineeManagement.dll"]