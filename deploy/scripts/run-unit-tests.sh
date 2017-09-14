failureCode=0
for line in $(find -name '*.sln' -maxdepth 1 | grep -G '^.*\.sln'); 
do 
    echo "restoring $line";
	dotnet restore $line;
done;
for line in $(find -name '*.csproj' | grep -G '^.\/test\/unit\/.*\.csproj'); 
do 
	dotnet test --no-build --logger trx -c "Release" $line;
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
