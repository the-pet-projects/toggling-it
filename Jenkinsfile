node {
	currentBuild.result = "SUCCESS"
	
    try {
		def version = VersionNumber(versionNumberString: '0.0.0.${BUILD_DATE_FORMATTED,\"yy\"}${BUILD_MONTH, XX}.${BUILDS_THIS_MONTH}')
		withEnv(['PIPELINE_VERSION='+version]) {
			timestamps {
				buildStep('Build'){
					gitContext = 'Build'
					currentBuild.displayName = '#'+env.PIPELINE_VERSION
					deleteDir()
					checkout scm			
					try {
						sh '''sh ./deploy/scripts/build.ci.sh;'''
					}
					finally {
						sh '''sh ./deploy/scripts/build.ci.cleanup.sh;'''						
					}
				}

				buildStep('Unit Tests'){
					try {
						sh '''sh ./deploy/scripts/build.ci.unittests.sh;'''
						step([$class: 'MSTestPublisher', testResultsFile: '**/test/unit/**/*.trx', failOnError: true, keepLongStdio: true])
					}
					finally {
						sh '''sh ./deploy/scripts/build.ci.unittests.cleanup.sh;'''		
					}
				}

				buildStep('Integration Tests'){
					withCredentials([usernamePassword(credentialsId: 'dockerhub', passwordVariable: 'DOCKER_USER_PASSWORD', usernameVariable: 'DOCKER_USER_NAME')]) {
						sshagent(['Toggling-It-Api']) {
							sh '''BUILD_VERSION=${PIPELINE_VERSION};
								export BUILD_VERSION;
								sh ./deploy/scripts/build.ci.integrationtests.sh;
								exitCode=$?;
								if [ $exitCode -eq 0 ]; then
									echo "integration tests successful... pushing img to dockerhub...";
									docker login -u ${DOCKER_USER_NAME} -p ${DOCKER_USER_PASSWORD};
									sh ./deploy/scripts/build.ci.pushimg.sh;
									exitCode=$?;
									docker logout;
								fi;
								sh ./deploy/scripts/build.ci.integrationtests.cleanup.sh;
								exit $exitCode;'''
							
							sh '''git tag -f ${PIPELINE_VERSION};
								git push origin ${PIPELINE_VERSION};'''								
							
							step([$class: 'MSTestPublisher', testResultsFile: '**/test/integration/**/*.trx', failOnError: true, keepLongStdio: true])
						}
					}			
				}
			}
		}
    }
    catch (err) {
        currentBuild.result = "FAILURE"
		cleanWs()
        throw err
    }
}

def gitRepoUrl = 'https://github.com/the-pet-projects/toggling-it/'

void buildStep(String context, Closure closure) {
	stage(context);
	try {
		setBuildStatus(context, "In progress...", "PENDING");
		closure();
	} catch (Exception e) {
		setBuildStatus(context, e.take(140), "FAILURE");
	}
	setBuildStatus(context, "Success", "SUCCESS");
}

// Updated to account for context
void setBuildStatus(String context, String message, String state) {
	step([
		$class: "GitHubCommitStatusSetter",
		reposSource: [$class: "ManuallyEnteredRepositorySource", url: gitRepoUrl],
		contextSource: [$class: "ManuallyEnteredCommitContextSource", context: context],
		errorHandlers: [[$class: "ChangingBuildStatusErrorHandler", result: "UNSTABLE"]],
		statusResultSource: [ $class: "ConditionalStatusResultSource", results: [[$class: "AnyBuildResult", message: message, state: state]] ]
	]);
}