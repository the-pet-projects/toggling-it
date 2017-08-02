docker-compose -f docker-compose.integrationtests.yml -p netcoreintegrationtests rm -fsv
docker image rm -f petprojects/toggling-it:${BUILD_VERSION}
