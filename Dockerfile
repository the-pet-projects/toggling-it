FROM microsoft/aspnetcore
WORKDIR /app
COPY ./publish .
ENTRYPOINT ["dotnet", "Presentation.API.dll"]