#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 49603
EXPOSE 44393

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["Source/DockerSample.WebApi/DockerSample.WebApi.csproj", "Source/DockerSample.WebApi/"]
COPY ["Source/DockerSample.Infra.CrossCutting.IOC/DockerSample.Infra.CrossCutting.IOC.csproj", "Source/DockerSample.Infra.CrossCutting.IOC/"]
COPY ["Source/DockerSample.Infra.Data/DockerSample.Infra.Data.csproj", "Source/DockerSample.Infra.Data/"]
COPY ["Source/DockerSample.Domain/DockerSample.Domain.csproj", "Source/DockerSample.Domain/"]
COPY ["Source/DockerSample.Application/DockerSample.Application.csproj", "Source/DockerSample.Application/"]
RUN dotnet restore "Source/DockerSample.WebApi/DockerSample.WebApi.csproj"
COPY . .
WORKDIR "/src/Source/DockerSample.WebApi"
RUN dotnet build "DockerSample.WebApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DockerSample.WebApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DockerSample.WebApi.dll"]