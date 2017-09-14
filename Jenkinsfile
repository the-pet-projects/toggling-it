node {

	currentBuild.result = "SUCCESS"
	
    try {
		def version = VersionNumber(versionNumberString: '0.0.0.${BUILD_DATE_FORMATTED,\"yy\"}${BUILD_MONTH, XX}.${BUILDS_THIS_MONTH}')
		withEnv(['PIPELINE_VERSION='+version]) {
			timestamps {
				stage('Build'){
					def cenas = VersionNumber(versionNumberString: '0.0.0.${BUILD_DATE_FORMATTED,\"yy\"}${BUILD_MONTH, XX}.${BUILDS_THIS_MONTH}')
					echo cenas
					echo env.PIPELINE_VERSION
					echo version
					currentBuild.displayName = cenas
					deleteDir()
					checkout scm			
					
					try {
						sh '''sh ./deploy/scripts/build.ci.sh;'''
					}
					finally {
						sh '''sh ./deploy/scripts/build.ci.cleanup.sh;'''
					}
				}

				stage('Unit Tests'){
					try {
						sh '''sh ./deploy/scripts/build.ci.unittests.sh;'''
						step([$class: 'XUnitPublisher', testTimeMargin: '3000', thresholdMode: 1, thresholds: [[$class: 'FailedThreshold', failureNewThreshold: '', failureThreshold: '', unstableNewThreshold: '', unstableThreshold: ''], [$class: 'SkippedThreshold', failureNewThreshold: '', failureThreshold: '', unstableNewThreshold: '', unstableThreshold: '']], tools: [[$class: 'MSTestJunitHudsonTestType', deleteOutputFiles: true, failIfNotNew: true, pattern: '**/test/unit/**/*.trx', skipNoTestFiles: false, stopProcessingIfError: true]]])
					}
					finally {
						sh '''sh ./deploy/scripts/build.ci.unittests.cleanup.sh;'''		
					}
				}

				stage('Integration Tests'){
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
								
							step([$class: 'XUnitPublisher', testTimeMargin: '3000', thresholdMode: 1, thresholds: [[$class: 'FailedThreshold', failureNewThreshold: '', failureThreshold: '', unstableNewThreshold: '', unstableThreshold: ''], [$class: 'SkippedThreshold', failureNewThreshold: '', failureThreshold: '', unstableNewThreshold: '', unstableThreshold: '']], tools: [[$class: 'MSTestJunitHudsonTestType', deleteOutputFiles: true, failIfNotNew: true, pattern: '**/test/integration/**/*.trx', skipNoTestFiles: false, stopProcessingIfError: true]]])
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