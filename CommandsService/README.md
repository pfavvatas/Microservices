commands:

**Docker:**

1. `docker build -t pfavvatas/commandsservice .`
2. `docker run -p 8080:80 --name commandsservice-container -d pfavvatas/commandsservice`
3. `docker ps`
   CONTAINER ID IMAGE COMMAND CREATED STATUS PORTS NAMES

   93c11c33c0ae pfavvatas/commandsservice "dotnet PlatformServ…" Less than a second ago Up 30 seconds 0.0.0.0:8080->80/tcp dreamy_euclid

4. `docker stop "CONTAINER ID"` example `docker stop 93c11c33c0ae`
5. `docker start "CONTAINER ID"` example `docker start 93c11c33c0ae`
6. `docker push pfavvatas/commandsservice`

**Kubernetes:**
Kubernetes is running ? `kubectl version`

1. Apply .yaml file `kubectl apply -f commands-depl.yaml`
2. `kubectl get deployments`
3. `kubectl get pods`
4. delete deployment `kubectl delete deployment commands-depl`
5. Access to Service: Need to create a Node port mapping `K8S\commands-np-srv.yaml`
   1. `kubectl apply -f commands-np-srv.yaml`
   2. `kubectl get services` find the port
   <!-- 3. test service `http://localhost:32271/api/platforms` -->

**Troubleshooting:**
Here are a few things you can check and troubleshoot to resolve this issue:

1. Verify the service and its port: Ensure that the service "commands-clusterip-srv" is correctly defined in your Kubernetes cluster, and it is exposing port 80. You can check the service configuration using the kubectl get service command.

2. Check if the service is running: Verify that the pod associated with the service is running and healthy. You can use the kubectl get pods command to list the pods and check their status. If the pod is not running, investigate any error messages or events associated with it using kubectl describe pod <pod-name>.

3. Check the service's endpoint: If the pod is running successfully, check the service's endpoint. You can use the kubectl describe service commands-clusterip-srv command to get more details about the service. Ensure that the endpoints are correctly set, and the pod's IP address and port are included.

   1. Check if there are any running pods with the correct labels by running kubectl get pods -l app=commandsservice. If no pods are listed, it means there are none currently running.
   2. If there are no pods running, investigate why they might not be running. You can use kubectl describe pod <pod-name> for more information about the pods' status and any error messages.

   3. Verify that the pods are correctly labeled with app=commandsservice. If the labels are missing or incorrect, you may need to update the pod's labels or modify the selector of the service to match the correct labels.

   4. If the pods are running, but the service is still not picking them up as endpoints, it could be due to an issue with the pod readiness or the selector labels. Check the pod's readiness status using kubectl describe pod <pod-name> and ensure that the pods are reporting as "Ready."

   5. If you recently deployed or updated the pods, it's possible that the service hasn't discovered the new endpoints yet. In that case, you can try deleting and recreating the service using kubectl delete service commands-clusterip-srv followed by kubectl create service clusterip commands-clusterip-srv --tcp=80:80 --dry-run=client -o yaml | kubectl apply -f - to force the update.

4. Verify network policies: If you are using network policies in your cluster, ensure that they are not blocking the network traffic to the service. Check if there are any policies that could be causing the connection to be refused. You can use the kubectl get networkpolicies command to list the existing network policies.

5. Firewall or network issues: Check if there are any firewall rules or network restrictions outside of Kubernetes that could be blocking the connection. Make sure that the necessary network ports are open for communication.

6. DNS resolution: Ensure that the service's DNS name resolves correctly to the expected IP address. You can test DNS resolution using tools like nslookup or dig.
