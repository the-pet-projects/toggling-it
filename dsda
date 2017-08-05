FROM microsoft/aspnetcore:1.1  
ARG source  
RUN echo "source: $source"  
WORKDIR /app  
COPY ${source:-/build} .  
EXPOSE 80  
ENTRYPOINT ["dotnet", "Presentation.API.dll"]  