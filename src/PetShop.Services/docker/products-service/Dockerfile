ARG SDK_TAG=5.0.100-preview.7
ARG ASPNET_TAG=5.0.0-preview.7
FROM mcr.microsoft.com/dotnet/sdk:${SDK_TAG} AS builder

WORKDIR /src
COPY src/PetShop.Services.Entities/PetShop.Services.Entities.csproj ./PetShop.Services.Entities/
COPY src/PetShop.Services.Model/PetShop.Services.Model.csproj ./PetShop.Services.Model/
COPY src/PetShop.Services.Products/PetShop.Services.Products.csproj ./PetShop.Services.Products/

WORKDIR /src/PetShop.Services.Products
RUN dotnet restore

COPY src /src
RUN dotnet publish -c Release -o /out PetShop.Services.Products.csproj

# app image
FROM mcr.microsoft.com/dotnet/aspnet:${ASPNET_TAG} AS common
ENTRYPOINT ["dotnet", "/app/PetShop.Services.Products.dll"]
WORKDIR /app
COPY --from=builder /out/ .

# alpine tweaks
FROM common AS alpine
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk add --no-cache icu-libs