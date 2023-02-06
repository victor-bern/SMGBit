FROM mcr.microsoft.com/dotnet/sdk:7.0 as build-image

WORKDIR /home/app/BackEnd

COPY /smgbit-back ./
RUN for file in $(ls *.csproj); do mkdir -p ./${file%.*}/ && mv $file ./${file%.*}/; done

RUN dotnet restore

COPY . .


RUN dotnet publish ./src/SMGbit/SMGBit.Api.csproj -o /publish/

FROM mcr.microsoft.com/dotnet/aspnet:7.0	

WORKDIR /publish


EXPOSE 80
COPY --from=build-image /publish .

ENTRYPOINT ["dotnet", "SMGBit.Api.dll"]