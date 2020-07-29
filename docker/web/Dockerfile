FROM mcr.microsoft.com/dotnet/framework/aspnet:3.5-windowsservercore-ltsc2019 AS v4
SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

RUN Install-WindowsFeature NET-HTTP-Activation; \
    Remove-Website -Name 'Default Web Site'; \
    New-Website -Name 'petshop-web' -Port 80 -PhysicalPath 'C:\petshop-web' -Force

COPY ./zips/petshop-web.zip .
RUN Expand-Archive -Path petshop-web.zip -DestinationPath /

COPY ./docker/web/web.config /petshop-web/
COPY ./docker/web/config/*.config /petshop-web/config/

# v4.1 new project
FROM mcr.microsoft.com/dotnet/framework/sdk:3.5-windowsservercore-ltsc2019 AS v41-builder

WORKDIR /src/PetShop
COPY src/PetShop/PetShop.sln .
COPY src/PetShop/IDAL/IDAL.csproj ./IDAL/
COPY src/PetShop/DALFactory/DALFactory.csproj ./IDAL/
COPY src/PetShop/ServiceDAL/ServiceDAL.csproj ./ServiceDAL/
COPY src/PetShop/ServiceDAL/packages.config ./ServiceDAL/
RUN nuget restore PetShop.sln

COPY src /src
RUN msbuild ServiceDAL/ServiceDAL.csproj /p:OutputPath=c:/out/
RUN msbuild DALFactory/DALFactory.csproj /p:OutputPath=c:/out/

# v4.1 update
FROM v4 as v41
COPY --from=v41-builder /out/ /petshop-web/bin