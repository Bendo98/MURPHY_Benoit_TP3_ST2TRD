FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MURPHY_Benoit_TP3_ST2TRD/MURPHY_Benoit_TP3_ST2TRD.csproj", "MURPHY_Benoit_TP3_ST2TRD/"]
RUN dotnet restore "MURPHY_Benoit_TP3_ST2TRD/MURPHY_Benoit_TP3_ST2TRD.csproj"
COPY . .
WORKDIR "/src/MURPHY_Benoit_TP3_ST2TRD"
RUN dotnet build "MURPHY_Benoit_TP3_ST2TRD.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MURPHY_Benoit_TP3_ST2TRD.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MURPHY_Benoit_TP3_ST2TRD.dll"]
