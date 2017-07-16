FROM microsoft/aspnetcore:1.1 AS aspnetcore
ARG source
RUN echo "source: $source"

WORKDIR /app

COPY ${source:-/build} .
EXPOSE 65455

ENTRYPOINT ["dotnet", "Presentation.API.dll"]

# run image
# docker run --name ftm-test -p 8181:80 ftm-test 