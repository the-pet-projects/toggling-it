FROM microsoft/aspnetcore AS aspnetcore
WORKDIR /app

COPY ./src/Presentation.API/publish .

ENTRYPOINT ["dotnet", "Presentation.API.dll"]

# run image
# docker run --name ftm-test -p 8181:80 docker-tutorial 