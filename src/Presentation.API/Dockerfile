FROM microsoft/aspnetcore:1.1
ENTRYPOINT ["dotnet", "Presentation.API.dll"]
ARG source=.
WORKDIR /app
EXPOSE 80
COPY $source .