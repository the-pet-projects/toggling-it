failureCode=0
for line in $(find -name '*.csproj' | grep -G '^.\/test\/integration\/.*\.csproj'); 
do 
	dotnet restore $line;
	dotnet test --logger trx -c "Release" $line;
	lastExitCode=$?;
    	echo "lastexitcode=$lastExitCode";
    	if [ $lastExitCode != 0 ] ; then
		echo "setting failurecode $lastExitCode";
    		failureCode=$lastExitCode;
    	fi; 
done;
if [ $failureCode != 0 ] ; then
	echo "exiting with status code $failureCode";
	exit $failureCode;
fi;
