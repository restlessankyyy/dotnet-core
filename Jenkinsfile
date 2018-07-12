timestamps {

node ('linuxslave') { 

	stage (testproj - Checkout') {
 	 checkout([$class: 'GitSCM', branches: [[name: '*/master']], doGenerateSubmoduleConfigurations: false, extensions: [], submoduleCfg: [], userRemoteConfigs: [[credentialsId: '8d4da9bc-7e8e-4ecd-a3cd-ded741928fb8', url: 'https://git-codecommit.us-east-2.amazonaws.com/v1/repos/ce']]]) 
	}
	stage ('testproj - Build') {
 			// Shell build step
        withAWS(credentials:-aws-key'){
                sh 'eval $(aws ecr get-login --no-include-email --region us-east-2)'
                sh """
                docker build -t testproj :$TAG_NAME .
                docker tag testproj :$TAG_NAME 407769799504.dkr.ecr.us-east-2.amazonaws.com/test-ecr:$TAG_NAME
                docker push 504.dkr.ecr.us-east-2.amazonaws.com/:$TAG_NAME
                """
        }
	}
}
}
